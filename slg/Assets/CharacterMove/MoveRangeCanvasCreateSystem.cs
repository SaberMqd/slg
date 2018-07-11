using Unity.Entities;
using UnityEngine;

using slg.controler;
using Unity.Transforms;
using Unity.Collections;
using Unity.Mathematics;

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

        protected override void OnUpdate()
        {
            if (group.Length == 0) {
                return;
            }
            var pos = EntityManager.GetComponentData<Position>(group.entity[0]);
            //MoveRangeManager.GetInstance().CreateMoveRange((int)pos.Value.x, (int)pos.Value.y,(int)pos.Value.z, 3);
            //GameObject.Instantiate(Resources.Load<GameObject>("MoveCell"));
            var go = GameObject.Instantiate(Resources.Load<GameObject>("MoveCell"));
            var e = go.GetComponent<GameObjectEntity>().Entity;
            EntityManager.SetComponentData(e,new Position { Value = new float3{  x = pos.Value.x, y = pos.Value.y, z = pos.Value.z+1 } });
            EntityManager.AddComponent(e, typeof(MoveDes));
            Debug.LogFormat("l;alalla{0} {1} {2}",pos.Value.x, pos.Value.y, pos.Value.z);
            UpdateInjectedComponentGroups();
            PostUpdateCommands.RemoveComponent<PreMove>(group.entity[0]);

        }
    }
}

