FROM core.net-base
ADD /src /app
WORKDIR /app
RUN ["dotnet", "restore"]
EXPOSE 5004
ENTRYPOINT ["dotnet", "run"]