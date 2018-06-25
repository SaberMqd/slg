using Unity.Entities;


public class AttackRangeCanvasCreateSystem : ComponentSystem
{
    struct Group
    {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<PreAttackData> data;
    }

    [Inject] Group group;
    EntityManager em = World.Active.GetOrCreateManager<EntityManager>();

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            var pos = em.GetComponentData<CharacterCoordinate>(group.entity[i]);
            AttackRangeManager.GetInstance().CreateAttackRange((int)pos.X, (int)pos.Y, (int)pos.Z, 0);
            RoundManager.GetInstance().isAttacking = true;
            PostUpdateCommands.RemoveComponent<PreAttackData>(group.entity[i]);
        }

    }
}
