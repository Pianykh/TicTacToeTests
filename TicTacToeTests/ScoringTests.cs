using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TicTacToeTests
{
    class ScoringTests : TestConfiguration
    {
        [Test]
        public void FirstPalyerWin_ShuldScorePointToFirstPlayer()
        {
            var ticTacToePage = new TicTacToePage(webDriver);
            ticTacToePage.GoToTicTacToePage()
                .ClickPlayerSwitcher()
                .CreateSquareList()
                .ClickOnSquare(0)
                .ClickOnSquare(2)
                .ClickOnSquare(3)
                .ClickOnSquare(5)
                .ClickOnSquare(6)
                .StartNewGame();
            ticTacToePage.WaitForFirstPlayerScore();
            
            var actualScore = ticTacToePage.GetScoreFirstPlayer();
            var expectedScore = "1";

            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void SecondPalyerWin_ShuldScorePointToSecondPlayer()
        {
            var ticTacToePage = new TicTacToePage(webDriver);
            ticTacToePage.GoToTicTacToePage()
                .ClickPlayerSwitcher()
                .CreateSquareList()
                .ClickOnSquare(0)
                .ClickOnSquare(2)
                .ClickOnSquare(1)
                .ClickOnSquare(5)
                .ClickOnSquare(6)
                .ClickOnSquare(8)
                .StartNewGame();
            ticTacToePage.WaitForSecondPlayerScore();

            var actualScore = ticTacToePage.GetScoreSecondPlayer();
            var expectedScore = "1";

            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Tie_ShuldScorePointToTieScores()
        {
            var ticTacToePage = new TicTacToePage(webDriver);
            ticTacToePage.GoToTicTacToePage()
                .ClickPlayerSwitcher()
                .CreateSquareList()
                .ClickOnSquare(0)
                .ClickOnSquare(1)
                .ClickOnSquare(2)
                .ClickOnSquare(3)
                .ClickOnSquare(5)
                .ClickOnSquare(4)
                .ClickOnSquare(7)
                .ClickOnSquare(8)
                .ClickOnSquare(6)
                .StartNewGame();
            ticTacToePage.WaitForTieScore();

            var actualScore = ticTacToePage.GetScoreTie();
            var expectedScore = "1";

            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}
