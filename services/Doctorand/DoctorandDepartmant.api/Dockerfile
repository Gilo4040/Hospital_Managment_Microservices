# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
# Stage 0: Base runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 1?? ??? ????? ???????? ??? (csproj) ???? restore ???? ????
COPY ["services/Doctorand/DoctorandDepartmant.api/DoctorandDepartmant.api.csproj", "services/Doctorand/DoctorandDepartmant.api/"]
COPY ["services/Doctorand/doctor.application/doctor.application.csproj", "services/Doctorand/doctor.application/"]
COPY ["services/Doctorand/doctor.core/doctor.core.csproj", "services/Doctorand/doctor.core/"]
COPY ["services/Doctorand/doctor.infrastructure/doctor.infrastructure.csproj", "services/Doctorand/doctor.infrastructure/"]

# 2?? Restore dependencies ???
RUN dotnet restore "services/Doctorand/DoctorandDepartmant.api/DoctorandDepartmant.api.csproj"

# 3?? ??? ???? ????? ???????
COPY . .

# 4?? ????? ?????? ?????? ???????
WORKDIR /src/services/Doctorand/DoctorandDepartmant.api

# 5?? Build ???????
RUN dotnet build "DoctorandDepartmant.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage 2: Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DoctorandDepartmant.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 3: Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoctorandDepartmant.api.dll"]