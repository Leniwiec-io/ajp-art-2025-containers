#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DockerLoadBalancing.UI.Blazor/DockerLoadBalancing.UI.Blazor.csproj", "DockerLoadBalancing.UI.Blazor/"]
COPY ["DockerLoadBalancing.Application/DockerLoadBalancing.Application.csproj", "DockerLoadBalancing.Application/"]
COPY ["DockerLoadBalancing.Domain/DockerLoadBalancing.Domain.csproj", "DockerLoadBalancing.Domain/"]
COPY ["DockerLoadBalancing.Infrastructure/DockerLoadBalancing.Infrastructure.csproj", "DockerLoadBalancing.Infrastructure/"]
RUN dotnet restore "./DockerLoadBalancing.UI.Blazor/./DockerLoadBalancing.UI.Blazor.csproj"
COPY . .
WORKDIR "/src/DockerLoadBalancing.UI.Blazor"
RUN dotnet build "./DockerLoadBalancing.UI.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DockerLoadBalancing.UI.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerLoadBalancing.UI.Blazor.dll"]