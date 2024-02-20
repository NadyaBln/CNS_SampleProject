using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace CNS_SampleProject.Utils
{
    internal class WaitUntil
    {
        private readonly IWebDriver _driver;
       
        public static void WaitFor(By locator, IWebDriver _driver)
        {
            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(locator));
                new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch(WebDriverTimeoutException)
            {
                throw new TimeoutException("Element was not loaded");
            }
        }
    }
}
