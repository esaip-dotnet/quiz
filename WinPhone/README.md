Application Windows Phone:


Elle contient un programme permettant d'envoyer le contenue d'un fichier json sur le serveur ainsi que deux interfaces graphiques:
  - la première interface correspond à la sélection d'une réponse à une question et la validation de cette réponse
  - la seconde quant à elle correspond à la selection d'un quizz

L'envoie de données s'effectue via la méthode HttpWebRequest, car cette méthode permet d'attendre la réponse sur un thread en arrière-plan alors que la méthode WebClient quant à elle fonctionne uniquement sur le thread utilisateur


Installation
Voir le fichiers INSTALL.md se trouvant dans ce même dossier