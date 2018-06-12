using Unity.Entities;

public struct AttackMagic : IComponentData
{
    public bool MagicAbility;
}

public struct AttackPhysics : IComponentData
{
    public bool PhysicsAbility;
}
