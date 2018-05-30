using System;
using System.Xml.Serialization;

namespace xml.data
{

    [XmlRoot("Root")]
    public class ItemCollection<T> {
        [XmlArray("Items"), XmlArrayItem("Item")]
        public T[] Items { get; set; }
    }

    [Serializable]
    public class Cell
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int Height { set; get; }
        public int Width { set; get; }
        public float PassEfficiency { set; get; }
        
        public int AtkAdd { set; get; }
        public int DefAdd { set; get; }
        public int HitAdd { set; get; }
        public int EvAdd { set; get; }
        public float HPRecovery { set; get; }
        public int AtkTime { set; get; }
        public int MotherCell { set; get; }
        public float MinCent { set; get; }
        public float MaxCent { set; get; }
        public int MinDistance { set; get; }
        public int SameDistance { set; get; }
        public string Resourse { set; get; }
        
    }

    [Serializable]
    public class Terrain
    {
        public int CellID { set; get; }

        public int X { set; get; }

        public int Y { set; get; }

    }
}
