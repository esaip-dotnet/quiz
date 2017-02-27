FROM esaipnet/api-core.net-base:1.0

ENV MONGO_URL_PORT db-mongo:27017
ENV MONGO_DATABASE quiz

ADD /src /app
WORKDIR /app/api-core.net
RUN ["dotnet", "restore"]
EXPOSE 5004
ENTRYPOINT ["dotnet", "run"]
