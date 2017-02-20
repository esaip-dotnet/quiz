FROM esaipnet/api-core.net-base
ADD . /app
WORKDIR /app
RUN ["dotnet", "restore"]
EXPOSE 80
ENTRYPOINT ["dotnet", "run"]