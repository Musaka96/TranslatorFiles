using System;
using System.Xml;
using System.Linq;

namespace Translate.MethodClasses
{
    public static class XMLTranslationHandler
    {
        private static readonly string logLocation = 
            System.AppContext.BaseDirectory + "/Content/TranslationsLog.xml";

        private static readonly string dataLocation = 
            System.AppContext.BaseDirectory + "/Content/Translations.xml";


        public static string FindTranslationInData(string key)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(dataLocation);

            foreach (XmlNode xmlNode in xmlDoc.SelectNodes("//translations/translation"))
            {
                if (xmlNode.FirstChild.Name != "from"
                    || xmlNode.FirstChild.InnerText != key)
                {
                    continue;
                }

                return xmlNode.FirstChild.NextSibling.InnerText;
            }

            return null;
        }

        public static void WriteTranslationLog(string from, string to)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(logLocation);

            XmlNodeList translations = xmlDoc.SelectNodes("//translations");
            foreach (XmlNode translation in translations)
            {
                XmlNode userNode = xmlDoc.CreateElement("translation");

                XmlAttribute attribute = xmlDoc.CreateAttribute("timestamp");
                attribute.Value = DateTime.Now.ToString();
                userNode.Attributes.Append(attribute);

                XmlNode fromNode = xmlDoc.CreateElement("from");
                fromNode.InnerText = from;
                XmlNode toNode = xmlDoc.CreateElement("to");
                toNode.InnerText = to;

                userNode.AppendChild(fromNode);
                userNode.AppendChild(toNode);

                translation.AppendChild(userNode);
            }

            xmlDoc.Save(logLocation);
        }

        public static void WriteTranslationData(string from, string to)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(dataLocation);

            XmlNodeList translations = xmlDoc.SelectNodes("//translations");
            foreach (XmlNode translation in translations)
            {
                XmlNode userNode = xmlDoc.CreateElement("translation");

                XmlNode fromNode = xmlDoc.CreateElement("from");
                fromNode.InnerText = from;
                XmlNode toNode = xmlDoc.CreateElement("to");
                toNode.InnerText = to;

                userNode.AppendChild(fromNode);
                userNode.AppendChild(toNode);

                translation.AppendChild(userNode);
            }

            xmlDoc.Save(dataLocation);
        }
    }
}