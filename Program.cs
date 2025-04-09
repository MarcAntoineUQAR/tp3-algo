using System;
using System.Collections.Generic;

public class Node
{
    public int Id;
    public Node? Previous;
    public Node? Next;
    public int? Value;

    public Node(int id, int value)
    {
        Id = id;
        Previous = null;
        Next = null;
        Value = value;
    }
}

public class DoubleLL
{
    public Node StartingNode;
    public Node FindNode(int valueToFind)
    {
        Node currentNode = StartingNode;
        while (currentNode != null)
        {
            if (currentNode.Value == valueToFind)
            {
                Console.WriteLine($"Node {valueToFind} trouvé dans {currentNode.Id}");
                return currentNode;
            }
            currentNode = currentNode.Next;
        }
        Console.WriteLine($"Node {valueToFind} non trouvé");
        return null;
    }

    public void AddNode(int valueToAdd)
    {
        Node currentNode = StartingNode;
        while (currentNode.Next != null)
        {
            if (currentNode.Value != null)
                currentNode = currentNode.Next;
            else
            {
                currentNode.Value = valueToAdd;
                Console.WriteLine($"Valeur {valueToAdd} ajouté dans node {currentNode.Id}");
                return;
            }
            Console.WriteLine("Aucune node libre");
            return;
        }
    }

    public void RemoveNode(int idToRemove)
    {
        Node currentNode = StartingNode;
        while (currentNode != null)
        {
            if (currentNode.Id == idToRemove)
            {
                if (currentNode.Value == null)
                {
                    Console.WriteLine($"Le node {idToRemove} est déjà libre.");
                    return;
                }

                currentNode.Value = null;
                Console.WriteLine($"Le node {idToRemove} est maintenant libre.");
                return;
            }
            currentNode = currentNode.Next;
        }

        Console.WriteLine($"Aucun node avec l'ID {idToRemove} trouvé.");
    }

    public void CompactNodes()
    {
        Node currentNode = StartingNode;

        while (currentNode != null)
        {
            // Sauvegarde du prochain node AVANT de possiblement supprimer celui-ci
            Node nextNode = currentNode.Next;

            if (currentNode.Value == null)
            {
                // Si le node précédent existe, on relie son Next au node suivant
                if (currentNode.Previous != null)
                    currentNode.Previous.Next = currentNode.Next;
                else
                    StartingNode = currentNode.Next; // Si on supprime le premier node

                // Si le node suivant existe, on relie son Previous au node précédent
                if (currentNode.Next != null)
                    currentNode.Next.Previous = currentNode.Previous;
            }
            // Passe au prochain node
            currentNode = nextNode;
        }
    }
}

class Program
{
    static void Main()
    {
        Random random = new Random();
        var list = new DoubleLL();

        list.StartingNode = new Node(0, random.Next(1, 10));
        Node current = list.StartingNode;

        for (int i = 1; i < 5; i++)
        {
            var newNode = new Node(i, random.Next(1, 10));
            current.Next = newNode;
            newNode.Previous = current;
            current = newNode;
        }

        string choix;
        do
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Afficher tous les nodes");
            Console.WriteLine("2. Trouver un node avec une valeur");
            Console.WriteLine("3. Ajouter une valeur");
            Console.WriteLine("4. Supprimer une valeur");
            Console.WriteLine("5. Compacter la liste");
            Console.WriteLine("6. Quitter");
            Console.Write("Choix: ");
            choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Valeurs dans la liste :");
                    Node currentAffichage = list.StartingNode;
                    while (currentAffichage != null)
                    {
                        if (currentAffichage.Value != null)
                            Console.WriteLine($"[{currentAffichage.Id}] -> {currentAffichage.Value}");
                        else if (currentAffichage.Value == null)
                            Console.WriteLine($"[{currentAffichage.Id}] -> (libre)");
                        currentAffichage = currentAffichage.Next;
                    }
                    break;

                case "2":
                    Console.Write("Entrez un entier à trouver: ");
                    if (int.TryParse(Console.ReadLine(), out int valeurRecherche))
                    {
                        Node nodeFound = list.FindNode(valeurRecherche);
                        if (nodeFound != null)
                            Console.WriteLine($"Node trouvé. Id : {nodeFound.Id}, Valeur : {nodeFound.Value}");
                        else
                            Console.WriteLine("Aucun node avec cette valeur n’a été trouvé.");
                    }
                    break;

                case "3":
                    Console.Write("Entrez un entier à ajouter: ");
                    if (int.TryParse(Console.ReadLine(), out int valeurAjout))
                        list.AddNode(valeurAjout);
                    break;

                case "4":
                    Console.Write("Entrez un entier à supprimer: ");
                    if (int.TryParse(Console.ReadLine(), out int valeurSupp))
                    {
                        var node = list.FindNode(valeurSupp);
                        if (node != null)
                            list.RemoveNode(node.Id);
                    }
                    break;

                case "5":
                    Console.WriteLine("Compaction...");
                    list.CompactNodes();
                    break;

                case "6":
                    Console.WriteLine("bo-bye");
                    break;

                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }

        } while (choix != "5");
    }
}
