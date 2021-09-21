#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS buildapi
FROM ubuntu:20.04 AS buildapi
ENV NET_VERSION=5.0
ENV NODE_VERSION=14.17.6
ENV NVM_DIR=/root/.nvm
ENV DEBIAN_FRONTEND=noninteractive
ENV DOTNET_EnableDiagnostics=0
#RUN type apt-get
RUN apt-get update && apt-get install -y curl libatomic1 python build-essential apt-transport-https
RUN apt-get -yq install libicu-dev
RUN curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin -c ${NET_VERSION} --install-dir /local/install
RUN /local/install/dotnet --version
RUN mkdir -p $NVM_DIR && curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.38.0/install.sh | bash
RUN . "$NVM_DIR/nvm.sh" && nvm install ${NODE_VERSION}
RUN . "$NVM_DIR/nvm.sh" && nvm use v${NODE_VERSION}
RUN . "$NVM_DIR/nvm.sh" && nvm alias default v${NODE_VERSION}
ENV PATH="${NVM_DIR}/versions/node/v${NODE_VERSION}/bin/:${PATH}"
#RUN echo $PATH 
#RUN ls -lah ${NVM_DIR}/versions/node/v${NODE_VERSION}/bin
RUN node --version && npm --version
COPY . /src
WORKDIR /src
RUN (cd Anniversaries.Web && npm install && npm run build)
RUN /local/install/dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
LABEL org.opencontainers.image.source https://github.com/mrdavidkovacs/AnniversariesApi
COPY --from=buildapi /src/publish /App
WORKDIR /App
ENV DOTNET_EnableDiagnostics=0
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "Anniversaries.Api.dll"]