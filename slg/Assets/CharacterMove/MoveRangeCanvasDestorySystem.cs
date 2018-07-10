using slg.controler;
using Unity.Entities;
using UnityEngine;

namespace slg.move
{

    [UpdateAfter(typeof(CharacterMoveSystem))]
    public class MoveRangeCanvasDestorySystem : ComponentSystem
    {

        struct Group
        {
            public int Length;
            public EntityArray entity;
            public ComponentDataArray<MoveOver> data;
        }

        [Inject] Group group;

        protected override void OnUpdate()
        {
            if (group.Length == 0) {
                return;
            }
            var entites = EntityManager.GetAllEntities();
            foreach (var e in entites) {
                if (EntityManager.HasComponent<MoveDes>(e)) {
                    EntityManager.DestroyEntity(e);
                }
            }
            entites.Dispose();
            //MoveRangeManager.GetInstance().DestroyMoveRange();
            PostUpdateCommands.RemoveComponent<MoveOver>(group.entity[0]);
            UpdateInjectedComponentGroups();
        }
    }
}