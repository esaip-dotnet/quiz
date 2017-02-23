# api-node.js

NodeJS est une plateforme construite sur le moteur JavaScript V8 de Chrome qui permet de développer des applications en utilisant du JavaScript.

Il est souvent utiliser pour créer un serveur http.

## Installation en locale

Télécharger la dernière version de Node.js sur le site: https://nodejs.org/en/download/

Exemple: version Windows Installer (.msi) 64-bit: node-v6.10.0-x64.msi

Puis lancer l'installation.

### Tester Node.js 

Pour tester Node.js, créer simplement un fichier test.js et écrire dedans:

> console.log('Hello Node.js');

Ensuite, avec le programme "Node.js command prompt", lancer la commande

> node test.js

### Créer un simple serveur web (http) 

#### Prérequis

Il faut installer le package "express" qui fournit des outils de base pour aller plus vite dans la création d'application Node.js.

> npm install express

#### Créer le serveur 

Créer un fichier "serveur.js"

>   var http = require('http');
>   var express = require("express");
>   var app = express();

>   var server = http.createServer(app);
>   var listener = 8080;
>   server.listen(listener);

>   app.get('/', function(req, res) {
>       res.status(200);
>       res.send("Ca marche sur ma machine !");
>   });

####

Pour tester le serveur, il suffit d'entrer dans un navigateur:

> http://localhost:8080

Le message "Ca marche sur ma machine !" s'affiche sur la page.

## Installer sur Docker


