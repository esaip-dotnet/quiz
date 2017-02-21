FROM esaipnet/api-core.net-base:1.0




ADD /src /app
WORKDIR /app/web-client-core-asp.net
RUN ["dotnet", "restore"]
EXPOSE 80
ENTRYPOINT ["dotnet", "run"]
