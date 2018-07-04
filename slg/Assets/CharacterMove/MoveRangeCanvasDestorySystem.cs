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
            public ComponentDataArray<DestroyMoveRangeData> data;
        }

        [Inject] Group group;

        protected override void OnUpdate()
        {
            for (int i = 0; i < group.Length; i++)
            {
                MoveRangeManager.GetInstance().DestroyMoveRange();
                PostUpdateCommands.RemoveComponent<DestroyMoveRangeData>(group.entity[i]);
            }

        }
    }
}