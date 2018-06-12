using Unity.Entities;

// ΚµΜε
public struct CountData : IComponentData
{
    public int count;
}

public struct CountData1 : IComponentData
{
    public int count1;
    public UnityEngine.Transform t;
}

/*
public struct MoveRangeCanves : IComponentData
{
    public int count1;
    public UnityEngine.Transform t;
}
*/