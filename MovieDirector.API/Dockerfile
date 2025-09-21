FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ../MovieDirectorApp.sln ./
COPY ../MovieDirectorApp.Api/MovieDirectorApp.Api.csproj ./MovieDirectorApp.Api/
COPY ../MovieDirectorApp.Application/MovieDirectorApp.Application.csproj ./MovieDirectorApp.Application/
COPY ../MovieDirectorApp.Infrastructure/MovieDirectorApp.Infrastructure.csproj ./MovieDirectorApp.Infrastructure/
COPY ../MovieDirectorApp.Domain/MovieDirectorApp.Domain.csproj ./MovieDirectorApp.Domain/

RUN dotnet restore "MovieDirectorApp.sln"

COPY . .
WORKDIR "/src/MovieDirectorApp.Api"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "MovieDirectorApp.Api.dll"]
