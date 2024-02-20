using CNS_SampleProject.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using static CNS_SampleProject.Utils.UserRoles;

namespace CNS_SampleProject.PageObjects
{
    public class AdminPage : CommonLocators
    {
        IWebDriver _driver;
        //for Add User
        public static By _dropdown_UserRole = By.XPath("(//div[@class='oxd-grid-item oxd-grid-item--gutters'])[1]");
        public static By _dropdown_Status = By.XPath("//label[text()='Status']/following::div[@class='oxd-select-text-input'][1]");
        public static By _field_EmployeeName = By.XPath("//input[@data-v-75e744cd]");
        public static By _field_Username = By.XPath("//label[text()='Username']/following::input[@class='oxd-input oxd-input--active'][1]");
        public static By _field_Password = By.XPath("//label[text()='Password']/following::input[@type='password'][1]");
        public static By _field_ConfirmPassword = By.XPath("//label[text()='Confirm Password']/following::input[@type='password'][1]");

        public static By _userRoleValue_Admin = By.XPath("//div[@role='listbox']//div[@role='option'][span[text()='Admin']]");
        public static By _userRoleValue_ESS = By.XPath("//div[@role='listbox']//div[@role='option'][span[text()='ESS']]");
        public static By _statusValue_Enabled = By.XPath("//div[@role='listbox']//div[@role='option'][span[text()='Enabled']]");
       

        //for Search User 
        public static By _username = By.XPath("//label[text()='Username']/following::input[@class='oxd-input oxd-input--active']");

        public AdminPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public AdminPage ClickAddButton()
        {

            _driver.FindElement(_button_Add).Click();
            WaitUntil.WaitFor(_addUserContainer, _driver);

            return this;
        }

        public AdminPage SelectUserRole(UserRole userRole)
        {
            //open User Role dropdown
            _driver.FindElement(_dropdown_UserRole).Click();

            switch (userRole)
            {
                case UserRole.Admin:
                    WaitUntil.WaitFor(_userRoleValue_Admin, _driver);
                    _driver.FindElement(_userRoleValue_Admin).Click();
                    break;

                case UserRole.ESS:
                    WaitUntil.WaitFor(_userRoleValue_ESS, _driver);
                    _driver.FindElement(_userRoleValue_ESS).Click();
                    break;
            }
            return this;
        }

        public AdminPage EnterEmployeeName(string employeeName)
        {
            _driver.FindElement(_field_EmployeeName).SendKeys(employeeName);

            //wait till dropdown will be visible 
            Thread.Sleep(2000);

            //select existed employee
            _driver.FindElement(By.XPath($"//div[@role='listbox']//div[@role='option'][span[contains(text(),'{employeeName}')]][1]")).Click();

            return this;
        }

        public AdminPage SelectStatus()
        {
            _driver.FindElement(_dropdown_Status).Click();
            _driver.FindElement(_statusValue_Enabled).Click();
            return this;
        }

        public AdminPage EnterUsername(string username)
        {
            _driver.FindElement(_field_Username).SendKeys(username);
            return this;
        }

        public AdminPage EnterPassword(string password)
        {
            _driver.FindElement(_field_Password).SendKeys(password);
            _driver.FindElement(_field_ConfirmPassword).SendKeys(password);
            return this;
        }

        public AdminPage ClickSave()
        {
            _driver.FindElement(_button_Submit).Click();
            return this;
        }

        public AdminPage CheckIsUserCreated()
        {
            Thread.Sleep(2000);
            Assert.That(CommonFunctions.IsElementPresent(_message_UserCreatedSuccess, _driver), "User is not created");
           
            return this;
        }
    }
}
