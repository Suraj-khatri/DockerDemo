# Runtime Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

EXPOSE 8080


# Build Image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy project file
COPY DockerDemo.csproj .

# Restore packages
RUN dotnet restore

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Copy source code
COPY . .

# Publish application
RUN dotnet publish -c Release -o /app/publish


# Final Image
FROM base AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "DockerDemo.dll"]
