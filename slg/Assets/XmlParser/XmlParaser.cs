using System;
using System.IO;
using System.Xml.Serialization;

namespace map.creater
{
    public class XmlParaser
    {
        public XmlParaser(String xmlPath)
        {
            //crustalBlockNodes = new List<CrustalBlock>();
            CBCollection = new CrustalBlockCollection();
            try
            {
                /*FileStream fs = new FileStream(xmlPath, FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(CrustalBlock));
                CrustalBlock cb = xs.Deserialize(fs) as CrustalBlock;*/

                FileStream fs = new FileStream(xmlPath, FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(CrustalBlockCollection));
                CBCollection = xs.Deserialize(fs) as CrustalBlockCollection;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //public List<CrustalBlock> GetAllCrustalBlock() {
        //    return crustalBlockNodes;
        //}

        public CrustalBlockCollection GetAllCrustalBlock()
        {
            return CBCollection;
        }

        // private List<CrustalBlock> crustalBlockNodes;
        private CrustalBlockCollection CBCollection;
    }
}
