using CNS_SampleProject.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CNS_SampleProject.PageObjects
{
    public class PIMPage : CommonLocators
    {
        IWebDriver _driver;

        public static By _field_firstname = By.XPath("//input[@name='firstName']");
        public static By _field_middlename = By.XPath("//input[@name='middleName']");
        public static By _field_lastname = By.XPath("//input[@name='lastName']");

        public static By _imageInput = By.XPath("//input[@type='file']");
        public PIMPage(IWebDriver driver) 
        {
            _driver = driver;
        }

        public PIMPage ClickAddButton()
        {

            _driver.FindElement(_button_Add).Click();
            WaitUntil.WaitFor(_addUserContainer, _driver);

            return this;
        }

        /// <summary>
        /// parameter middleName is optional
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
            _driver.FindElement(_imageInput).SendKeys(Base.path + "Images\\sun.jpg");
            return this;
        }

        public PIMPage ClickSave()
        {
            _driver.FindElement(_button_Submit).Click();
            return this;
        }

        public PIMPage CheckIsUserCreated()
        {
            Thread.Sleep(2000);
            Assert.That(CommonFunctions.IsElementPresent(_message_UserCreatedSuccess, _driver), "Employee is not created");
            return this;
        }
    }
}
