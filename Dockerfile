# Dockerfile inside MovieDirectorApp.Api/
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ../MovieDirectorApp.sln ./
COPY ../MovieDirector.API/MovieDirector.API.csproj ./MovieDirector.API/
COPY ../MovieDirectorApp.Application/MovieDirectorApp.Application.csproj ./MovieDirectorApp.Application/
COPY ../MovieDirectorApp.Infrastructure/MovieDirectorApp.Infrastructure.csproj ./MovieDirectorApp.Infrastructure/
COPY ../MovieDirectorApp.Domain/MovieDirectorApp.Domain.csproj ./MovieDirectorApp.Domain/
COPY ../MovieDirectorApp.Tests/MovieDirectorApp.Tests.csproj ./MovieDirectorApp.Tests/

RUN dotnet restore "MovieDirectorApp.sln"

COPY ../ ./
WORKDIR "/src/MovieDirector.API"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "MovieDirector.API.dll"]
