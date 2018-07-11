using System;
using Unity.Entities;

namespace slg.character.attribute
{
    [Serializable]
    public struct BaseAttribute : IComponentData
    {
        //public int Lv;
        public int MinHP;
        public int MaxHP;

        public int MinStr;
        public int MaxStr;

        public int MinMag;
        public int MaxMag;

        public int MinSki;
        public int MaxSki;

        public int MinSpd;
        public int MaxSpd;

        public int MinLuc;
        public int MaxLuc;

        public int MinDef;
        public int MaxDef;

        public int MinMdef;
        public int MaxMdef;

        //public int XP;
        //public int Movement;
        //public int HP;
        //public int Power;
        //public int MP;
       // public int Skill;
       // public int Speed;
       // public int Lucky;
       // public int Defense;
       // public int MagicResistance;
    }

    public class BaseAttributeComponent : ComponentDataWrapper<BaseAttribute> { }
}
