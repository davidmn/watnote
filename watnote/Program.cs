using System;
using System.Linq;

namespace watnote
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintInfo();
                return;
            }
            if (args.Length == 2 && !args.Contains("silent"))
            {
                PrintInfo();
                return;
            }
            if (args.Length > 2)
            {
                PrintInfo();
                return;
            }

            var silent = args.Contains("silent");
            var engine = new WatNoteEngine(silent);

            switch (args[0])
            {
                case "new":
                    engine.NewNote();
                    break;
                case "backup":
                    Console.WriteLine("Backing up notes...");
                    break;
                case "config":
                    engine.Config();
                    break;
                default:
                    PrintInfo();
                    break;
            }
        }

        private static void PrintInfo()
        {
            Console.WriteLine("watnote:");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("watnote new       create a new day's notes");
            Console.WriteLine("watnote backup    backup notes to backup dir");
            Console.WriteLine("watnote config    open config, replace strings are %FOLDERPATH% %FILEPATH%");
            Console.WriteLine("watnote X silent  don't log anything while doing X");
        }
    }
}
