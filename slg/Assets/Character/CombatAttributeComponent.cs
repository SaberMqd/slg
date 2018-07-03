using System;
using Unity.Entities;

namespace slg.character.attribute
{
    [Serializable]
    public struct CombatAttribute : IComponentData
    {
        public int Attack;
        public int HitRate;
        public int Cri;
        public int Dodge;
    }

    public class CombatAttributeComponent : ComponentDataWrapper<CombatAttribute> { }
}
