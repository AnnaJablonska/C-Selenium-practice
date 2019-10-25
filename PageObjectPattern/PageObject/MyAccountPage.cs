using AutomationPractiseHomework.PageObjectPattern;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationPractiseHomework.PageObjectPattern.PageObject
{
    class MyAccountPage
    {

        private IWebDriver _driver;

        public MyAccountPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void GoToMainPage()
        {
            _driver.FindElement(By.CssSelector(".logo.img-responsive")).Click();
        }


    }
}
