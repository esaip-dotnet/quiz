var http = require('http');
var express = require("express");
var app = express();
var bodyParser = require('body-parser');
var jsonPatch = require('fast-json-patch');

var listener = 8080;

var server = http.createServer(app);
server.listen(listener);

var path = require("path");

/********** LE SERVEUR **********/

app.use(express.static(__dirname + '/'));

app.use(bodyParser.json()); // parse application/json
app.use(bodyParser.urlencoded({
    extended: true
}));

/* MONGODB */

var mongodb = require('mongodb');

//We need to work with "MongoClient" interface in order to connect to a mongodb server.
var MongoClient = mongodb.MongoClient;

serverName = "localhost";
portListener = "27017";
bdd = "quiz";
  
var serverName = process.env.SERVERNAME || serverName;
var portListener = process.env.PORTMONGODB || portListener;
var bdd = process.env.BDDNAME || bdd;

    
//console.log(process.env.SERVERNAME)


/*var serverName ="localhost";
var portListener = "27017";
var bdd = "quiz";*/

var url = 'mongodb://'+serverName+':'+portListener+'/'+bdd;
//var url = 'mongodb://localhost:27017/quiz';

MongoClient.connect(url, function (err, db) {
    if (err) {
        console.log('Unable to connect to the mongoDB server. Error:', err);
    } else {
        //HURRAY!! We are connected. :)
        console.log('Connection established to', url);
        
        // Get the documents collection
        var resultat = db.collection('quiz');

        //Notre tableau de quiz
        var allQuiz = new Array();

        //On recupère les quiz en bdd et on les ajoute a notre tableau.
        resultat.find({}).toArray(function (error, results) {
            if (error) throw error;

            results.forEach(function(i, obj) {
                allQuiz.push(i);
            });
        });

        // Pour creer un nouveau formulaire
        app.post('/json', function (request, response) {
            
            // On cree un nouveau quiz (test)
            var newQuiz = {
                summary: request.body.summary,
                description: request.body.description,
                title: request.body.title,
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
            
            // On ajoute le nouveau quiz dans la BDD
            resultat.insert(newQuiz, function (err, result) {
                if (err) {
                    console.log(err);
                } else {
                    console.log('Success !');
                    
                    newQuiz._id = result.insertedIds.toString();
                    
                    // On ajoute le nouveau quiz dans notre tableau
                    allQuiz.push(newQuiz);
                }
                //Close connection
                //db.close();
            });
            
            response.redirect('/');
                        
            //console.log(request.body.name); // your JSON
            //response.send(request.body); // echo the result back
        });

        // Page d'accueil
        app.get('/', function(req, res) {
            res.status(200);
            res.send("Ca marche sur ma machine !");
        });

        // Pour récupérer tout les quiz
        app.get('/quiz', function(req, res) {
            var myJson = JSON.stringify(allQuiz); // Convertir Array en objet JSON
            res.contentType('application/json');
            res.status(200);
            res.json(myJson);
        });

        // Pour récupérer un quiz précis
        app.get('/quiz/:id', function(req, res) {
            var MongoObjectID = require("mongodb").ObjectID;          // Il nous faut ObjectID
            var idToFind      = req.params.id;                        // Identifiant dans l'URL
            var objToFind     = { _id: new MongoObjectID(idToFind) };
            db.collection("quiz").findOne(objToFind, function(error, result) {
                if (error) throw error;

                console.log(
                    "ID Quiz: "  + result._id.toString() + "\n" // 53dfe7bbfd06f94c156ee96e
                );   
                res.contentType('application/json');
                res.status(200);
                res.json(result);
            });
        });
        
        app.put('/quiz/:id', function(req, res) {
            
            var MongoObjectID = require("mongodb").ObjectID;          // Il nous faut ObjectID
            var idToFind      = req.params.id;                        // Identifiant dans l'URL
            var objToFind     = { _id: new MongoObjectID(idToFind) };
            db.collection("quiz").findOne(objToFind, function(error, result) {
                // A Faire
            });
            
        });
        
        
        // Pour modifier le summary d'un quiz
        app.patch('/quiz/:id', function (req, res){
            var MongoObjectID = require("mongodb").ObjectID;          // Il nous faut ObjectID
            var idToFind      = req.params.id;                        // Identifiant dans l'URL
            var newSummary      = req.params.newSummary;
            var objToFind     = { _id: new MongoObjectID(idToFind) };
            db.collection("quiz").findOneAndUpdate(
                objToFind, 
                { $set: {summary:"gf"} }, // A améliorer (valeur en dur)
                function(error, result) {
                
                    res.send(result);
                
            });              
        });


    }
});