using CNS_SampleProject.PageObjects;
using CNS_SampleProject.Resources;
using CNS_SampleProject.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static CNS_SampleProject.Utils.UserRoles;

namespace CNS_SampleProject.Tests
{
    public class Tests_Web
    {
        IWebDriver _driver;

        [SetUp]
        public void StartBrowser()
        {
            AccountCreds.GetAccountCredsFromFile();
            ChromeOptions options = new ChromeOptions();

            options.AddArguments("--start-maximized");
            options.AddArguments("--disable-notifications");

            _driver = new ChromeDriver(options);
        }

        [Test]
        public void Login()
        {
            new LoginPage(_driver)
                .GoToURL()
                .EnterCredentials()
                .ClickSubmitButton()
                .CheckIsUserLoggedIn();
        }

        [Test]
        public void AddUser_AdminRole()
        {
            string usernameInThisTest = Generator.UsernameGenerator();

            //existing test method reuse
            Login();

            new MainPage(_driver)
                .OpenAdminPage()
                .ClickAddButton()
                .SelectUserRole(UserRole.Admin)
                .EnterEmployeeName("Vasya")
                .SelectStatus()
                .EnterUsername(usernameInThisTest)
                .EnterPassword(Base.stongPassword)
                .ClickSave()
                .CheckIsUserCreated();
        }
        [Test]
        public void AddEmployee()
        {
            string nameInThisTest = Generator.NameGenerator();

            //existing test method reuse
            Login();

            new MainPage(_driver)
                .OpenPIMPage()
                .ClickAddButton()
                .EnterEmployeeFullName(nameInThisTest, nameInThisTest)
                .UploadImage()
                .ClickSave()
                .CheckIsUserCreated();
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
