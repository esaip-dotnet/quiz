FROM esaipnet/api-core.net-base:1.0




ADD /src /app
WORKDIR /app/WebClientCore
RUN ["dotnet", "restore"]
EXPOSE 80
ENTRYPOINT ["dotnet", "run"]
