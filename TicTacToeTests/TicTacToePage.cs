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
       // private readonly static By _passwordField = By.CssSelector("input[type=password]");
       // private readonly static By _loginButton = By.CssSelector("[class^=SignInForm__submitButton]");
       // private readonly static By _blockedUserMessage = By.CssSelector("[class^=FormErrorText__error]>div");

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
    }
    
}
