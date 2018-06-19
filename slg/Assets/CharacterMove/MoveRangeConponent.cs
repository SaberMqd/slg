using Unity.Entities;

public struct CreateMoveRangeData : IComponentData { }

public struct DestroyMoveRangeData : IComponentData { }

public struct MovePosition : IComponentData {
    public float X;
    public float Y;
    public float Z;
}


