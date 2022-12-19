#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["api/api.resource/api.resource.csproj", "api/api.resource/"]
COPY ["infra/infra.ioc.resource/infra.ioc.resource.csproj", "infra/infra.ioc.resource/"]
COPY ["app/app.resource/app.resource.csproj", "app/app.resource/"]
COPY ["domain/domain.resource/domain.resource.csproj", "domain/domain.resource/"]
COPY ["data/data.resource/data.resource.csproj", "data/data.resource/"]
RUN dotnet restore "api/api.resource/api.resource.csproj"
COPY . .
WORKDIR "/src/api/api.resource"
RUN dotnet build "api.resource.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api.resource.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.resource.dll"]