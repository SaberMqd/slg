using Unity.Entities;
using UnityEngine;


namespace slg.map
{

    public class MapDestorySystem : ComponentSystem
    {
        struct Group
        {
            public int Length;
            public EntityArray entity;
            public ComponentDataArray<MapDeleteType> mapData;
        }

        [Inject] Group group;
        protected override void OnUpdate()
        {
            for (int i = 0; i < group.Length; i++)
            {
                PostUpdateCommands.DestroyEntity(group.entity[i]);
            }
        }
    }
}