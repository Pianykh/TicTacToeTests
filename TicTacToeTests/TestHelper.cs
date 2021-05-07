using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeTests
{
    public static class TestHelper
    {
        public static bool IsElementExist(By by, IWebDriver webDriver)
        {
            try
            {
                webDriver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public static bool IsElementVisible(By by, IWebDriver webDriver)
        {
            return webDriver.FindElement(by).Displayed;
        }
    }
}
