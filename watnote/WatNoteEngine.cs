using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace watnote
{
    public class WatNoteEngine
    {
        private string _configPath;
        private Configuration _configuration;
        public WatNoteEngine()
        {
            LoadConfig();
        }

        public void NewNote()
        {
            Console.WriteLine("Creating new note...");
            var dateTime = DateTime.Now;

            var pathElements = new List<string>
            {
                _configuration.NotesDir,
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

            if (_configuration.ShouldStartEditor)
            {
                Console.WriteLine($"Opening note {filePath}...");

                var args = _configuration.EditorArgs.Replace("%FOLDERPATH%", directoryPath)
                    .Replace("%FILEPATH%", filePath);
                var p = Process.Start(_configuration.EditorCmd, args);
            }
        }

        public void Backup()
        {

        }

        public void Config()
        {
            if (_configuration.ShouldStartEditor)
            {
                Console.WriteLine("Opening config...");
                try
                {
                    var p = Process.Start(_configuration.EditorCmd, _configPath);
                }
                catch (Exception)
                {
                    Console.WriteLine("Couldn't open editor, dumping settings");
                    PrintConfig();
                }
            }
            else
            {
                PrintConfig();
            }
        }

        private void PrintConfig()
        {
            var configText = File.ReadAllText(_configPath);
            Console.Write(configText);
            Console.WriteLine();
        }

        private void LoadConfig()
        {
            var homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            _configPath = Path.Combine(homeDir, ".watconf.json");

            if (!File.Exists(_configPath))
            {
                var defaultConfig = CreateDefaultConfig();
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(defaultConfig, options);
                File.WriteAllText(_configPath, jsonString);
            }

            var configText = File.ReadAllText(_configPath);
            var config = JsonSerializer.Deserialize<Configuration>(configText);
            _configuration = config;
        }

        private Configuration CreateDefaultConfig()
        {
            var conf = new Configuration
            {
                NotesDir = @"C:\Repos\notes",
                BackupDir = "",
                ShouldStartEditor = false,
                EditorCmd = "",
                EditorArgs = ""
            };
            return conf;
        }
    }
}