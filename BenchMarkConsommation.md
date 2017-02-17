                                                                                Benchmark consommation mémoire 
                                                                    
Étude comparative de performance et consommation mémoire entre une concaténation par boucle simple et l'utilisation d'un objet StringBuilder.

Concaténation simple:
Une concaténation simple se fait à l'aide d'une boucle basique telle que :

For (i=0 to fin)
chaine1+=chaine[i];

Cette méthode est efficace lorsque le nombre de chaîne à concaténer est inférieur à 8 (environ). La performance est la consommation sont alors très positifs.
Résultats pour 8 chaînes :

Compilation results....
-------------------
- OutputSize : 1.833MiB
- Compilation time : 0.87s

Résultats pour 52 chaînes :

Compilation results....
-------------------
- OutputSize : 1.835MiB
- Compilation time : 1.54s

On voit clairement que le temps de compilation est bien plus important, bien que la mémoire consommée, elle, ne varie que très peu.


Concaténation StringBuilder:
StringBuilder builder = new StringBuilder();
builder.Append("Première chaîne");
builder.Append("Seconde chaîne");

Cette méthode devient efficace si l'on veut faire de la concaténation dynamique et surtout si celle-ci dépasse le nombre de 8 chaînes de caractères.

Résultats pour 8 chaînes :

Compilation results....
-------------------
- OutputSize : 1.835MiB
- Compilation time : 0.92s

Résultats pour 52 chaînes :

Compilation results....
-------------------
- OutputSize : 1.835MiB
- Compilation time : 0.95s

Avec cette méthode, on remarque que le temps de compilation ne varie pas tellement mais est quand même bien inférieur à celui de la première méthode. 
En revanche, « Output Size » ne varie pas, il faudrait tester avec plus d’incrémentations, mais le principe reste le même.

Tous ces tests ont été réalisés avec ma machine, les résultats peuvent donc variés en fonction de la configuration. Cependant le graphique des performances restera le même si l'on fait avec encore plus de chaînes.


