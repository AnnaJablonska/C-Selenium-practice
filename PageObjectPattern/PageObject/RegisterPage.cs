using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractiseHomework
{
    class RegisterPage
    {

        private IWebDriver _driver;

        public RegisterPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        //Data for the registration form
        private String firstName = "FirstName";
        private String lastName = "LastName";
        private String password = "password";
        private String street = "street";
        private String city = "city";
        private String postalCode = "12345";
        private String mobilePhone = "12345678";


        //Registration fields

        [FindsBy(How = How.CssSelector, Using = "#email_create")]
        public IWebElement EmailField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#SubmitCreate")]
        public IWebElement CreateAccountButton { get; set; }


        [FindsBy(How = How.Id, Using = "customer_firstname")]
        public IWebElement FirstNameLocator { get; set; }

        [FindsBy(How = How.Id, Using = "customer_lastname")]
        public IWebElement LastNameLocator { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#id_gender1")]
        public IWebElement GenderCheckboxLocator { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#passwd")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "address1")]
        public IWebElement Address1Field { get; set; }

        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement CityField { get; set; }

        [FindsBy(How = How.Id, Using = "postcode")]
        public IWebElement PostcodeField { get; set; }

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        public IWebElement MobilePhoneField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#id_state")]
        public IWebElement StateDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "submitAccount")]
        public IWebElement SubmitAccountBtn { get; set; }


        public void RegisterUserFirstStep()
        {
            //Create random email and fill the Email field
            Random r = new Random();
            String email = $"Email{r.Next()}@gmail.com";
            _driver.FindElement(By.CssSelector("#email_create")).SendKeys(email);
            //EmailField.SendKeys(email);

            //Click Create Account button
            CreateAccountButton.Click();
        }

        public void FillRegisterForm()
        {
            //Wait for Filling form
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(pageLoaded => pageLoaded.FindElement(By.CssSelector(".std.box")).Displayed);

            //Fill the form
            GenderCheckboxLocator.Click();
            FirstNameLocator.SendKeys(firstName);
            LastNameLocator.SendKeys(lastName);
            PasswordField.SendKeys(password);
            Address1Field.SendKeys(street);
            CityField.SendKeys(city);
            PostcodeField.SendKeys(postalCode);
            MobilePhoneField.SendKeys(mobilePhone);

            //Clear the last field and send new text
            IWebElement myAddress = _driver.FindElement(By.Id("alias"));
            myAddress.Clear();
            myAddress.SendKeys("My address");

            //Select from the dropdown list
            IWebElement element = StateDropdown;
            SelectElement select = new SelectElement(element);
            select.SelectByText("Alabama");

            //Click Submitt Account
            SubmitAccountBtn.Click();
        }

       
    }
}
