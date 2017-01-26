var http = require('http');
var express = require("express");
var app = express();
var bodyParser = require('body-parser');

var server = http.createServer(app);
var io = require("socket.io").listen(server);
server.listen(8080);

var path = require("path");

/********** LE SERVEUR **********/

app.use(express.static(__dirname + '/'));

app.get('/', function (req, res) {
    res.sendFile(path.join(__dirname + '/index.html'));
});

app.use(bodyParser.json()); // parse application/json
app.use(bodyParser.urlencoded({
    extended: true
}));




/* MONGODB */

var mongodb = require('mongodb');

//We need to work with "MongoClient" interface in order to connect to a mongodb server.
var MongoClient = mongodb.MongoClient;

// Connection URL. This is where your mongodb server is running.
var url = 'mongodb://localhost:27017/quiz';

MongoClient.connect(url, function (err, db) {
    if (err) {
        console.log('Unable to connect to the mongoDB server. Error:', err);
    } else {
        //HURRAY!! We are connected. :)
        console.log('Connection established to', url);



        app.post('/json', function (request, response) {

            // Get the documents collection
            var resultat = db.collection('quiz');

            var quiz = {
                nomQuiz: request.body.nom,
                nbQuestion: request.body.nbQuestion
            }

            resultat.insert(quiz, function (err, result) {
                if (err) {
                    console.log(err);
                } else {
                    console.log('Inserted %d documents into the "quiz" collection. The documents inserted with "_id" are:', result.length, result);
                }
                //Close connection
                //db.close();
            });
            
            resultat.find({}).toArray(function (err, docs) {
                console.log("Found the following records");
                console.log(docs);
            });

            //console.log(request.body.name); // your JSON
            //response.send(request.body); // echo the result back
        });

        


    }
});


// ON RECOIS UN OBJET JSON VIA UN POST
// ON LE RECUPERE ICI ET ON L ECRIS DANS LA BDD MONGODB