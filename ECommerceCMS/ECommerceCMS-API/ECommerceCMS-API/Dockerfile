#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ECommerceCMS-API/ECommerceCMS-API.csproj", "ECommerceCMS-API/"]
RUN dotnet restore "ECommerceCMS-API/ECommerceCMS-API.csproj"
COPY . .
WORKDIR "/src/ECommerceCMS-API"
RUN dotnet build "ECommerceCMS-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerceCMS-API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerceCMS-API.dll"]