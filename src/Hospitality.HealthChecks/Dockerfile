#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Hospitality.HealthChecks/Hospitality.HealthChecks.csproj", "src/Hospitality.HealthChecks/"]
RUN dotnet restore "src/Hospitality.HealthChecks/Hospitality.HealthChecks.csproj"
COPY . .
WORKDIR "/src/src/Hospitality.HealthChecks"
RUN dotnet build "Hospitality.HealthChecks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hospitality.HealthChecks.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hospitality.HealthChecks.dll"]