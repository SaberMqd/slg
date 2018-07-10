using System;
using Unity.Entities;

namespace slg.weapon.attribute
{
    [Serializable]
    public struct WeaponBaseAttribute : IComponentData
    {
        public enum RelationType {
            Str = 0,
            Mag,
        }
        public int Type;
        public RelationType Relation;

        public int Lv;

        public int MinDis;
        public int MaxDis;

        public int Atk;
        public int Hit;

        public int Kill;
        public int Evade;

        public int Str;
        public int Mag;

        public int Ski;
        public int Luc;
        public int Def;
        public int Mdef;
        public int Weight;
        public int Durability;
        public int Price;
    }

    public class WeaponBaseAttributeComponent : ComponentDataWrapper<WeaponBaseAttribute> { }
}
