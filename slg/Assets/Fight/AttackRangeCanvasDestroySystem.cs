using Unity.Entities;

[UpdateAfter(typeof(AttackSystem))]
public class AttackRangeCanvasDestroySystem : ComponentSystem
{

    struct Group
    {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<DestroyAttackRange> data;
    }

    [Inject] Group group;

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            AttackRangeManager.GetInstance().DestroyAttackRange();
            PostUpdateCommands.RemoveComponent<DestroyAttackRange>(group.entity[i]);
        }
    }
}
