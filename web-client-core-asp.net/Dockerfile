FROM esaipnet/api-core.net-base:1.0

ENV API_URL_PORT api-net:81
ENV DB_NAME quiz

ADD /src /app
WORKDIR /app/WebClientCore
RUN ["dotnet", "restore"]
EXPOSE 80
ENTRYPOINT ["dotnet", "run"]
