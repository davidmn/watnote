using System;
using System.IO;

namespace watnote
{
    public class Configuration
    {
        public string NotesDir { get; set; }

        public string BackupDir { get; set; }

        public bool ShouldStartEditor { get; set; }

        public string EditorCmd { get; set; }

        public string EditorArgs { get; set; }
        
        public Configuration CreateDefault()
        {
            var notesDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"notes");

            var conf = new Configuration
            {
                NotesDir = notesDir,
                BackupDir = "",
                ShouldStartEditor = false,
                EditorCmd = "",
                EditorArgs = ""
            };
            return conf;
        }
    }
}