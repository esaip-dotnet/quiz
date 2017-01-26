FROM api-core.net-base
ADD /src /app
WORKDIR /app/api-core.net
RUN ["dotnet", "restore"]
EXPOSE 5004
ENTRYPOINT ["dotnet", "run"]