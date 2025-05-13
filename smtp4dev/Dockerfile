#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM rnwood/smtp4dev:3.8.6 AS base
# FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS app-base
WORKDIR /app
# COPY ["nuget.config", "."]
# COPY ["AllMighLibrary.Grpc/AllMighLibrary.Grpc.csproj", "AllMighLibrary.Grpc/"]
# RUN dotnet restore "AllMighLibrary.Grpc/AllMighLibrary.Grpc.csproj"
# COPY . .
# WORKDIR "/src/AllMighLibrary.Grpc"
# RUN dotnet build "AllMighLibrary.Grpc.csproj" -c Release -o /app/build

FROM app-base AS publish
# RUN dotnet publish "AllMighLibrary.Grpc.csproj" -c Release -o /app/publish /p:UseAppHost=false
# RUN dotnet publish "AllMighLibrary.Grpc.csproj" -c Release -o /app/publish /p:UseAppHost=false
COPY --from=base /app .

FROM app-base AS final
WORKDIR /app
COPY --from=publish /app .

RUN apt-get update && apt-get install -y \
    nodejs \
    npm 

ENTRYPOINT ["dotnet", "/app/Rnwood.Smtp4dev.dll"]
