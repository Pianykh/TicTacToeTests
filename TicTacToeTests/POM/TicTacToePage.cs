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
        private readonly static By _squareLeftBlock = By.CssSelector("[class=\"square left\"]");
        private readonly static By _squareBlock = By.CssSelector("[class=\"square\"]");
        private readonly static By _squareRightBlock = By.CssSelector("[class=\"square right\"]");
        private readonly static By _squareBottomLeftBlock = By.CssSelector("[class=\"square bottom left\"]");
        private readonly static By _squareBottomBlock = By.CssSelector("[class=\"square bottom\"]");
        private readonly static By _squareBottomRightBlock = By.CssSelector("[class=\"square bottom right\"]");
        private readonly static By _scoresOnePlayer = By.CssSelector("body > div.scores.p1");
        private readonly static By _scoresTwoPlayer = By.CssSelector("body > div.scores.p2");
        private readonly static List<By> sqareList = new List<By>();
        private readonly static By _audioSwitcher = By.CssSelector("[class=mute]");
        private readonly static By _audioIndicator = By.CssSelector("svg > g > path[d ^= M67]");


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

        public TicTacToePage ClickAudioSwitcher()
        {
            _webDriver.FindElement(_audioSwitcher).Click();
            return this;
        }

        public bool IsTwoPlayersModeOn()
        {
            return TestHelper.IsElementExist(_scoresTwoPlayer, _webDriver);               
        }

        public bool IsOnePlayersModeOn()
        {
            return TestHelper.IsElementExist(_scoresOnePlayer, _webDriver);
        }

        public bool IsAudioOn()
        {
            return TestHelper.IsElementVisible(_audioIndicator, _webDriver);                
        }

        public bool IsSquareMarked(int square)
        {
            By mark = By.CssSelector(sqareList[square].ToString().Replace("By.CssSelector: ", "") + " .x");
            return TestHelper.IsElementVisible(mark, _webDriver);
        }

        public TicTacToePage CreateSquareList()
        {            
            sqareList.Add(_squareTopLeftBlock);
            sqareList.Add(_squareTopBlock);
            sqareList.Add(_squareTopRightBlock);
            sqareList.Add(_squareLeftBlock);
            sqareList.Add(_squareBlock);
            sqareList.Add(_squareRightBlock);
            sqareList.Add(_squareBottomLeftBlock);
            sqareList.Add(_squareBottomBlock);
            sqareList.Add(_squareBottomRightBlock);
            return this;
        }

        public void ClickOnSquare(int square)
        {
            _webDriver.FindElement(sqareList[square]).Click();            
        }        
    }    
}
