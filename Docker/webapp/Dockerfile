# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY Client/. ./Client/
COPY Server/. ./Server/
COPY Shared/. ./Shared/
RUN dotnet restore ./Server/HogeBlazor.Server.csproj

# copy everything else and build app
WORKDIR /source/Server
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "HogeBlazor.Server.dll"]
