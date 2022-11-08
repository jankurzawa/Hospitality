#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Hospitality.Examination.API/Hospitality.Examination.API.csproj", "src/Hospitality.Examination.API/"]
COPY ["src/Hospitality.Common/Hospitality.Common.csproj", "src/Hospitality.Common/"]
COPY ["src/Hospitality.Examination.Domain/Hospitality.Examination.Domain.csproj", "src/Hospitality.Examination.Domain/"]
COPY ["src/Hospitality.Examination.Persistance/Hospitality.Examination.Persistance.csproj", "src/Hospitality.Examination.Persistance/"]
COPY ["src/Hospitality.Examination.Application/Hospitality.Examination.Application.csproj", "src/Hospitality.Examination.Application/"]
RUN dotnet restore "src/Hospitality.Examination.API/Hospitality.Examination.API.csproj"
COPY . .
WORKDIR "/src/src/Hospitality.Examination.API"
RUN dotnet build "Hospitality.Examination.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hospitality.Examination.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hospitality.Examination.API.dll"]