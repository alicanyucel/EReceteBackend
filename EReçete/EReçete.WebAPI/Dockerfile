FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EReçete.WebAPI/EReçete.WebAPI.csproj", "EReçete.WebAPI/"]
COPY ["EReçete.Application/EReçete.Application.csproj", "EReçete.Application/"]
COPY ["EReçete.Domain/EReçete.Domain.csproj", "EReçete.Domain/"]
COPY ["EReçete.Infrastructure/EReçete.Infrastructure.csproj", "EReçete.Infrastructure/"]
RUN dotnet restore "./EReçete.WebAPI/EReçete.WebAPI.csproj"
COPY . .
WORKDIR "/src/EReçete.WebAPI"
RUN dotnet build "./EReçete.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EReçete.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EReçete.WebAPI.dll"]
