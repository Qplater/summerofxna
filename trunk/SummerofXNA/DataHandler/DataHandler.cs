using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using SummerofXNA.DataHandler.ContentStructures;

namespace SummerofXNA.DataHandler
{
    public class DataHandler
    {
        XmlDocument xmlDoc;
        const string configURI = "Content/Data/config.xml";

        /// <summary>
        /// Loads all information from config.xml
        /// </summary>
        public List<ContentStructures.ConfigContent> LoadConfiguration() 
        {
            List<ConfigContent> configList = 
                new List<ConfigContent>();
            ConfigContent data =
                new ConfigContent();

            xmlDoc = new XmlDocument();
            xmlDoc.Load(configURI);

            XmlNode root = xmlDoc.DocumentElement;

            foreach (XmlNode itemNode in root.ChildNodes) 
            {
                data.ID = itemNode.Attributes["id"].Value;

                XmlNodeList nodeList = itemNode.ChildNodes;

                XmlNode childNode = nodeList.Item(0);
                data.ConfigName = childNode.InnerText;
                childNode = nodeList.Item(1);
                data.ConfigType = childNode.InnerText;
                childNode = nodeList.Item(2);
                data.ConfigValue = childNode.InnerText;

                configList.Add(data);
            }

            return configList;
        }

        /// <summary>
        /// Modifies an item in the config.xml configuration file
        /// </summary>
        /// <param name="modified">The configuration item that contians the modified value</param>
        public void ModifyConfigValue(ConfigContent modified) 
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(configURI);

            XmlNode root = xmlDoc.DocumentElement;

            foreach (XmlNode itemNode in root.ChildNodes) 
            {
                if (itemNode.Attributes["id"].Value == modified.ID) 
                {
                    XmlNodeList nodeList = itemNode.ChildNodes;

                    XmlNode childNode = nodeList.Item(2);
                    childNode.InnerText = modified.ConfigValue;
                }
            }
            File.Delete(configURI);
            xmlDoc.Save(configURI);
        }
    }
}
