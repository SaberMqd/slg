using Unity.Entities;
using UnityEngine;

public struct MapType : IComponentData
{
    public int Type;
}

public struct MapDeleteType : IComponentData
{
    public int Type;
}