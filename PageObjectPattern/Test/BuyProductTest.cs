using AutomationPractiseHomework.PageObjectPattern;
using AutomationPractiseHomework.PageObjectPattern.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing.Imaging;
using System.Threading;

namespace AutomationPractiseHomework.Test
{
    [TestFixture]
    class BuyProductTest : TestSetUp
    {

    [Test]
    public void BuyProductAndCheckSuccessMessage()
        {
            var register = new RegisterPage(driver);
            register.RegisterUserFirstStep();
            register.FillRegisterForm();

            //Go to MainPage
            var myAccountPage = new MyAccountPage(driver);
            myAccountPage.GoToMainPage();

            //Find a short, add it to cart and proceed to checkout
            var mainPage = new BuyingProductPage(driver);
            mainPage.AddOneProductToShoppingCart();
            mainPage.ProceedToCheckout();

            //Check the success message
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(finish => finish.FindElement(By.CssSelector(".alert.alert-success")).Displayed);
            var successMessage = driver.FindElement(By.CssSelector(".alert.alert-success"));
            Assert.AreEqual("Your order on My Store is complete.", successMessage.Text);

        }




    }
}
