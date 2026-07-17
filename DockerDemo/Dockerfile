# Runtime Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

EXPOSE 8080


# Build Image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy only csproj first
COPY DockerDemo.csproj .

# Restore packages
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Publish the application
RUN dotnet publish -c Release -o /app/publish


# Final Image
FROM base AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "DockerDemo.dll"]
