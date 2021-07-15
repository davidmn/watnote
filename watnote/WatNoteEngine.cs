using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace watnote
{
    public class WatNoteEngine
    {
        private ConfigManager _configManager;
        public WatNoteEngine()
        {
            var path = GetConfigPath();
            _configManager = new ConfigManager(path);
        }

        public void NewNote()
        {
            Console.WriteLine("Creating new note...");
            var dateTime = DateTime.Now;

            var pathElements = new List<string>
            {
                _configManager.Configuration.NotesDir,
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

            if (_configManager.Configuration.ShouldStartEditor)
            {
                Console.WriteLine($"Opening note {filePath}...");

                var args = _configManager.Configuration.EditorArgs.Replace("%FOLDERPATH%", directoryPath)
                    .Replace("%FILEPATH%", filePath);
                var p = Process.Start(_configManager.Configuration.EditorCmd, args);
            }
        }

        public void Backup()
        {

        }

        public void Config()
        {
            _configManager.OpenConfig();
        }

        private string GetConfigPath()
        {
            var homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var path = Path.Combine(homeDir, ".watconf.json");
            return path;
        }
    }
}