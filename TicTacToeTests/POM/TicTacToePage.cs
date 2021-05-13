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

        private readonly static By _newGameSwitcher = By.CssSelector("[class=restart]");
        private readonly static By _squareTopLeftBlock = By.CssSelector("[class=\"square top left\"]");
        private readonly static By _squareTopBlock = By.CssSelector("[class=\"square top\"]");
        private readonly static By _squareTopRightBlock = By.CssSelector("[class=\"square top right\"]");
        private readonly static By _squareLeftBlock = By.CssSelector("[class=\"square left\"]");
        private readonly static By _squareBlock = By.CssSelector("[class=\"square\"]");
        private readonly static By _squareRightBlock = By.CssSelector("[class=\"square right\"]");
        private readonly static By _squareBottomLeftBlock = By.CssSelector("[class=\"square bottom left\"]");
        private readonly static By _squareBottomBlock = By.CssSelector("[class=\"square bottom\"]");
        private readonly static By _squareBottomRightBlock = By.CssSelector("[class=\"square bottom right\"]");
        private readonly static List<By> sqareList = new List<By>();

        private readonly static By _scoresBoardOnePlayer = By.CssSelector("body > div.scores.p1");
        private readonly static By _scoresBoardTwoPlayer = By.CssSelector("body > div.scores.p2");
        private readonly static By _scoresFirstPlayer = By.CssSelector("[class=player1] .score");
        private readonly static By _scoresSecondPlayer = By.CssSelector("[class=player2] .score");
        private readonly static By _scoresTie = By.CssSelector("[class=ties] .score");

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
            return TestHelper.IsElementExist(_scoresBoardTwoPlayer, _webDriver);               
        }

        public bool IsOnePlayersModeOn()
        {
            return TestHelper.IsElementExist(_scoresBoardOnePlayer, _webDriver);
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

        public TicTacToePage ClickOnSquare(int square)
        {
            _webDriver.FindElement(sqareList[square]).Click();
            return this;
        }
        
        public string GetScoreFirstPlayer()
        {
            return _webDriver.FindElement(_scoresFirstPlayer).Text;
        }

        public string GetScoreSecondPlayer()
        {
            return _webDriver.FindElement(_scoresSecondPlayer).Text;
        }

        public string GetScoreTie()
        {
            return _webDriver.FindElement(_scoresTie).Text;
        }

        public TicTacToePage StartNewGame()
        {
            _webDriver.FindElement(_newGameSwitcher).Click();
            return this;
        }

        public void WaitForFirstPlayerScore()        {
            
            if (_webDriver.FindElement(_scoresFirstPlayer).Text == "0")
                WaitForFirstPlayerScore();
            return;
        }

        public void WaitForSecondPlayerScore()
        {            
            if (_webDriver.FindElement(_scoresSecondPlayer).Text == "0")
                WaitForSecondPlayerScore();
            return;
        }

        public void WaitForTieScore()
        {
            if (_webDriver.FindElement(_scoresTie).Text == "0")
                WaitForTieScore();
            return;
        }
    }    
}
