using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractiseHomework.PageObjectPattern.PageObject
{
    class BuyingProductPage
    {
        private IWebDriver _driver;

        public BuyingProductPage(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void AddOneProductToShoppingCart()
        {
           // _driver.FindElement(By.XPath("//*[@id='homefeatured']/li[1]/div")).Click();
            _driver.FindElement(By.CssSelector(".product-image-container")).Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(pageLoaded => pageLoaded.FindElement(By.CssSelector("#add_to_cart")).Displayed);

            _driver.FindElement(By.CssSelector("#add_to_cart")).Click();
        }

        public void ProceedToCheckout()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(pageLoaded => pageLoaded.FindElement(By.XPath("//div/a[@title='Proceed to checkout']")).Displayed);
            _driver.FindElement(By.XPath("//div/a[@title='Proceed to checkout']")).Click();

            wait.Until(pageLoaded => pageLoaded.FindElement(By.XPath("//div/p/a[@title='Proceed to checkout']")).Displayed);
            _driver.FindElement(By.XPath("//div/p/a[@title='Proceed to checkout']")).Click();

            wait.Until(pageLoaded => pageLoaded.FindElement(By.XPath("//button[@name='processAddress']")).Displayed);
            _driver.FindElement(By.XPath("//button[@name='processAddress']")).Click();

            wait.Until(pageLoaded => pageLoaded.FindElement(By.XPath("//button[@name='processCarrier']")).Displayed);
            _driver.FindElement(By.CssSelector("#uniform-cgv")).Click();
            _driver.FindElement(By.XPath("//button[@name='processCarrier']")).Click();

            wait.Until(pageLoaded => pageLoaded.FindElement(By.CssSelector(".cheque")).Displayed);
            _driver.FindElement(By.CssSelector(".cheque")).Click();

            wait.Until(pageLoaded => pageLoaded.FindElement(By.XPath("//div[@class='columns-container']/div/div/div[@id='center_column']/form/p/button")).Displayed);
            _driver.FindElement(By.XPath("//div[@class='columns-container']/div/div/div[@id='center_column']/form/p/button")).Click();
        }


    }
}
