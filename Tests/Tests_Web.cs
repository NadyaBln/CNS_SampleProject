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
        public void AddEmployee()
        {
            string nameInThisTest = Generator.NameGenerator();

            //existing test method reuse
            Login();

            var mainPage = new MainPage(_driver);
            mainPage
                .OpenPIMPage()
                .ClickAddButton<PIMPage>()
                .EnterEmployeeFullName(Config.testName, nameInThisTest, nameInThisTest)
                .UploadImage()
                .EnterEmployeeID()
                .ClickSave<PIMPage>()
                .CheckIsEmployeeCreated();
        }

        //Please run this test after AddEmployee test.
        //Because this test needs existing Employee, but other site users could remove my employee. thanks :)
        [Test]
        public void AddUser_AdminRole()
        {
            string usernameInThisTest = Generator.UsernameGenerator();

            //existing test method reuse
            Login();

            new MainPage(_driver)
                .OpenAdminPage()
                .ClickAddButton<AdminPage>()
                .SelectUserRole(UserRole.Admin)
                .EnterEmployeeName(Config.testName)
                .SelectStatus()
                .EnterUsername(usernameInThisTest)
                .EnterPassword(Config.stongPassword)
                .ClickSave<AdminPage>()
                .CheckIsUserCreated();
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
