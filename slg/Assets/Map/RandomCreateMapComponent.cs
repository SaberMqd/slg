using System;
using Unity.Entities;


namespace slg.map {

    [Serializable]
    public struct RandomCreateMap : IComponentData
    {
        public int Type;
    }

    public class RandomCreateMapComponent : ComponentDataWrapper<RandomCreateMap> { }
}
