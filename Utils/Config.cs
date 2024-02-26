using System.Reflection;

namespace CNS_SampleProject.Utils
{
    internal class Config
    {
        public static readonly string SiteLoginURL = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        public static readonly string stongPassword = "Test1234!";

        static readonly string? directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string path = directory + "\\Resources\\";
        public static string testName = "Vasya";
    }
}
