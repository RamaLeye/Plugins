# TP3_PatronsModele_plugins


Ma solution comprend 4 projets : 

- MyPluginApp : un projet console et qui contient le main. C'est le projet principal
- PluginBase : une librairie de classes (DLL) où on retrouve l'interface IPlugin qu'implementeront tous nos plugins 
- NoticePlugin : un plugin de test de type DLL
- ReadUsersPlugin : le plugin répondant à ce TP de type DLL

Ainsi, nous partons sur 2 projets principaux qui sont MuPluginApp et PluginBase, et plus on a de plugins, plus le nombre de projets augmentera.


J'ai choisi de mettre la classe User dans le projet PluginBase car c'est une classe réutilisable par d'autres types de plugins ( par exemple si on voudrait créer un puglin qui ecrit les users dans un file).
Vu que tous les projets de plugin ont comme réference la PluginBase, ils pourront également utiliser User si nécessaire.

Dans notre système, nous retrouvons dans notre plugin des informations comme le nom, une brève definition et une fonction d'exécution de ce plugin.
Dans le plugin ReadUsers, la liste d'utilisateurs est chargée par la fonction ReadUsersFiles que l'on appelle dans la fonction Execute(). Ainsi, on parcourt chaque fichier de type Json uniquement et grace au package nuget Newtonsoft.json, on récupere chaque fichier sous forme de liste qu'on rajoute dans la liste principale d'utilisateurs du plugin. 
