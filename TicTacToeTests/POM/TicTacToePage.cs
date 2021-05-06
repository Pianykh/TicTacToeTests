using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeTests
{
    public class TicTacToePage
    {
        private readonly IWebDriver _webDriver;

        private readonly static By _changePlayerButton = By.CssSelector("[class^=ties]");
        private readonly static By _squareTopLeftBlock = By.CssSelector("[class=\"square top left\"]");
        private readonly static By _squareTopBlock = By.CssSelector("[class=\"square top\"]");
        private readonly static By _squareTopRightBlock = By.CssSelector("[class=\"square top right\"]");
        private readonly static By _scoresOnePlayer = By.CssSelector("body > div.scores.p1");
        private readonly static By _scoresTwoPlayer = By.CssSelector("body > div.scores.p2");

        public TicTacToePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public TicTacToePage GoToTicTacToePage()
        {
            _webDriver.Navigate().GoToUrl("https://playtictactoe.org/");
            return this;
        }

        public TicTacToePage ClickPlayerSwitcher()
        {
            _webDriver.FindElement(_changePlayerButton).Click();
            return this;
        }

        public bool IsElementExcistOnPage(string selector)
        {
            try
            {
                _webDriver.FindElement(By.CssSelector(selector));
            }
            catch (NoSuchElementException)
            {
                return false;
            }            
            return true;
        }
    }
    
}
