using Unity.Entities;
using UnityEngine;

using slg.controler;
using Unity.Transforms;
using Unity.Collections;
using Unity.Mathematics;
using System.Collections.Generic;

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
            if (mover.Length == 0) {
                return;
            }
            var pos = EntityManager.GetComponentData<Position>(mover.entity[0]);
            var passValue = EntityManager.GetComponentData<BaseCharacterAttribute>(mover.entity[0]).Mobility;
            MoveRangeManager.GetInstance().CreateMoveRange((int)pos.Value.x, (int)pos.Value.y, (int)pos.Value.z, passValue);
            PostUpdateCommands.RemoveComponent<PreMove>(mover.entity[0]);
        }

    }
}

