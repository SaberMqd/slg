using Unity.Entities;
using UnityEngine;

namespace slg.map {

    public struct MapType : IComponentData
    {
        public int Type;
    }
}


public struct MapDeleteType : IComponentData
{
    public int Type;
}