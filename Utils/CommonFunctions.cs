using OpenQA.Selenium;
using System.Text;

namespace CNS_SampleProject.Utils
{
    internal class CommonFunctions
    {
        public static bool IsElementPresent(By by, IWebDriver _driver)
        {
            try
            {
                IWebElement displayed = _driver.FindElement(by);
                if (displayed != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static string StringGenerator(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            char offset = lowerCase ? 'A' : 'a';
            const int letteroffset = 26;

            var random = new Random();
            for(var  i = 0; i < size; i++)
            {
                var @char=(char)random.Next(offset, offset + letteroffset);
                builder.Append(@char);  
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}
