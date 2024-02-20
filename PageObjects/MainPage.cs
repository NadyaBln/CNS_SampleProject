using CNS_SampleProject.Utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace CNS_SampleProject.PageObjects
{
    public class MainPage 
    {
        IWebDriver _driver;

        //locators
        public static readonly By _postLoginHeader = By.CssSelector(".oxd-topbar-header-userarea");
        public static readonly By _menuItem_Admin = By.XPath("//span[text()='Admin']");
        public static readonly By _menuItem_PIM = By.XPath("//span[text()='PIM']");

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public MainPage CheckIsUserLoggedIn()
        {
            Assert.That(CommonFunctions.IsElementPresent(_postLoginHeader, _driver), "User is not logged in");
            return this;
        }

        public AdminPage OpenAdminPage()
        {
            _driver.FindElement(_menuItem_Admin).Click();
            WaitUntil.WaitFor(CommonLocators._tableFilter, _driver);    

            return new AdminPage(_driver);
        }

        public PIMPage OpenPIMPage()
        {
            _driver.FindElement(_menuItem_PIM).Click();
            WaitUntil.WaitFor(CommonLocators._tableFilter, _driver);

            return new PIMPage(_driver);
        }
    }
}
