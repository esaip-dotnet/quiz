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

### Prérequis

Avoir une installation Docker fonctionnel.

### Le fichier package.json

Créer un fichier "package.json". Ce fichier décrit votre application et ces dépendances.

Exemple:

>{
>  "name": "quiz",
>  "version": "0.0.1",
>  "description": " Application quiz",
>  "main": "serveur.js",
>  "author": "",
>  "license": "MIT",
>  "repository": {
>    "type": "git"
>  },
>  "dependencies": {
>    "express": "^4.14.1"
>  }
>}

### Le fichier serveur.js

Ensuite il faut créer le fichier "serveur.js" comme vu précédemment.

### Le fichier "Dockerfile"

> FROM esaipnet/api-node.js-base:1.0

> ADD package.json /tmp/package.json
> RUN cd /tmp && npm install
> RUN mkdir -p /opt/app && cp -a /tmp/node_modules /opt/app/

> WORKDIR /opt/app
> ADD . /opt/app

> EXPOSE 8080
> CMD ["node", "serveur.js"]

#### Explications

> FROM esaipnet/api-node.js-base:1.0

La commande FROM permet de définir depuis quel image Docker on veut build l'application.

> ADD package.json /tmp/package.json
> RUN cd /tmp && npm install
> RUN mkdir -p /opt/app && cp -a /tmp/node_modules /opt/app/

Ce code permet d'ajouter les dépendances (qui sont dans package.json) 
sans pour autant les réinstaller à chaque fois que l'on rebuild le container Docker.

Les modules sont mis en cache et ne sont pas rebuild dès qu'on change le code source de notre appli.

> WORKDIR /opt/app
> ADD . /opt/app

L'instruction WORKDIR permet de dire ou se trouve l'application.

> EXPOSE 8080

C'est le port sur lequel notre application (serveur http) est à l'écoute.

> CMD ["node", "serveur.js"]

Pour lancer l'application Node.js.

### Build l'image Docker

Il faut se placer dans le repertoire contenant le fichier "DockerFile" et lancer la commande:

> $ docker build -t \<your username>/node-web-app .

### Lancer l'image Docker

> $ docker run -p 49160:8080 -d \<your username>/node-web-app

Le flag -p indique de rédiriger le port public 49162 vers le port privé 8080 dans le container.

### Tester

Aller dans un navigateur et entrer l'url:

> localhost:49160

### Source

- https://nodejs.org/en/docs/guides/nodejs-docker-webapp/
- http://bitjudo.com/blog/2014/03/13/building-efficient-dockerfiles-node-dot-js/


