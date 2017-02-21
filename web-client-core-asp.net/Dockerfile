FROM esaipnet/api-core.net-base:1.0
ADD . /app
WORKDIR /app
RUN ["dotnet", "restore"]
EXPOSE 80
ENTRYPOINT ["dotnet", "run"]
