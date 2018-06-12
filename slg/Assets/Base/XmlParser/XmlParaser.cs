using System;
using System.IO;
using System.Xml.Serialization;

namespace XML.Paraser
{
    public class XmlParaser<T> 
    {
        static public T Paraser(String xmlPath)
        {
            FileStream fs = new FileStream(xmlPath, FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(T));
            return (T)xs.Deserialize(fs);
        }
    }
}
