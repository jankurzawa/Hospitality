#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Hospitality.CheckUp.API/Hospitality.CheckUp.API.csproj", "src/Hospitality.CheckUp.API/"]
COPY ["src/Hospitality.Common/Hospitality.Common.csproj", "src/Hospitality.Common/"]
RUN dotnet restore "src/Hospitality.CheckUp.API/Hospitality.CheckUp.API.csproj"
COPY . .
WORKDIR "/src/src/Hospitality.CheckUp.API"
RUN dotnet build "Hospitality.CheckUp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hospitality.CheckUp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hospitality.CheckUp.API.dll"]