using Unity.Entities;
using UnityEngine;

using slg.controler;
using Unity.Transforms;
using Unity.Collections;
using Unity.Mathematics;
using System.Collections.Generic;
using slg.character.attribute;
using static MoveRangeManager;

namespace slg.move {

    public class CreateMoveRangeSystem : ComponentSystem
    {
        struct GMover
        {
            public int Length;
            public EntityArray entity;
            public ComponentDataArray<PreMove> preMove;
        }

        [Inject] GMover mover;

		protected override void OnUpdate()
        {
            var e = mover.entity[0];
            var pos = EntityManager.GetComponentData<Position>(e);
            var passValue = EntityManager.GetComponentData<BaseAttribute>(e).Movement;
            Debug.Log(pos.Value);
            CreateMoveRange((int)pos.Value.x, (int)pos.Value.z, (int)pos.Value.y,passValue);
            EntityManager.RemoveComponent<PreMove>(e);
            UpdateInjectedComponentGroups();
        }

        void CreateMoveRange(int x, int y, int z, int passValue)
        {
            var area = BacktrackingAlg.GetAccessibleArea(new Node { x = x, y = y }, passValue);
            UnityEngine.Debug.Log("areas num is " + area.Count);
            foreach (var c in area)
            {
                var t = c.Key.Split('_');
                var prefab = Resources.Load<GameObject>("MoveCell");
                GameObject terr_go = GameObject.Instantiate(prefab);
                var e = terr_go.GetComponent<GameObjectEntity>();
                EntityManager.SetComponentData(e.Entity, new Position
                {
                    Value = new float3(int.Parse(t[0]), 0, z = int.Parse(t[1]))
                });
            }
            return;
        }

    }
}

