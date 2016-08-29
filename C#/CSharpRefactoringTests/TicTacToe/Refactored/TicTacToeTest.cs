using System.Linq;
using CSharpRefactorings.TicTacToe.Refactored;
using NUnit.Framework;

namespace CSharpRefactoringTests.TicTacToe.Refactored
{
    [TestFixture]
    public class TicTacToeTest
    {
        [Test]
        public void Win_X()
        {
            // arrange
            var ui = new UI_Mock(new[] {1, 4, 2, 5, 3});
            var ttt = new Program(ui);

            // act
            ttt.Start();

            // assert 
            Assert.AreEqual("The winner is X!", ui.Messages.Last());       
        }

        [Test]
        public void Win_Y()
        {
            // arrange
            var ui = new UI_Mock(new[] { 4, 1, 5, 2, 8,3 });
            var ttt = new Program(ui);

            // act
            ttt.Start();

            // assert 
            Assert.AreEqual("The winner is Y!", ui.Messages.Last());
        }

        [Test]
        public void Draw()
        {
            // arrange
            var ui = new UI_Mock(new[] { 5, 1, 2, 7, 3, 6, 4, 8, 9 });
            var ttt = new Program(ui);

            // act
            ttt.Start();

            // assert 
            Assert.AreEqual("No one won.", ui.Messages.Last());
        }
    }
}
