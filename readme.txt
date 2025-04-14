SYSTÈME DE LISTES DOUBLEMENT CHAÎNÉES
=========================================================

AUTEUR(S) : Simon Drolet, Marc-Antoine Leblond
DATE DE CRÉATION : 14 avril 2025

DESCRIPTION :
-------------
Implémentation de liste doublement chaînée en C#, avec suppression paresseuse.

FONCTIONS :
-----------
FindNode(int valueToFind) : Prend un entier en paramètre. Recherche la première node contenant cette valeur (non libre) et retourne son identificateur (Id). Si aucune node ne contient cette valeur, retourne null.
AddNode(int valueToAdd) : Prend un entier en paramètre. Ajoute la valeur dans la première node libre trouvée dans la liste. Si aucune node libre n’est disponible, affiche un message d’erreur.
FreeNode(int valueToRemove) : Prend un entier en paramètre. Recherche la première node contenant cette valeur, et la marque comme libre (Value = null). Si aucune node ne correspond, affiche un message approprié.
CompactNodes() : Parcourt la liste chaînée et supprime tous les nodes marqués comme libres. La structure de la liste est mise à jour pour relier correctement les nodes restants.

COMMANDES D'ÉXÉCUTION :
-----------------------------------
- dotnetrun

RÉFÉRENCES :
-------------
- Pigeon, S., P. (n.d.). Les structures de données et leurs algorithmes en langage C++ : une approche brutaliste.
- Tulusibrahim. (2023, November 3). Understanding doubly linked list: a tutorial - Tulusibrahim - medium. Medium. https://tulusibrahim.medium.com/understanding-doubly-linked-list-a-tutorial-c91330f8031d
- Linear Data Structures: Doubly linked lists cheatsheet | Codecademy. (n.d.). Codecademy. https://www.codecademy.com/learn/linear-data-structures-python/modules/doubly-linked-lists-python/cheatsheet
- Doubly Linked List (With code). (n.d.). https://www.programiz.com/dsa/doubly-linked-list
- Doubly Linked List Class with Nodes C++. (n.d.). Stack Overflow. https://stackoverflow.com/questions/74750549/doubly-linked-list-class-with-nodes-c
- Contributeurs aux projets Wikimedia. (2024, April 1). Liste chaînée. https://fr.wikipedia.org/wiki/Liste_cha%C3%AEn%C3%A9e
