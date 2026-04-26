# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/Patient.Service/Patient.Api/Patient.Api.csproj", "services/Patient.Service/Patient.Api/"]
COPY ["services/Patient.Service/Patient.Application/Patient.Application.csproj", "services/Patient.Service/Patient.Application/"]
COPY ["services/Patient.Service/Patient.Core/Patient.Core.csproj", "services/Patient.Service/Patient.Core/"]
COPY ["services/Patient.Service/Patient.Infrastructure/Patient.Infrastructure.csproj", "services/Patient.Service/Patient.Infrastructure/"]
RUN dotnet restore "./services/Patient.Service/Patient.Api/Patient.Api.csproj"
COPY . .
WORKDIR "/src/services/Patient.Service/Patient.Api"
RUN dotnet build "./Patient.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Patient.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Patient.Api.dll"]