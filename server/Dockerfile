FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Rommanel.Api/Rommanel.Api.csproj", "Rommanel.Api/"]
COPY ["Rommanel.Domain/Rommanel.Domain.csproj", "Rommanel.Domain/"]
COPY ["Rommanel.Infra/Rommanel.Infra.csproj", "Rommanel.Infra/"]
COPY ["Rommanel.Service/Rommanel.Service.csproj", "Rommanel.Service/"]
RUN dotnet restore "Rommanel.Api/Rommanel.Api.csproj"
COPY . .
WORKDIR "/src/Rommanel.Api"
RUN dotnet build "Rommanel.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Rommanel.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rommanel.Api.dll"]