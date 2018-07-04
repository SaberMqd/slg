using Unity.Entities;
using UnityEngine;

using slg.controler;
using Unity.Transforms;

namespace slg.move {

    public class CreateMoveRangeSystem : ComponentSystem
    {

        struct Group
        {
            public int Length;
            public EntityArray entity;
            public ComponentDataArray<PreMove> data;
        }

        [Inject] Group group;
        EntityManager em = World.Active.GetOrCreateManager<EntityManager>();

        protected override void OnUpdate()
        {
            for (int i = 0; i < group.Length; i++)
            {
                var pos = em.GetComponentData<Position>(group.entity[i]);
                MoveRangeManager.GetInstance().CreateMoveRange((int)pos.Value.x, (int)pos.Value.y,(int)pos.Value.z, 3);
                PostUpdateCommands.RemoveComponent<PreMove>(group.entity[i]);
            }

        }
    }
}

