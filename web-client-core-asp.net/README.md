# WebClient core asp.net

## Introduction
Le WebClient permet aux utilisateurs de ce projet, de créer un quiz.
L'utilisateur peut ajouter au quiz des questions constituées de 4 réponses.
  
## Utilisation
L'application est constituée de 2 fenêtres, une pour créer le quiz et une pour ajouter des questions à celui-ci.

La première fenêtre est un formulaire simple, il faut juste remplir les informations nécessaire:
![creation_quiz](https://github.com/TonyJallais/quiz/tree/master/web-client-core-asp.net/img/home.png "Création du quiz")

Pour la seconde, il faut aussi remplir les informations de la question, puis remplir chaques réponses.
Une fois cela fait, l'utilisateur à plusieurs choix, soit ajouter une nouvelle question au quiz, 
soit stopper l'ajout de question :
![ajout_question](https://github.com/TonyJallais/quiz/tree/master/web-client-core-asp.net/img/question.png "Ajout de question")

## Dockerfile
Le DockerFile permet l'exécution de l'application dans un conteneur.
Il est constitué de 2 variables d'environnement :
  - API_URL_PORT : url de l'api ainsi que son port, ici api-net étant le conteneur de l'api.
  - DB_NAME : nom de la collection.
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
L'application WebClient s'exécute en même temps que les API. Pour cela, il faut exécuter le docker-compose qui est
situé à la racine du projet "Quiz". Il faut utiliser la commande "docker-compose up".
Voilà l'application est maintenant accessible par l'url http://votre-addresse:80/