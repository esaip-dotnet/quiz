api-node.js
===============

This is the Node API version of the quiz application

---------------------------------------------------------

Explanation
===============

At the moment the API exposes four operations under the localhost/quiz url : 

* /quiz (GET) : returns all quiz;
* /quiz/{id} (GET): returns a specified quiz thanks to the id;
* /quiz/{id} (PUT): edits a quiz and create the quiz if it doesn't exist
* /json (POST): creates a quiz form

---------------------------------------------------------
Content
===============

Here is an example of the contents of the quiz object:


{
                summary: "Drapeau",
                description: "Quiz sur les drapeau",
                title: "Drapeau",
                questions: [
                    { 
                        title:"Quel est ce drapeaux ?"
                    }
                    
                ],
                answers: [
                    {
                        title:"France",
                        correct:true
                    },
                    {
                        title:"Espagne",
                        correct:false
                    },
                    {
                        title:"Allemagne",
                        correct:false
                    },
                    {
                        title:"Italie",
                        correct:false
                    }
                ]
}

-----------------------------------------------------------