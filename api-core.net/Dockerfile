FROM esaipnet/api-core.net-base

ENV MONGO_URL_PORT localhost:27017
ENV MONGO_DATABASE quiz

ADD /src /app
WORKDIR /app/api-core.net
RUN ["dotnet", "restore"]
EXPOSE 80
ENTRYPOINT ["dotnet", "run"]