using System;
using System.IO;

namespace watnote
{
    public class WatNoteEngine
    {
        private readonly ConfigManager _configManager;
        public WatNoteEngine()
        {
            var path = GetConfigPath();
            _configManager = new ConfigManager(path);
        }

        public void NewNote()
        {
            NoteCreator.CreateNote(_configManager.Configuration);
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