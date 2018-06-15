using Unity.Entities;
using UnityEngine;

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
            var g = GameObject.Find("moverange");
            if (g) {
                GameObject.Destroy(g);
            }

            PostUpdateCommands.RemoveComponent<CreateMoveRangeData>(group.entity[i]);
            PostUpdateCommands.RemoveComponent<DestroyMoveRangeData>(group.entity[i]);
        }

    }
}
