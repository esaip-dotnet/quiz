# API .NET Core

L'API Core .NET du Quiz

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


## Format
Tous les retours sont au format JSON.

Le format de retour d'un *Quiz* est le suivant :

```json
docker run -p 80:80 -d --name api-core.net api-core.net
```

License
----

MIT


   [Docker]: <https://www.docker.com/>
   [site officiel]: <https://docs.docker.com/engine/installation/linux/>
