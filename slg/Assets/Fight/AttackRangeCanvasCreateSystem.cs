using Unity.Entities;
using Unity.Transforms;

public class AttackRangeCanvasCreateSystem : ComponentSystem
{
    struct Group
    {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<CreateAttackRangeData> data;
    }

    [Inject] Group group;
    EntityManager em = World.Active.GetOrCreateManager<EntityManager>();

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            var pos = em.GetComponentData<Position>(group.entity[i]);
            AttackRangeManager.GetInstance().CreateAttackRange((int)pos.Value.x, (int)pos.Value.y, (int)pos.Value.z, 0);
            PostUpdateCommands.RemoveComponent<CreateAttackRangeData>(group.entity[i]);
        }

    }
}
