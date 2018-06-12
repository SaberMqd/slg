using Unity.Entities;
using UnityEngine;

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
            if (group.mapData[i].Type == 1)
            {
                for (int j = 0; j < 460; ++j) {
                    var g = GameObject.Find("mapcell"+j);
                    GameObject.Destroy(g);
                }
                PostUpdateCommands.DestroyEntity(group.entity[i]);
                break;
            }
        }
    }
}
