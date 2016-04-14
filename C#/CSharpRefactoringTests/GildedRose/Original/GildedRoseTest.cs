using System.Collections.Generic;
using CSharpRefactorings.GildedRose.Original;
using NUnit.Framework;

namespace CSharpRefactoringTests.GildedRose.Original
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void Foo()
        {
            var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new CSharpRefactorings.GildedRose.Original.GildedRose(items);
            app.UpdateQuality();
            Assert.AreEqual("fixme", items[0].Name);
        }
    }
}
