#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/clients/ELibrary.Fronted/ELibrary.Fronted.csproj", "src/clients/ELibrary.Fronted/"]
COPY ["src/modules/ModuleDistributor.Dapr.HealthCheck/ModuleDistributor.Dapr.HealthCheck.csproj", "src/modules/ModuleDistributor.Dapr.HealthCheck/"]
COPY ["src/modules/ModuleDistributor.Dapr.Configuration/ModuleDistributor.Dapr.Configuration.csproj", "src/modules/ModuleDistributor.Dapr.Configuration/"]
COPY ["src/modules/ModuleDistributor.Dapr/ModuleDistributor.Dapr.csproj", "src/modules/ModuleDistributor.Dapr/"]
COPY ["src/modules/ModuleDistributor/ModuleDistributor.csproj", "src/modules/ModuleDistributor/"]
COPY ["src/modules/ModuleDistributor.Logging/ModuleDistributor.Logging.csproj", "src/modules/ModuleDistributor.Logging/"]
COPY ["src/modules/ModuleDistributor.Serilog/ModuleDistributor.Serilog.csproj", "src/modules/ModuleDistributor.Serilog/"]
COPY ["src/services/elibrary/ELibrary.Protos/ELibrary.Protos.csproj", "src/services/elibrary/ELibrary.Protos/"]
COPY ["src/services/healthchecks/HealthChecks.Fronted.Shared/HealthChecks.Fronted.Shared.csproj", "src/services/healthchecks/HealthChecks.Fronted.Shared/"]
COPY ["src/services/identities/Identities.Protos/Identities.Protos.csproj", "src/services/identities/Identities.Protos/"]
RUN dotnet restore "./src/clients/ELibrary.Fronted/./ELibrary.Fronted.csproj"
COPY . .
WORKDIR "/src/src/clients/ELibrary.Fronted"
RUN dotnet build "./ELibrary.Fronted.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ELibrary.Fronted.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ELibrary.Fronted.dll"]