FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY Client/. ./Client/
COPY Server/. ./Server/
COPY Shared/. ./Shared/
RUN dotnet build ./Server/HogeBlazor.Server.csproj

WORKDIR /source/Server
RUN dotnet publish -c release
