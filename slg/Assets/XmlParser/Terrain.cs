using System;
using System.Xml.Serialization;

namespace map.creater
{
    [Serializable]
    public class CrustalBlockCollection
    {
        //[XmlArray("Items"), XmlArrayItem("CrustalBlock")]
        [XmlArray("Items")]
        public Cell[] Items { get; set; }
    }

    [Serializable]
    public class Cell
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int Height { set; get; }
        public int Width { set; get; }
        public int PassEfficiency { set; get; }
        public int AtkAdd { set; get; }
        public int DefAdd { set; get; }
        public int EvAdd { set; get; }
        public int HPRecovery { set; get; }
        public int AtkTime { set; get; }
        public int MotherCell { set; get; }
        public int MinCent { set; get; }
        public int MaxCent { set; get; }
        public int MinDistance { set; get; }
        public int SameDistance { set; get; }
    }

    [Serializable]
    public class MapCell
    {
        public int X { set; get; }
        public int Y { set; get; }
        public int ID { set; get; }

    }

    public class Terrain
    {
       
    }
}
