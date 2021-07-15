using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace watnote
{
    public static class NoteCreator
    {
        public static void CreateNote(Configuration configuration)
        {
            Console.WriteLine("Creating new note...");
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
                Console.WriteLine($"Creating note {filePath}...");
                Directory.CreateDirectory(directoryPath);
                var title = $@"# {dateTime.Year}-{dateTime.Month:D2}-{dateTime.Day:D2}" + Environment.NewLine;
                File.WriteAllText(filePath, title);
            }

            if (configuration.ShouldStartEditor)
            {
                Console.WriteLine($"Opening note {filePath}...");

                var args = configuration.EditorArgs.Replace("%FOLDERPATH%", directoryPath)
                    .Replace("%FILEPATH%", filePath);
                Process.Start(configuration.EditorCmd, args);
            }
        }
    }
}