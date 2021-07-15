using NUnit.Framework;

namespace watnote.test
{
    public class EngineTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadConfig()
        {
            var engine = new WatNoteEngine();
        }

        [Test]
        public void NewNote()
        {
            var engine = new WatNoteEngine();
            engine.NewNote();
        }

        [Test]
        public void RunConfig()
        {
            var engine = new WatNoteEngine();
            engine.Config();
        }

        [Test]
        public void Backup()
        {
            var engine = new WatNoteEngine();
            engine.Backup();
        }
    }
}