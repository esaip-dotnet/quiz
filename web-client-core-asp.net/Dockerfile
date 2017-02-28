FROM esaipnet/api-core.net-base:1.0

ENV API_URL_PORT localhost:80

ADD /src /app
WORKDIR /app/WebClientCore
RUN ["dotnet", "restore"]
EXPOSE 5004
ENTRYPOINT ["dotnet", "run"]
