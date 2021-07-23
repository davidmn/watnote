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
            var engine = new WatNoteEngine(false);
        }

        [Test]
        public void NewNote()
        {
            var engine = new WatNoteEngine(false);
            engine.NewNote();
        }

        [Test]
        public void RunConfig()
        {
            var engine = new WatNoteEngine(false);
            engine.Config();
        }

        [Test]
        public void Backup()
        {
            var engine = new WatNoteEngine(false);
            engine.Backup();
        }
    }
}