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
            Assert.IsTrue(ticTacToePage.IsElementExcistOnPage("body > div.scores.p2"));            
        }      
    }
}
