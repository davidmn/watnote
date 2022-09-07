using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace watnote
{
    public static class NoteCreator
    {
        public static void CreateNote(Configuration configuration, bool silent)
        {
            WriteLine("Creating new note...", silent);
            var dateTime = DateTime.Now;

            var pathElements = new List<string>
            {
                configuration.NotesDir,
                $"{dateTime.Year}",
                $"{dateTime.Month:D2}"
            };
            var directoryPath = Path.Combine(pathElements.ToArray());

            pathElements.Add($"{dateTime.Year}-{dateTime.Month:D2}-{dateTime.Day:D2}.md");
            var filePath = Path.Combine(pathElements.ToArray());

            if (!File.Exists(filePath))
            {
                WriteLine($"Creating note {filePath}...", silent);
                Directory.CreateDirectory(directoryPath);
                var title = $@"# {dateTime.Year}-{dateTime.Month:D2}-{dateTime.Day:D2}" + Environment.NewLine;
                File.WriteAllText(filePath, title);
            }

            if (configuration.ShouldStartEditor)
            {
                WriteLine($"Opening note {filePath}...", silent);

                var args = configuration.EditorArgs.Replace("%FOLDERPATH%", configuration.NotesDir)
                    .Replace("%FILEPATH%", filePath);
                
                var startInfo = new ProcessStartInfo
                {
                    Arguments = args,
                    FileName = configuration.EditorCmd,
                    UseShellExecute = true
                };
                
                Process.Start(startInfo);
            }
        }
        
        private static void WriteLine(string text, bool silent)
        {
            if (!silent)
            {
                Console.WriteLine(text);
            }
        }
    }
}
