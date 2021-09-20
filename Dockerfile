FROM mcr.microsoft.com/dotnet/sdk:5.0 AS buildapi
COPY . /src
WORKDIR /src
ENV DOTNET_EnableDiagnostics=0
RUN dotnet restore && dotnet build -c Release -o build --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
LABEL org.opencontainers.image.source https://github.com/mrdavidkovacs/AnniversariesApi
COPY --from=buildapi /src/build /App
WORKDIR /App
ENV DOTNET_EnableDiagnostics=0
EXPOSE 80
#ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "Anniversaries.Api.dll"]