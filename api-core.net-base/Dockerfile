FROM microsoft/aspnetcore-build:1.0.1
ADD /src /app
WORKDIR /app
RUN ["dotnet", "restore"]
EXPOSE 5004
ENTRYPOINT ["dotnet", "run"]