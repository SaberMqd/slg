using System;
using Unity.Entities;

namespace slg.character.attribute
{
    public enum CampType {
        Camp_A = 0,
        Camp_B,
        Camp_C,
        Camp_D,
    };

    [Serializable]
    public struct Camp : IComponentData
    {
        public CampType campType;
    }

    public class CampComponent : ComponentDataWrapper<Camp> { }
}
