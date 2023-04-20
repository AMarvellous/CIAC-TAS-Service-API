FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

COPY CIAC-TAS-Service.csproj /build/

RUN dotnet restore ./build/CIAC-TAS-Service.csproj

COPY . ./build/
WORKDIR /build/
RUN dotnet publish ./CIAC-TAS-Service.csproj -c $BUILDCONFIG -o out /p:Version=$VERSION

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

COPY --from=build /build/out .

ENTRYPOINT ["dotnet", "CIAC-TAS-Service.dll"]












