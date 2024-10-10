//# toutes les classes seront implémentées ici par facilité

// Classe Logger

class Logger
{
    public delegate void LogHandler(string message);

    // propriété pour enregistrer méthode
    public LogHandler Log;

    public void LogMessage(string message)
    {
        Log?.Invoke(message);
    }
}

// Classe ConsoleLogger

class ConsoleLogger
{
    // implémente un logger qui écrit sur la console
    public static void LogMessage(string message)
    {
        Console.WriteLine("Dans ConsoleLogger : {0}", message);
    }
}

// Classe FileLogger

class FileLogger
{
    // implémente logger dans un fichier
    private static readonly string docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"source\repos\karen-asipuela-vinci\vinci-3\.NET\exo4");

    public static void LogMessageFile(string message)
    {
        try
        {
            using StreamWriter outputFile = new (Path.Combine(docPath, "logger.txt"));
            outputFile.WriteLine("Dans fichier txt : {0}", message);
        } catch (Exception e)
        {
            Console.WriteLine("Erreur lors de l'écriture dans le fichier : {0}", e.Message);
        }
    }
}

// Classe test

class Test
{
    static void Main(string[] args)
    {
        Logger logger = new();

        logger.Log += ConsoleLogger.LogMessage;
        logger.Log += FileLogger.LogMessageFile;

        logger.LogMessage("message test.");
    }
}