using Unity.Entities;
using UnityEngine;

public class CreateMoveRangeSystem : ComponentSystem
{

    struct Group
    {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<PreMoveData> data;
    }

    [Inject] Group group;
    EntityManager em = World.Active.GetOrCreateManager<EntityManager>();

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            var pos = em.GetComponentData<CharacterCoordinate>(group.entity[i]);
            MoveRangeManager.GetInstance().CreateMoveRange((int)pos.X, (int)pos.Y,(int)pos.Z, 0);
            PostUpdateCommands.RemoveComponent<PreMoveData>(group.entity[i]);
        }

    }
}
