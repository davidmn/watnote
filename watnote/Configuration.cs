namespace watnote
{
    public class Configuration
    {
        public string NotesDir { get; set; }

        public string BackupDir { get; set; }

        public bool ShouldStartEditor { get; set; }

        public string EditorCmd { get; set; }

        public string EditorArgs { get; set; }
    }
}