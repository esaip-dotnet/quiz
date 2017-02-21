var http = require('http');
var express = require("express");
var app = express();
var bodyParser = require('body-parser');
var jsonPatch = require('fast-json-patch');
/*
// Les dépendances utilisées pour la création du fichier Swagger
var argv = require('minimist')(process.argv.slice(2));
var swagger = require("swagger-node-express");
var bodyParser = require( 'body-parser' );

// Creation de la route menant à la documentation de l'API
var subpath = express();
app.use(bodyParser());
app.use("/swagger_doc", subpath);
swagger.setAppHandler(subpath);

app.use(express.static('dist'));

//On renseigne les informations de l'API

swagger.setApiInfo({
    title: "Node API for the quiz application",
    description: " At the moment the API exposes four operations under the localhost/quiz url: an operation which returns all quiz, which returns a specified quiz thanks to the id, which edits a quiz and creates the quiz if if doesn't exist, which creates a quiz form"

});
// Ceci est l'interface utilisateur pour accéder à la documentation de l'API
subpath.get('/', function (req, res) {
    res.sendfile(__dirname + '/dist/index.html');
});

// Configuration du swagger
wagger.configureSwaggerPaths('', 'api-docs', '');
var domain = 'localhost';
if(argv.domain !== undefined)
    domain = argv.domain;
else
    console.log('No --domain=xxx specified, taking default hostname "localhost".');
var applicationUrl = 'http://' + domain;
swagger.configure(applicationUrl, '1.0.0');

if (url && url.length > 1) {
    url = decodeURIComponent(url[1]);
} else {
    <del>url = "http://petstore.swagger.io/v2/swagger.json";</del>
    url = "/api-docs.json";
}
*/
var listener = 80;

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

//Mise en place du MongoClient pour se connecter au serveur
var MongoClient = mongodb.MongoClient;

var serverUrl = process.env.MONGO_URL_PORT;
var bdd = process.env.MONGO_DATABASE;

console.log(serverUrl);
console.log(bdd);

//test local
//var serverUrl = "13.95.14.230:27017";
//var bdd = "quiz";

var url = 'mongodb://'+serverUrl+'/'+bdd;
//var url = 'mongodb://localhost:27017/quiz';

//Test de la connection au serveur via le client 
MongoClient.connect(url, function (err, db) {
    if (err) {
        console.log('Unable to connect to the mongoDB server. Error:', err);
    } else {
        //HURRAY!! We are connected. :)
        console.log('Connection established to', url);
        
        // Get the documents collection
        var resultat = db.collection('Quiz');

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

        // Controller permettant d'accéder à notre page d'accueil
        app.get('/', function(req, res) {
            res.status(200);
            res.send("Ca marche sur ma machine !");
        });

        // Methode get permettant de récupérer tous les quiz 
        app.get('/quiz', function(req, res) {
            /*console.log(allQuiz);
            var myJson = JSON.stringify(allQuiz); // Convertir Array en objet JSON
            res.contentType('application/json');
            res.status(200);
            res.json(myJson);*/
            
            //On recupère les quiz en bdd et on les ajoute a notre tableau.
            resultat.find({}).toArray(function (error, results) {
                if (error) throw error;

                results.forEach(function(i, obj) {
                    console.log(i);
                    res.status(200);
                });
            });
        });

        // Methode permettant de récupérer un quiz précis grâce l'ID
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
        
        // Methode permettant de modifier un quiz
        app.put('/quiz/:id', function(req, res) {
            
            var MongoObjectID = require("mongodb").ObjectID;          // Il nous faut ObjectID
            var idToFind      = req.params.id;                        // Identifiant dans l'URL
            var objToFind     = { _id: new MongoObjectID(idToFind) };
            db.collection("quiz").findOne(objToFind, function(error, result) {
                // A Faire
            });
            
        });
        
        // La méthode patch va nous permettre de modifier l'attribut d'une ressource
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