FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

#COPY *.sln .
#COPY WebApi/WebApi.csproj ./WebApi/
# COPY CommonLib/CommonLib.csproj ./CommonLib/
# RUN dotnet restore ./WebApi/WebApi.csproj
# RUN dotnet restore ./CommonLib/CommonLib.csproj

# copy everything else and build app
COPY WebApi/. ./WebApi/
RUN dotnet restore ./WebApi/WebApi.csproj
COPY CommonLib/. ./CommonLib/
RUN dotnet restore ./CommonLib/CommonLib.csproj

WORKDIR /source/WebApi
RUN dotnet publish -c release -o /app --no-restore

#COPY . /hoge