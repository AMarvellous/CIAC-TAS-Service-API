using CIAC_TAS_Service.Contracts.HealthChecks;
using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Installers;
using CIAC_TAS_Service.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DataContext>();


builder.Services.InstallServicesInAssembly(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

////////
using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();

    await dbContext.Database.MigrateAsync();

    //Roles
    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        var adminRole = new IdentityRole("Admin");
        await roleManager.CreateAsync(adminRole);
    }

    if (!await roleManager.RoleExistsAsync("Poster"))
    {
        var posterRole = new IdentityRole("Poster");
        await roleManager.CreateAsync(posterRole);
    }

    if (!await roleManager.RoleExistsAsync("Estudiante"))
    {
        var estudianteRole = new IdentityRole("Estudiante");
        await roleManager.CreateAsync(estudianteRole);
    }

    //Users
    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    //var userRoleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityUserRole>>();

    if (await userManager.FindByNameAsync("Admin") == null)
    {
        var identityUser = new IdentityUser
        {
            UserName = "Admin",
            Email = "ciac.tas@gmail.com",
        };
        var identityResult = await userManager.CreateAsync(identityUser , "3FMa[E8UZq/{=c,z");

        if (identityResult.Succeeded)
        {
            await userManager.AddToRoleAsync(identityUser, "Admin");
        }
    }
}

//await app.RunAsync();
////////

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseHsts();
}

app.UseHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var response = new HealthCheckResponse
        {
            Status = report.Status.ToString(),
            Checks = report.Entries.Select(x => new HealthCheck
            {
                Component = x.Key,
                Status = x.Value.Status.ToString(),
                Description = x.Value.Description
            }),
            Duration = report.TotalDuration
        };

        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
});

var swaggerOptions = new SwaggerOptions();
builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

app.UseSwagger(option =>
{
    option.RouteTemplate = swaggerOptions.JsonRoute;
});
app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
