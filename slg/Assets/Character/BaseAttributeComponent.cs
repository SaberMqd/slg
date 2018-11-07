using System;
using Unity.Entities;

namespace slg.character.attribute
{
    [Serializable]
    public struct BaseAttribute : IComponentData
    {
        public int Lv;       
        public int XP;
        public int Movement;
        public int HP;
        public int Power;
        public int MP;
        public int Skill;
        public int Speed;
        public int Lucky;
        public int Defense;
        public int MagicResistance;
    }

    public class BaseAttributeComponent : ComponentDataWrapper<BaseAttribute> { }
}
