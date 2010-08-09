using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SummerofXNA.Classes.DataLayer
{
    public class XMLHandler
    {
        private string _filename;
        public string FileName
        {
            get
            {
                XMLHandler handler = new XMLHandler("config.xml");
                return _filename;
            }
            set
            {
                _filename = value;
            }
        }

        public XMLHandler(string filename)
        {
            _filename = filename;
        }

        public void NewElement(string parent, List<string[]> attribute, List<string[]> children)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Content/Data/" + _filename);
            XmlElement newel = doc.CreateElement(parent);

            if (attribute.Count > 0)
            {
                for (int i = 0; i < attribute.Count; i++)
                {
                    XmlAttribute attri = doc.CreateAttribute(attribute[i][0]);
                    attri.Value = attribute[i][1];
                    newel.Attributes.Append(attri);
                }
            }
            if (children.Count > 0)
            {
                for (int i = 0; i < children.Count; i++)
                {
                    XmlElement child = doc.CreateElement(children[i][0]);
                    child.AppendChild(doc.CreateTextNode(children[i][1]));
                    newel.AppendChild(child);
                    doc.AppendChild(newel);
                }

            }
            doc.Save("Content/Data/" + _filename);

        }
        public void ModifyElementChildren(string parent, List<string[]> children)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Content/Data/" + _filename);

            foreach (XmlNode element in doc)
            {
                if (element.Name == parent)
                {
                    foreach (XmlNode node in element)
                    {
                        for (int i = 0; i < children.Count; i++)
                        {
                            if (node.Name == children[i][0])
                            {
                                node.Value = children[i][1];
                            }
                        }
                    }
                }
            }
            doc.Save("Content/Data/" + _filename);

        }
        public List<XmlNode> ReadElement(string parent)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Content/Data/" + _filename);
            List<XmlNode> backList = new List<XmlNode>();
            foreach (XmlNode element in doc)
            {
                if (element.Name == parent)
                {
                    foreach (XmlNode node in element)
                    {
                        backList.Add(node);
                    }
                }
            }
            return backList;
        }
    }
}