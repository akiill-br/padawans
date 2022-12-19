#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["api/api.gateway.resource/api.gateway.resource.csproj", "api/api.gateway.resource/"]
RUN dotnet restore "api/api.gateway.resource/api.gateway.resource.csproj"
COPY . .
WORKDIR "/src/api/api.gateway.resource"
RUN dotnet build "api.gateway.resource.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api.gateway.resource.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.gateway.resource.dll"]