using CNS_SampleProject.PageObjects;
using CNS_SampleProject.Resources;
using CNS_SampleProject.Utils;
using OpenQA.Selenium;

namespace CNS_SampleProject
{
    public class LoginPage
    {
        readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        //locators
        public static readonly By _loginContainer = By.CssSelector(".orangehrm-login-container");
        public static readonly By _loginField = By.XPath("//input[@name='username']");
        public static readonly By _passField = By.XPath("//input[@name='password']");
        public static readonly By _submitBtn = By.XPath("//button[@type='submit']");

        public LoginPage GoToURL()
        {
            try
            {
                _driver.Url = Base.SiteLoginURL;
                WaitUntil.WaitFor(_loginContainer, _driver);
            }
            catch(TimeoutException ex)
            {
                throw new TimeoutException(ex.Message);
            }
            return this;
        }

        public LoginPage EnterCredentials()
        {
            _driver.FindElement(_loginField).SendKeys(AccountCreds.adminUserLogin);
            _driver.FindElement(_passField).SendKeys(AccountCreds.adminUserPass);

            return this;
        }

        public MainPage ClickSubmitButton()
        {
            _driver.FindElement(_submitBtn).Click();
            Thread.Sleep(2000);
            
            return new MainPage(_driver);
        }
    }
}