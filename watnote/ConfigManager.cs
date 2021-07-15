using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace watnote
{
    public class ConfigManager
    {
        public Configuration Configuration;
        private readonly string _configurationPath;
        public ConfigManager(string configPath)
        {
            _configurationPath = configPath;
            try
            {
                LoadConfig(_configurationPath);
            }
            catch (Exception)
            {
                Console.WriteLine("Deserializing config failed");
                throw;
            }
        }
        
        public void OpenConfig()
        {
            if (Configuration.ShouldStartEditor)
            {
                Console.WriteLine("Opening config...");
                try
                {
                    var p = Process.Start(Configuration.EditorCmd, _configurationPath);
                    return;
                }
                catch (Exception)
                {
                    Console.WriteLine("Couldn't open editor, dumping settings");
                }
            }
            PrintConfig();
        }

        private void PrintConfig()
        {
            var configText = JsonSerializer.Serialize(Configuration);
            Console.Write(configText);
            Console.WriteLine();
        }
        
        private void LoadConfig(string configPath)
        {
            if (!File.Exists(configPath))
            {
                var defaultConfig = new Configuration().CreateDefault();
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(defaultConfig, options);
                File.WriteAllText(configPath, jsonString);
            }

            var configText = File.ReadAllText(configPath);
            var config = JsonSerializer.Deserialize<Configuration>(configText);
            Configuration = config;
        }

        
    }
}