using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TMAuto
{
    class IOHandler
    {
        public static void Save(string path, object obj)
        {
            Type type = obj.GetType();
            string name = type.Name;
            var properties = type.GetProperties();

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.NewLineOnAttributes = true;

            using (XmlWriter wr = XmlWriter.Create(path, xmlWriterSettings))
            {
                wr.WriteStartDocument();
                wr.WriteStartElement(name);

                for (int i = 0; i < properties.Count(); i++)
                {
                    var property = properties[i];
                    string value = property.GetValue(obj, null).ToString();

                    if (property.PropertyType == type)
                    {
                        continue;
                    }

                    wr.WriteElementString(property.Name, value);
                }

                wr.WriteEndElement();
                wr.WriteEndDocument();
            }
        }

        public static void Load(string path, object obj)
        {
            Type type = obj.GetType();

            if (!File.Exists(path))
            {
                Save(path, obj);
                return;
            }

            var els = XDocument.Load(path).Root.Elements();
            
            for (int i = 0; i < els.Count(); i++)
            {
                var el = els.ElementAt(i);
                var property = type.GetProperty(el.Name.ToString());
                var value = el.Value;
                property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
            }
        }
    }
}
