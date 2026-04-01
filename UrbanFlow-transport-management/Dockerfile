FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UrbanFlow-transport-management/UrbanFlow-transport-management.csproj", "UrbanFlow-transport-management/"]
RUN dotnet restore "UrbanFlow-transport-management/UrbanFlow-transport-management.csproj"
COPY . .
WORKDIR "/src/UrbanFlow-transport-management"
RUN dotnet build "./UrbanFlow-transport-management.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UrbanFlow-transport-management.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UrbanFlow-transport-management.dll"]
