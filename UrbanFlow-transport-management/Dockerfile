FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 4009


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UrbanFlow-transport-management.csproj", "./"]
RUN dotnet restore "UrbanFlow-transport-management.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "./UrbanFlow-transport-management.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UrbanFlow-transport-management.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:4009
ENTRYPOINT ["dotnet", "UrbanFlow-transport-management.dll"]
