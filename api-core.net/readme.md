# WebClient API .NET Core

L'API Core .NET du Quiz

## Introduction

Cette partie du projet "Quiz", permet depuis une interface web :
  - L'ajout d'un quiz.
  - L'ajout d'une question à ce quiz.
  
## Installation

Pour pouvoir implémenter le webclient sur Azure, il faut éxecuter le WebClientCore.sln, cela ouvrira Microsoft Visual Studio.
Ensuite dans la zone de droite "Explorateur de solution", il faut faire un clique droit sur "src > WebClientCore", puis "Publier".

## Contrat
| MÉTHODE | ROUTE | ACTION |
|---|---|---|
| GET | /quiz | Retourne tous les quiz (titre + résumé + description + URL)  de la base. |
| GET | /quiz/*{idQuiz}* | Retourne le quiz *{idQuiz}*.|
| GET | /quiz/*{idQuiz}*/participation/*{idParticipant}* | Retourne la participation *{idParticipant}* du quiz *{idQuiz}*. |
|   |   |   |
| POST | /quiz | Crée un nouveau quiz. |
| POST | /quiz/*{idQuiz}*/participation | Crée une nouvelle participation au quiz *{idQuiz}*. |
|   |   |   |
| PUT | /quiz/*{idQuiz}*/participation/*{idParticipant}* | Édite la participation *{idParticipant}* du quiz *{idQuiz}*. |
|   |   |   |
| PATCH | /quiz/*{idQuiz}* | Édite le quiz *{idQuiz}*. |
| PATCH | /quiz/*{idQuiz}*/participation/*{idParticipant}* | Édite la participation *{idParticipant}* du quiz *{idQuiz}*. |

## Fonctionnalités
* Contient un fichier swagger.json pour la description de l'API
* Supporte CORS pour essayer l'API ("Try it out") depuis http://app.swaggerhub.com
* Implémente Swagger-UI pour une description de l'API en local (http://localhost/swagger)

## Format

Tous les retours sont au format JSON.

Le format de retour d'un *Quiz* est le suivant :

```json
docker run -p 80:80 -d --name api-core.net api-core.net
```

## Améliorations
Différentes améliorations sont à apporter :
  - Créer un menu permettant de choisir entre : création d'un quiz et participer.
  - Interface de jeu
  - L'ajout de plusieurs questions à un quiz, ainsi que plusieurs réponses à une question.
  
License
----

MIT


   [Docker]: <https://www.docker.com/>
   [site officiel]: <https://docs.docker.com/engine/installation/linux/>
