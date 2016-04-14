using CSharpRefactorings.Parrot.Refactored;
using NUnit.Framework;

namespace CSharpRefactoringTests.Parrot.Refactored
{
    [TestFixture]
    public class ParrotTest
    {
        [Test]
        public void GetSpeedOfEuropeanParrot()
        {
            IParrot parrot = new EuropeanParrot();
            Assert.AreEqual(parrot.GetSpeed(), 12.0);
        }

        [Test]
        public void GetSpeedOfAfricanParrot_With_One_Coconut()
        {
            IParrot parrot = new AfricanParrot(1);
            Assert.AreEqual(parrot.GetSpeed(), 3.0);
        }

        [Test]
        public void GetSpeedOfAfricanParrot_With_Two_Coconuts()
        {
            IParrot parrot = new AfricanParrot(2);
            Assert.AreEqual(parrot.GetSpeed(), 0.0);
        }

        [Test]
        public void GetSpeedOfAfricanParrot_With_No_Coconuts()
        {
            IParrot parrot = new AfricanParrot(0);
            Assert.AreEqual(parrot.GetSpeed(), 12.0);
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_nailed()
        {
            IParrot parrot = new NorwegianBlueParrot(true);
            Assert.AreEqual(parrot.GetSpeed(), 0.0);
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_not_nailed()
        {
            IParrot parrot = new NorwegianBlueParrot(1.5);
            Assert.AreEqual(parrot.GetSpeed(), 18.0);
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_not_nailed_high_voltage()
        {
            IParrot parrot = new NorwegianBlueParrot(4);
            Assert.AreEqual(parrot.GetSpeed(), 24.0);
        }
    }
}
