#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/services/elibrary/ELibrary.API/ELibrary.API.csproj", "src/services/elibrary/ELibrary.API/"]
COPY ["src/modules/ModuleDistributor.Dapr.HealthCheck/ModuleDistributor.Dapr.HealthCheck.csproj", "src/modules/ModuleDistributor.Dapr.HealthCheck/"]
COPY ["src/modules/ModuleDistributor.Dapr.Configuration/ModuleDistributor.Dapr.Configuration.csproj", "src/modules/ModuleDistributor.Dapr.Configuration/"]
COPY ["src/modules/ModuleDistributor.Dapr/ModuleDistributor.Dapr.csproj", "src/modules/ModuleDistributor.Dapr/"]
COPY ["src/modules/ModuleDistributor/ModuleDistributor.csproj", "src/modules/ModuleDistributor/"]
COPY ["src/modules/ModuleDistributor.Logging/ModuleDistributor.Logging.csproj", "src/modules/ModuleDistributor.Logging/"]
COPY ["src/modules/ModuleDistributor.Serilog/ModuleDistributor.Serilog.csproj", "src/modules/ModuleDistributor.Serilog/"]
COPY ["src/services/elibrary/ELibrary.Services/ELibrary.Services.csproj", "src/services/elibrary/ELibrary.Services/"]
COPY ["src/modules/ModuleDistributor.Grpc/ModuleDistributor.Grpc.csproj", "src/modules/ModuleDistributor.Grpc/"]
COPY ["src/services/elibrary/ELibrary.EntityFrameworkCore/ELibrary.EntityFrameworkCore.csproj", "src/services/elibrary/ELibrary.EntityFrameworkCore/"]
COPY ["src/modules/ModuleDistributor.EntityFrameworkCore/ModuleDistributor.EntityFrameworkCore.csproj", "src/modules/ModuleDistributor.EntityFrameworkCore/"]
COPY ["src/services/elibrary/ELibrary.Shared/ELibrary.Shared.csproj", "src/services/elibrary/ELibrary.Shared/"]
COPY ["src/services/identities/Identities.Shared/Identities.Shared.csproj", "src/services/identities/Identities.Shared/"]
COPY ["src/services/elibrary/ELibrary.Protos/ELibrary.Protos.csproj", "src/services/elibrary/ELibrary.Protos/"]
RUN dotnet restore "./src/services/elibrary/ELibrary.API/./ELibrary.API.csproj"
COPY . .
WORKDIR "/src/src/services/elibrary/ELibrary.API"
RUN dotnet build "./ELibrary.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ELibrary.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ELibrary.API.dll"]