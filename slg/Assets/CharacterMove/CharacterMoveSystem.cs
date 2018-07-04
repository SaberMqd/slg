using Unity.Entities;
using Unity.Transforms;

namespace slg.move
{

    [UpdateAfter(typeof(CreateMoveRangeSystem))]
    public class CharacterMoveSystem : ComponentSystem
    {
        struct Group
        {
            public int Length;
            public EntityArray entity;
            public ComponentDataArray<MoveTo> posdata;
        }

        [Inject] Group group;
        EntityManager em = World.Active.GetOrCreateManager<EntityManager>();

        protected override void OnUpdate()
        {
            for (int i = 0; i < group.Length; i++)
            {
                em.SetComponentData(group.entity[i], group.posdata[i].position);
                PostUpdateCommands.RemoveComponent<MoveTo>(group.entity[i]);
            }
        }
    }
}