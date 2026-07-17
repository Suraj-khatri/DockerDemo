FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["DockerDemo/DockerDemo.csproj", "DockerDemo/"]

RUN dotnet restore "DockerDemo/DockerDemo.csproj"

COPY . .

WORKDIR "/src/DockerDemo"

RUN dotnet publish "DockerDemo.csproj" \
-c Release \
-o /app/publish


FROM base AS final

WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet","DockerDemo.dll"]
