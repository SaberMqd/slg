using Unity.Entities;

public struct CreateMoveRangeData : IComponentData { }

public struct DestroyMoveRangeData : IComponentData { }

public struct MovePosition : IComponentData {
    public int X;
    public int Y;
    public int Z;
}


