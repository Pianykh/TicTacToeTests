using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeTests
{
    class MarkingBoardTests : TestConfiguration
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        
        public void ChangePlayer_ShouldChangeAiToSecondPlayer(int index)
        {
            var ticTacToePage = new TicTacToePage(webDriver);
            ticTacToePage.GoToTicTacToePage()
                .CreateSquareList()
                .ClickOnSquare(index);
        }
    }
}
