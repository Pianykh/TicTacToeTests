using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace TicTacToeTests
{
    public class ChangePlayerTests : TestConfiguration
    {
        [Test]
        public void ChangePlayer_ShouldChangeAiToSecondPlayer()
        {
            var ticTacToePage = new TicTacToePage(webDriver);
            ticTacToePage.GoToTicTacToePage()
                .ClickPlayerSwitcher();
            Assert.IsTrue(ticTacToePage.IsTwoPlayersModeOn());               
        }

        [Test]
        public void ChangePlayer_ShouldChangeSecondPlayerToAi()
        {
            var ticTacToePage = new TicTacToePage(webDriver);
            ticTacToePage.GoToTicTacToePage()
                .ClickPlayerSwitcher();
            if (ticTacToePage.IsTwoPlayersModeOn())
                ticTacToePage.ClickPlayerSwitcher();
            Assert.IsTrue(ticTacToePage.IsOnePlayersModeOn());
        }
    }
}
