1. QuizLeapProject

Ce projet remplit diff�rentes fonctionnalit�s :

D�tecter les mouvements d�une main ;
Assigner une valeur (dans notre cas une r�ponse) par rapport � la position de la main ;
Cr�er des zones neutres pour bien s�parer les zones de r�ponses (voir sch�ma plus bas) ;
Proposer un quiz brut comprenant une liste de quatre questions ferm�es ayant quatre choix de r�ponses ;
Switcher de question quand la r�ponse donn�e est correcte.
R�sultat obtenu :

final_result

2. Auteurs et copyright

Auteurs

Les auteurs de ce projet sont : CIVEL Bastien et ANDIVEAU Ludovic. Ce sont tous les deux des �l�ves de 5e ann�e en Ing�nieur du num�rique � l�ESAIP.

Civel Bastien - Github de Bastien.
ANDIVEAU Ludovic - Github de Ludovic.
Vous trouverez aussi la liste de tous les contributeurs qui ont particip� au projet.

Copyright

Voir la LICENCE.

3. Etat du projet

Le projet pour l�instant est encore � brut �, il n�est pas totalement dynamique, nous avons des variables en brutes pour g�n�rer notre Quiz et nos r�ponses.

4. Mise en place, pr�requis, utilisation rapide

Mat�riels utilis�s

LEAP MOTION

leap_motion

La LEAP motion nous a �t� pr�t�e par notre intervenant et il nous a �t� possible de l�utiliser � l�ext�rieur de l�enceinte de l�ESAIP, nous permettant de continuer notre projet chez nous.

PC Windows 8.1 64bits

C�est la version que nous avons utilis�e et c�est aussi la version minimale de Windows � avoir pour pouvoir utiliser le logiciel : Microsoft Visual Studio Ultimate 2013 Version 12.0.31101.00 Update 4.

Softs � installer

Pour utiliser notre projet il vous faudra au pr�alable t�l�charger et installer ces diff�rents logiciels :

Microsoft Visual Studio Ultimate 2013 Version 12.0.31101.00 Update 4 ;
Leap Motion SDK v2.3.1 que vous pouvez t�l�charger ici ;
Ajout de la r�f�rence Projet : LeapCSharp.NET4.0.
Attention : Pour int�grer votre SDK il faudra renseigner le chemin o� se trouve celui-ci. Pour cela il vous faudra ajouter une variable d�environnement syst�me � LEAP_SDK � pointant sur votre SDK.

variable_environnement

Puis cliquez sur l�onglet PROJET, dans la liste d�roulante s�lectionnez � Propri�t�s de NomDuProjet �. Ensuite dans � Ev�nements de build � ajout� la ligne ci-dessous :

xcopy /yr "C:\LeapMotionSDK\lib\x64\Leap.dll" "$(TargePath)"xcopy /yr "C:\LeapMotionSDK\lib\x64\LeapCSharp.dll" "$(TargetPath)"
prorietes_projet

Utilisation

Pour r�pondre � la question une fois le programme lanc�, il suffit � l�utilisateur de placer sa main dans une des zones de r�ponse.

schema_zones

5. License

Ce projet est sous la license MIT - voir le fichier LICENSE.md pour plus de d�tails.

6. Contribution, am�liorations possibles

Voici une liste d�am�liorations qui permettrait de faire progresser notre projet :

Zones personnalisables calcul�es � l�aide d�un algorithme h�berg� sur un Service. C�est-�-dire qu�il y aurait une initialisation au lancement du quiz, o� le joueur choisirait ses zones de r�ponses.
Mettre en place un changement de questions, pour l�instant celui-ci ne s�effectue que lorsqu�une bonne r�ponse a �t� donn�e.