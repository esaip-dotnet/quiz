# Docker Compose

Avec un simple fichier "docker-compose.yml", on peut décrire une application composé de plusieurs conteneurs Docker.

Pour lancer l'application, une seule commande suffit:

> docker-compose up

## Pré-requis

Il faut dans un premier temps écrire les fichiers "DockerFile" pour chacun des conteneurs Docker de l'application.

## Le fichier "docker-compose.yml"

Ce fichier défini les services de notre application.

Dans notre cas, nous avons plusieur servir:
- client-net
- api-net
- api-node
- db-mongo

Exemple:

> version: '2'
> services:
>     client-net:
>         build: web-client-core-asp.net
>         ports:
>         - "80:80"
>         image: "esaipnet/web-client-core-asp:1.0"
>     api-net:
>         build: api-core.net
>         ports:
>         - "81:80"
>         image: "esaipnet/api-core.net:1.0"
>     api-node:
>         build: api-node.js
>         ports:
>         - "82:80"
>         image: "esaipnet/api-node.js:1.0"
>     db-mongo:
>         image: "mongo:3.0.3"
>         ports:
>         - "27017:27017"

La ligne 

> ports: - "82:80" 

permet de rediriger le port 82 du conteneur Docker vers le port 80 de la machine hôte (HOST:CONTAINER).

Ainsi, lorsque l'utilisateur lancera une requete http tel que "http://0.0.0.0:82" sur le port, c'est l'api-node.js qui sera utiliser pour répondre.

![Docker-compose](http://blog.inovia-conseil.fr/wp-content/uploads/2015/03/archi-poste-dev.png "Docker-compose")

## Sources

- https://www.docker.com/products/docker-compose#/get-started
- http://blog.ippon.fr/2015/03/26/orchestration-de-containers-docker-docker-compose-et-crane/
- https://docs.microsoft.com/fr-fr/azure/virtual-machines/virtual-machines-linux-docker-compose-quickstart
