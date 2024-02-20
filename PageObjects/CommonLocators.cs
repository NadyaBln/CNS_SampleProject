using OpenQA.Selenium;

namespace CNS_SampleProject.PageObjects
{
    public class CommonLocators
    {
        //locators 
        public static By _tableFilter = By.CssSelector(".oxd-table-filter");
        public static By _button_Add = By.CssSelector(".orangehrm-header-container .oxd-button--medium");
        public static By _button_Submit = By.XPath("//button[@type='submit']");
        public static By _addUserContainer = By.CssSelector(".orangehrm-card-container");
        public static By _message_UserCreatedSuccess = By.CssSelector(".oxd-toast.oxd-toast--success");


    }
}
