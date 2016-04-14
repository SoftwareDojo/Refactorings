using CSharpRefactorings.Parrot.Original;
using NUnit.Framework;

namespace CSharpRefactoringTests.Parrot.Original
{
    [TestFixture]
    public class ParrotTest
    {
        [Test]
        public void GetSpeedOfEuropeanParrot()
        {
            var parrot = new CSharpRefactorings.Parrot.Original.Parrot(ParrotTypeEnum.EUROPEAN, 0, 0, false);
            Assert.AreEqual(parrot.GetSpeed(), 12.0);
        }

        [Test]
        public void GetSpeedOfAfricanParrot_With_One_Coconut()
        {
            var parrot = new CSharpRefactorings.Parrot.Original.Parrot(ParrotTypeEnum.AFRICAN, 1, 0, false);
            Assert.AreEqual(parrot.GetSpeed(), 3.0);
        }

        [Test]
        public void GetSpeedOfAfricanParrot_With_Two_Coconuts()
        {
            var parrot = new CSharpRefactorings.Parrot.Original.Parrot(ParrotTypeEnum.AFRICAN, 2, 0, false);
            Assert.AreEqual(parrot.GetSpeed(), 0.0);
        }

        [Test]
        public void GetSpeedOfAfricanParrot_With_No_Coconuts()
        {
            var parrot = new CSharpRefactorings.Parrot.Original.Parrot(ParrotTypeEnum.AFRICAN, 0, 0, false);
            Assert.AreEqual(parrot.GetSpeed(), 12.0);
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_nailed()
        {
            var parrot = new CSharpRefactorings.Parrot.Original.Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 0, true);
            Assert.AreEqual(parrot.GetSpeed(), 0.0);
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_not_nailed()
        {
            var parrot = new CSharpRefactorings.Parrot.Original.Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 1.5, false);
            Assert.AreEqual(parrot.GetSpeed(), 18.0);
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_not_nailed_high_voltage()
        {
            var parrot = new CSharpRefactorings.Parrot.Original.Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 4, false);
            Assert.AreEqual(parrot.GetSpeed(), 24.0);
        }
    }
}
