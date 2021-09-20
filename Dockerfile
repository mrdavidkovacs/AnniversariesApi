# build stage
FROM node:14.17.6-alpine3.11 as buildfe
WORKDIR /App
COPY Anniversaries.Web/ .
#COPY Anniversaries.Web/package*.json .
RUN npm install
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS buildapi
COPY . /src
WORKDIR /src
COPY --from=buildfe /Anniversaries.Api/wwwroot /Anniversaries.Api/wwwroot
ENV DOTNET_EnableDiagnostics=0
RUN dotnet restore && dotnet build -c Release -o build --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
LABEL org.opencontainers.image.source https://github.com/mrdavidkovacs/AnniversariesApi
COPY --from=buildapi /src/build /App
WORKDIR /App
ENV DOTNET_EnableDiagnostics=0
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "Anniversaries.Api.dll"]