using CNS_SampleProject.Utils;
using System.Xml;

namespace CNS_SampleProject.Resources
{
    internal class AccountCreds
    {
        public static string adminUserLogin = "";
        public static string adminUserPass = "";

        internal static void GetAccountCredsFromFile()
        {
            XmlDocument accDetails = new XmlDocument();
            accDetails.Load(Config.path + "AccountCreds.xml");

            XmlElement xRoot = accDetails.DocumentElement;
            foreach (XmlNode xNode in xRoot)
            {
                if (xNode.Attributes.Count > 0)
                {
                    XmlNode attribute = xNode.Attributes.GetNamedItem("type");
                    if (attribute.Value == "adminUser")
                    {
                        adminUserLogin = xNode.ChildNodes[0].InnerText;
                        adminUserPass = xNode.ChildNodes[1].InnerText;
                    }
                }
            }
        }
    }
}
