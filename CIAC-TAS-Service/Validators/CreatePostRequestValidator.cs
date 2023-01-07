using CIAC_TAS_Service.Contracts.V1.Requests;
using FluentValidation;

namespace CIAC_TAS_Service.Validators
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9]*$");
        }
    }
}
