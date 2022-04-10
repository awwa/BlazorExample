# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

RUN dotnet tool install -g Microsoft.dotnet-openapi

# copy csproj and restore as distinct layers
COPY Client/. ./Client/
COPY Client.Test/. ./Client.Test/
COPY Server/. ./Server/
COPY Server.Test/. ./Server.Test/
COPY Shared/. ./Shared/
COPY Shared.Test/. ./Shared.Test/
COPY HogeFunction/. ./HogeFunction/
COPY OpenApi/. ./OpenApi/
COPY HogeBlazor.sln ./
# RUN dotnet restore ./Server/HogeBlazor.Server.csproj
RUN dotnet build ./Server/HogeBlazor.Server.csproj

# build API Client
# RUN curl -fsSL https://deb.nodesource.com/setup_17.x | -E bash -
# RUN apt-get install -y nodejs
RUN apt update
RUN apt install npm -y
RUN npm install nswag -g
RUN nswag run ./OpenApi/nswag.json

# copy everything else and build app
WORKDIR /source/Server
COPY Server/Settings/appsettings.Release.json /source/Server/appsettings.json
RUN dotnet publish -c Release -o /app --no-restore
# COPY Server/Settings/appsettings.Release.json /app/appsettings.json

# final stage/image
# FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
# COPY --from=build /app ./
# COPY --from=build /usr/local/bin/dockerize /usr/local/bin/
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install --global dotnet-ef
ENTRYPOINT ["dotnet", "HogeBlazor.Server.dll"]
