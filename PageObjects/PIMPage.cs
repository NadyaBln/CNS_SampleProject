using CNS_SampleProject.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CNS_SampleProject.PageObjects
{
    public class PIMPage : BasePage
    {
        IWebDriver _driver;

        public static By _field_firstname = By.XPath("//input[@name='firstName']");
        public static By _field_middlename = By.XPath("//input[@name='middleName']");
        public static By _field_lastname = By.XPath("//input[@name='lastName']");
        public static By _errorMessage_idAlreadyExists = By.CssSelector(".oxd-input.oxd-input--active.oxd-input--error");

        public static By _imageInput = By.XPath("//input[@type='file']");
        public PIMPage(IWebDriver driver) :base(driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Enters given full name. Parameter middleName is optional
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="middleName"></param>
        /// <returns></returns>
        public PIMPage EnterEmployeeFullName(string firstName, string lastName, string? middleName=null)
        {
            _driver.FindElement(_field_firstname).SendKeys(firstName);
            _driver.FindElement(_field_lastname).SendKeys(lastName);

            if (middleName != null)
                 _driver.FindElement(_field_middlename).SendKeys(middleName);
           
            return this;
        }

        public PIMPage UploadImage()
        {
            _driver.FindElement(_imageInput).SendKeys(Config.path + "Images\\sun.jpg");
            return this;
        }
        
        public PIMPage CheckIsEmployeeIDAvailable()
        {
            if (_driver.FindElements(_errorMessage_idAlreadyExists).Count > 0)
            {

            }
            return this;
        }

        public PIMPage CheckIsEmployeeCreated()
        {
            Thread.Sleep(3000);
            Assert.That(CommonFunctions.IsElementPresent(_message_UserCreatedSuccess, _driver), "Employee is not created");
            return this;
        }
    }
}
