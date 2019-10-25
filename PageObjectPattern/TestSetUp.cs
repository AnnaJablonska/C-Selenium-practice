
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace AutomationPractiseHomework.PageObjectPattern
{
    class TestSetUp
    {
        public IWebDriver driver;

        [SetUp]
        public void Start()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
            driver.Manage().Window.Maximize();
        }


    [TearDown]
        public void Close()
        {
            driver.Close();
        }

    }
}
