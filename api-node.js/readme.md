# api-node.js
This is the Node API version of the voting application

## Contract
The API exposes four operations under the localhost/api/quiz url, those are:

- **/quiz (GET) : returns all quiz;
- **/quiz/{id} (GET) : returns a specified quiz by the invoqued id ;
- **/quiz/json (POST) : creates a new quiz.
- **/quiz/{id}/quiz (PATCH) :modify a quiz.

## Content
The JSON basic form is the following :
>				  summary: "Le quiz qui teste votre culture internationale",
>                description: "Ce quiz ...",
>                title: "Le grand quiz des pays",
>                questions: [
>                    { 
>                        title:"Quel est ce drapeaux ?"
>                    }
>                    
>                ],
>                answers: [
>                    {
>                        title:"France",
>                        correct:true
>                    },
>                    {
>                        title:"Espagne",
>                        correct:false
>                    },
>                    {
>                        title:"Allemagne",
>                        correct:false
>                    },
>                    {
>                        title:"Italie",
>                        correct:false
>                    }
>                ]

# Launch the node "serveur.js"
Firstly, mongodb server (mongod.exe) needs to be running.
You need to set the following environment variables. 
==> SERVERNAME 
==> PORTMONGODB
==> BDD (the mongodb base name)


Done By Allan SIRDEY, student of ESAIP school