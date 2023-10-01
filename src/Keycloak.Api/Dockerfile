FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Keycloak.Api/Keycloak.Api.csproj", "src/Keycloak.Api/"]
RUN dotnet restore "src/Keycloak.Api/Keycloak.Api.csproj"
COPY . .
WORKDIR "/src/src/Keycloak.Api"
RUN dotnet build "Keycloak.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Keycloak.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Keycloak.Api.dll"]
