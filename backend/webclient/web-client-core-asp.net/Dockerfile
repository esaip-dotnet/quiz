FROM esaipnet/api-core.net-base:1.0




ADD /src /app
WORKDIR /app/WebClientCore
RUN ["dotnet", "restore"]
EXPOSE 5004
ENTRYPOINT ["dotnet", "run"]
