using System;
using System.IO;

// Classe principale pour gérer les logs
class Logger
{
    // Déclaration d'un délégué nommé LogHandler qui prend une chaîne en paramètre
    public delegate void LogHandler(string message);

    // Propriété publique de type LogHandler pour enregistrer les méthodes de log
    public LogHandler Log;

    // Méthode pour envoyer un message à tous les gestionnaires enregistrés
    public void LogMessage(string message)
    {
        // Vérifie si un gestionnaire est attaché avant de l'invoquer
        if (Log == null)
        {
            Console.WriteLine("Aucun logger n'est enregistré !");
        }
        else
        {
            // Appelle toutes les méthodes enregistrées via le délégué
            Log?.Invoke(message);
        }
    }
}

// Classe pour gérer les logs via la console
class ConsoleLogger
{
    // Méthode statique qui implémente le log sur la console
    public static void LogMessage(string message)
    {
        Console.WriteLine("Dans ConsoleLogger : {0}", message);
    }
}

// Classe pour gérer les logs dans un fichier
class FileLogger
{
    // Chemin vers le fichier log dans le répertoire de l'utilisateur
    private static readonly string docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"source\repos\karen-asipuela-vinci\vinci-3\.NET\exo4");

    // Méthode statique pour écrire un message dans un fichier texte
    public static void LogMessageFile(string message)
    {
        try
        {
            // Vérifie si le dossier existe, sinon le crée
            if (!Directory.Exists(docPath))
            {
                Directory.CreateDirectory(docPath);
            }

            // Ouvre ou crée le fichier log en mode ajout
            using StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "logger.txt"), true);
            // Écrit le message dans le fichier
            outputFile.WriteLine("Dans fichier txt : {0}", message);
        }
        catch (Exception e)
        {
            // Affiche un message d'erreur en cas de problème
            Console.WriteLine("Erreur lors de l'écriture dans le fichier : {0}", e.Message);
        }
    }
}

// Classe pour tester les fonctionnalités de log
class Test
{
    // Point d'entrée du programme
    static void Main(string[] args)
    {
        // Instancie la classe Logger
        Logger logger = new Logger();

        // Ajoute ConsoleLogger et FileLogger au délégué Log
        logger.Log += ConsoleLogger.LogMessage; // Enregistre la méthode pour afficher dans la console
        logger.Log += FileLogger.LogMessageFile; // Enregistre la méthode pour écrire dans un fichier

        // Envoie un message à tous les gestionnaires de log enregistrés
        logger.LogMessage("Message test.");

        // Envoie un autre message pour vérifier le multicast delegate
        logger.LogMessage("Ceci est un autre message de test.");
    }
}
