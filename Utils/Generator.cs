namespace CNS_SampleProject.Utils
{
    internal class Generator
    {
        public static string UsernameGenerator()
        {
            string username = "test" + CommonFunctions.StringGenerator(4);
            return username;
        }

        public static string NameGenerator()
        {
            string username = CommonFunctions.StringGenerator(5);
            return username;
        }
    }
}
