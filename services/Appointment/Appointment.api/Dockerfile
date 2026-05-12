# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj files
COPY ["services/Appointment/Appointment.api/Appointment.api.csproj", "services/Appointment/Appointment.api/"]
COPY ["services/Appointment/Appointment.Application/Appointment.Application.csproj", "services/Appointment/Appointment.Application/"]
COPY ["services/Appointment/Appointment.Core/Appointment.Core.csproj", "services/Appointment/Appointment.Core/"]

# ✔ التصحيح هنا
COPY ["services/Appointment/Appointment.Infrastrucure/Appointment.Infrastrucure.csproj", "services/Appointment/Appointment.Infrastrucure/"]

# ✔ EventMassage
COPY ["Infrastructure/EventMassage/EventMassage.csproj", "Infrastructure/EventMassage/"]
COPY ["Infrastructure/logging/logging.csproj", "Infrastructure/logging/"]

# ✔ مهم جدًا
RUN dotnet restore "services/Appointment/Appointment.api/Appointment.api.csproj"
# Restore


# Copy everything
COPY . .

WORKDIR /src/services/Appointment/Appointment.api

RUN dotnet build Appointment.api.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Appointment.api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Appointment.api.dll"]