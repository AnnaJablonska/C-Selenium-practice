using AutomationPractiseHomework.PageObjectPattern;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationPractiseHomework.Test
{
    [TestFixture]
    class CreateNewUserTest : TestSetUp
    {


        [Test]
        public void CreateNewUserAccount()
        {
            //Register user
            var registerPage = new RegisterPage(driver);
            //Enter email adress and click Create account
            registerPage.RegisterUserFirstStep();
            //Fill teh registration form
            registerPage.FillRegisterForm();


            //Check the success message
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(finish => finish.FindElement(By.CssSelector(".info-account")).Displayed);
            var successMessage = driver.FindElement(By.CssSelector(".info-account"));
            Assert.AreEqual("Welcome to your account. " +
                "Here you can manage all of your personal information and orders.", successMessage.Text);

        }


    }
}
