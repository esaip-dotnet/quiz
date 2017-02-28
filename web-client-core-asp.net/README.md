# WebClient core asp.net

## Introduction
Le WebClient permet aux utilisateurs de ce projet, de créer un quiz.
L'utilisateur peut ajouter au quiz des questions constituées de 4 réponses.
  
## Utilisation
L'application est constituée de 2 fenêtres, une pour créer le quiz et une pour ajouter des questions à celui-ci.

La première fenêtre est un formulaire simple, il faut juste remplir les informations nécessaire:
![alt text](https://github.com/TonyJallais/quiz/tree/master/web-client-core-asp.net/img/home.png "Création du quiz")

Une fois cela fait, l'utilisateur à plusieurs choix, soit ajouter une nouvelle question au quiz, 
soit stopper l'ajout de question :
![alt text](https://github.com/TonyJallais/quiz/tree/master/web-client-core-asp.net/img/question.png "Ajout de question")

## Dockerfile
Le DockerFile permet l'exécution de l'application dans un conteneur.
Il est constitué de 2 variables d'environnement :
```
FROM esaipnet/api-core.net-base:1.0

ENV API_URL_PORT api-net:81
ENV DB_NAME quiz

ADD /src /app
WORKDIR /app/WebClientCore
RUN ["dotnet", "restore"]
EXPOSE 80
ENTRYPOINT ["dotnet", "run"]
```
  
## Installation
