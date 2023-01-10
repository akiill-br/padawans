#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["api/api.oauth.github.resource/api.oauth.github.resource.csproj", "api/api.oauth.github.resource/"]
RUN dotnet restore "api/api.oauth.github.resource/api.oauth.github.resource.csproj"
COPY . .
WORKDIR "/src/api/api.oauth.github.resource"
RUN dotnet build "api.oauth.github.resource.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api.oauth.github.resource.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.oauth.github.resource.dll"]