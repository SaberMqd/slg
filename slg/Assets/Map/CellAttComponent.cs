using System;
using Unity.Entities;

namespace slg.map
{
    [Serializable]
    public struct CellAtt : IComponentData
    {
        public int ID;
        public int Height;
        public int Width;
        public float PassEfficiency;
        public int AtkAdd;
        public int DefAdd;
        public int HitAdd;
        public int EvAdd;
        public float HPRecovery;
        public int AtkTime;
        public int MotherCell;
        public float MinCent;
        public float MaxCent;
        public int MinDistance;
        public int SameDistance;
    }

    public class CellAttComponent : ComponentDataWrapper<CellAtt> { }
}
