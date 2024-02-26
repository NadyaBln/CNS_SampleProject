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

        public static string IDGenerator()
        {
            Random random = new Random();
            string id = random.Next(10, 9999).ToString();
            return id;
        }
    }
}
