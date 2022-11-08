#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Hospitality.Web/Hospitality.Web.csproj", "src/Hospitality.Web/"]
COPY ["src/Hospitality.Common/Hospitality.Common.csproj", "src/Hospitality.Common/"]
COPY ["src/Hospitality.Identity.Data/Hospitality.Identity.Data.csproj", "src/Hospitality.Identity.Data/"]
RUN dotnet restore "src/Hospitality.Web/Hospitality.Web.csproj"
COPY . .
WORKDIR "/src/src/Hospitality.Web"
RUN dotnet build "Hospitality.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hospitality.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hospitality.Web.dll"]