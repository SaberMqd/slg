using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace map
{
    [Serializable]
    public class CrustalBlockCollection
    {
        //[XmlArray("Items"), XmlArrayItem("CrustalBlock")]
        [XmlArray("Items")]
        public CrustalBlock[] Items { get; set; }
    }


    [Serializable]
    public class CrustalBlock
    {
        public int BlockIndex { set; get; }

        /*
        public String BlockName { set; get; }
        public int BlockSize { set; get; }
        public int SuperBlock { set; get; }
        public int MinCoverSize { set; get; }
        public int MaxCoverSize { set; get; }
        public int MarginDistance { set; get; }
        public int MinDistance { set; get; }
        */
    }
    public class Terrain
    {
       
    }
}
