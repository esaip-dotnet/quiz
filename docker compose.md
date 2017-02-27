Explication Docker Compose :

Pour mettre en place notre application, nous avions differentes API (Node et core) qui pouvaient être appelé grace à l'exposition des ports. Ceci à été fait grace au docker compose qui gérait la redirection des ports. Chaque Api, pointait vers un port différent. Exemple : L'api node vers le port 82
	  L'api core vers le port 81
Ainsi, le docker compose permet de les exposé par la suite sur le port 80.