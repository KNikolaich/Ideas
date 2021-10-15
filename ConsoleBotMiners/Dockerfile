#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ConsoleBotMiners/ConsoleBotMiners.csproj", "ConsoleBotMiners/"]
COPY ["BotCore/BotCore.csproj", "BotCore/"]
COPY ["PoolsSelector/PoolsSelector.csproj", "PoolsSelector/"]

COPY . .
WORKDIR "/src/ConsoleBotMiners"
RUN dotnet build "ConsoleBotMiners/ConsoleBotMiners.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleBotMiners/ConsoleBotMiners.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleBotMiners.dll"]