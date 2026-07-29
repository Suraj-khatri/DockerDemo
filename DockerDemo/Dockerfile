# ==========================
# Build Stage
# ==========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy project file
COPY DockerDemo.csproj ./

# Restore packages
RUN dotnet restore

# Copy remaining source
COPY . .

# Publish application
RUN dotnet publish -c Release -o /app/publish --no-restore


# ==========================
# Runtime Stage
# ==========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "DockerDemo.dll"]
