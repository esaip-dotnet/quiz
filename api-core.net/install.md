# API .NET Core

## Prérequis
Pour installer l'API .Net Core, le seul prérequis est : 
  - Une machine sous Linux avec [Docker] installé dessus.

## Installation

### Docker
Pour installer Docker, suivre les étapes d'installations sur le [site officiel].

### Créer l'image Docker de l'API
Pour créer l'image Docker de l'API, lancer cette commande dans le dossier coreapi :
```sh
cd api-core.net 
docker build -t api-core.net .
```

### Lancer API
Pour lancer l'API, il faut faire cette commande :
```sh
docker run -p 80:80 -d --name api-core.net api-core.net
```

License
----

MIT


   [Docker]: <https://www.docker.com/>
   [site officiel]: <https://docs.docker.com/engine/installation/linux/>
