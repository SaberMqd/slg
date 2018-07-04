using System.Collections.Generic;
using Unity.Entities;
using XML.Paraser;
using XML.Data;
using UnityEngine;
using slg.map;

[UpdateAfter(typeof(FileCreateMapSystem))]
public class RandomCreateMapSystem : ComponentSystem
{
    struct Group {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<RandomCreateMap> mapData;
    }

    [Inject] Group group;

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            if (MapDataManager.GetInstance().isCreated) {
                PostUpdateCommands.DestroyEntity(group.entity[i]);
                continue;
            }
        }
    }
}
