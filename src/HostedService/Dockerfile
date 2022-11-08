#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HostedService/HostedService.csproj", "HostedService/"]
COPY ["src/Hospitality.Common/Hospitality.Common.csproj", "src/Hospitality.Common/"]
RUN dotnet restore "HostedService/HostedService.csproj"
COPY . .
WORKDIR "/src/HostedService"
RUN dotnet build "HostedService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HostedService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HostedService.dll"]