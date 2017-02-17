# 1. QuizLeapProject 

Ce projet remplit différentes fonctionnalités :
*   Détecter les mouvements d’une main ;
*   Assigner une valeur (dans notre cas une réponse) par rapport à la position de la main ;
*   Créer des zones neutres pour bien séparer les zones de réponses (voir schéma plus bas) ;
*   Proposer un quiz brut comprenant une liste de quatre questions fermées ayant quatre choix de réponses ;
*   Switcher de question quand la réponse donnée est correcte.

Résultat obtenu :

![final_result](https://github.com/Ludovic-Andiveau/hello-word/blob/master/final_result.png "Interface finale via terminal")


# 2. Auteurs et copyright

### Auteurs

Les auteurs de ce projet sont : CIVEL Bastien et ANDIVEAU Ludovic. Ce sont tous les deux des élèves de 5e année en Ingénieur du numérique à l’ESAIP.


* [Civel Bastien](https://github.com/BastienCivel) - Github de Bastien.
* [ANDIVEAU Ludovic](https://github.com/Ludovic-Andiveau/) - Github de Ludovic.


Vous trouverez aussi la liste de tous les [contributeurs](https://github.com/Ludovic-Andiveau/quiz/graphs/contributors) qui ont participé au projet.

### Copyright

Voir la [LICENCE](https://github.com/Ludovic-Andiveau/quiz/blob/master/LICENSE).

# 3. Etat du projet

Le projet pour l’instant est encore « brut », il n’est pas totalement dynamique, nous avons des variables en brutes pour générer notre Quiz et nos réponses.


# 4. Mise en place, prérequis, utilisation rapide

## Matériels utilisés

LEAP MOTION

![leap_motion](https://github.com/Ludovic-Andiveau/hello-word/blob/master/leap_motion.jpg "Leap motion connecté au pc.")

La LEAP motion nous a été prêtée par notre intervenant et il nous a été possible de l’utiliser à l’extérieur de l’enceinte de l’ESAIP, nous permettant de continuer notre projet chez nous.


PC Windows 8.1 64bits

C’est la version que nous avons utilisée et c’est aussi la version minimale de Windows à avoir pour pouvoir utiliser le logiciel : Microsoft Visual Studio Ultimate 2013 Version 12.0.31101.00 Update 4.

## Softs à installer

Pour utiliser notre projet il vous faudra au préalable télécharger et installer ces différents logiciels :

*	Microsoft Visual Studio Ultimate 2013 Version 12.0.31101.00 Update 4 ;
*   Leap Motion SDK v2.3.1 que vous pouvez télécharger [ici](https://developer.leapmotion.com/sdk/v2/) ; 
*	Ajout de la référence Projet : LeapCSharp.NET4.0.


Attention : Pour intégrer votre SDK il faudra renseigner le chemin où se trouve celui-ci.
Pour cela il vous faudra ajouter une variable d’environnement système « LEAP_SDK » pointant sur votre SDK.

![variable_environnement](https://github.com/Ludovic-Andiveau/hello-word/blob/master/variable_environnement.png "Ajout variable environnement.")

Puis cliquez sur l’onglet PROJET, dans la liste déroulante sélectionnez « Propriétés de NomDuProjet ». Ensuite dans « Evénements de build » ajouté la ligne ci-dessous :

```
xcopy /yr "C:\LeapMotionSDK\lib\x64\Leap.dll" "$(TargePath)"xcopy /yr "C:\LeapMotionSDK\lib\x64\LeapCSharp.dll" "$(TargetPath)"
```

![prorietes_projet](https://github.com/Ludovic-Andiveau/hello-word/blob/master/prorietes_projet.png "Modification propriétés du projet.")

## Utilisation

Pour répondre à la question une fois le programme lancé, il suffit à l’utilisateur de placer sa main dans une des zones de réponse. 

![schema_zones](https://github.com/Ludovic-Andiveau/hello-word/blob/master/schema_zones.JPG "Schema des zones de réponses.")

# 5. License

Ce projet est sous la license MIT - voir le fichier [LICENSE.md](https://github.com/Ludovic-Andiveau/quiz/blob/master/LICENSE) pour plus de détails.

# 6. Contribution, améliorations possibles

Voici une liste d’améliorations qui permettrait de faire progresser notre projet : 
*   Zones personnalisables calculées à l’aide d’un algorithme hébergé sur un Service. C’est-à-dire qu’il y aurait une initialisation au lancement du quiz, où le joueur choisirait ses zones de réponses.
*   Mettre en place un changement de questions, pour l’instant celui-ci ne s’effectue que lorsqu’une bonne réponse a été donnée. 

