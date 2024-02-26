using CNS_SampleProject.Utils;
using OpenQA.Selenium;

namespace CNS_SampleProject.PageObjects
{
    /// <summary>
    /// All methods in this class use Generics because they are universal and can be used in several classes.
    /// </summary>
    public class BasePage 
    {
        IWebDriver _driver;

        //locators 
        public static By _tableFilter = By.CssSelector(".oxd-table-filter");
        public static By _button_Add = By.CssSelector(".orangehrm-header-container .oxd-button--medium");
        public static By _button_Submit = By.XPath("//button[@type='submit']");
        public static By _addUserContainer = By.CssSelector(".orangehrm-card-container");
        public static By _message_UserCreatedSuccess = By.CssSelector(".oxd-toast.oxd-toast--success");

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        /// Can be used in classes AdminPage, PIMPage
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns></returns>
        public TPage ClickAddButton<TPage>() where TPage : BasePage
        {
            _driver.FindElement(_button_Add).Click();
            WaitUntil.WaitFor(_addUserContainer, _driver);
            return (TPage)this;
        }


        /// <summary>
        /// Can be used in classes AdminPage, PIMPage
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <returns></returns>
        public TPage ClickSave<TPage>() where TPage : BasePage
        {
            _driver.FindElement(_button_Submit).Click();
            return (TPage)this;
        }
    }

}
