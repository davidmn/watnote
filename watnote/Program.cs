using System;

namespace watnote
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                PrintInfo();
                return;
            }

            var engine = new WatNoteEngine();

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
        }
    }
}
