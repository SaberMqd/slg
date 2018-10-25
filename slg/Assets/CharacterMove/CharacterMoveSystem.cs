using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace slg.move
{

    [UpdateAfter(typeof(CreateMoveRangeSystem))]
    public class CharacterMoveSystem : ComponentSystem
    {
        struct Group
        {
            public int Length;
            public EntityArray entity;
            public ComponentDataArray<MoveTo> posdata;
        }

        [Inject] Group group;
        EntityManager em = World.Active.GetOrCreateManager<EntityManager>();

        protected override void OnUpdate()
        {
            for (int i = 0; i < group.Length; i++)
            {
                em.SetComponentData(group.entity[i], group.posdata[i].position);
                PostUpdateCommands.RemoveComponent<MoveTo>(group.entity[i]);
            }
        }

		private List<Vector3> MovePathNav(Vector3 position, int ActionPoint)
		{
            /*
			MapDataManager mdm = MapDataManager.GetInstance();
			List<Vector3> moveRange = new List<Vector3>();
			List<Vector3> tempRange = new List<Vector3>();
			List<Vector3> leastCost = new List<Vector3>();
			List<Vector3> testRange = new List<Vector3> { position };
			List<float> expendedAP = new List<float> { ActionPoint };
			Vector3 testPos = new Vector3();
			float testAP = 0f;
			Entity testGround = new Entity();
			int mobility = EntityManager.GetComponentData<BaseCharacterAttribute>(mover.entity[0]).Mobility;
			while (ActionPoint > 0)
			{
				List<Vector3> tempRange = new List<Vector3> { lastRange[i] + new Vector3(-1, 0, 0), lastRange[i] + new Vector3(1, 0, 0), lastRange[i] + new Vector3(0, 0, -1), lastRange[i] + new Vector3(0, 0, 1) };
				MoveCostCalculat(EntityManager.GetComponentData<PassCost>(testGround).Value, mobility)
			}

			Debug.Log(moveRange.Count);
			return moveRange；
            */
            return new List<Vector3>();
		}
	}
}