using System;
using System.IO;

namespace watnote
{
    public class WatNoteEngine
    {
        private readonly ConfigManager _configManager;
        private readonly bool _silent;
        public WatNoteEngine(bool silent)
        {
            var path = GetConfigPath();
            _configManager = new ConfigManager(path);
            _silent = silent;
        }

        public void NewNote()
        {
            NoteCreator.CreateNote(_configManager.Configuration, _silent);
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