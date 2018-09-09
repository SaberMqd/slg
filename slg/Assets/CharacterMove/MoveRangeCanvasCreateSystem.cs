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

        struct g_Mover
        {
            public int Length;
            public EntityArray entity;
            public ComponentDataArray<PreMove> preMove;
        }

        [Inject] g_Mover mover;

		struct g_Blocker
		{
			public int Length;
			public EntityArray entity;
			public ComponentDataArray<Blocker> blocker;
		}

		[Inject] g_Blocker blocker;

		//struct g_Ground
		//{
		//	public int Length;
		//	public EntityArray entity;
		//	public ComponentDataArray<Ground> blocker;
		//}
		protected override void OnUpdate()
        {
            if (mover.Length == 0) {
                return;
            }

            var pos = EntityManager.GetComponentData<Position>(mover.entity[0]);

            var moveRange = CreateMoveRange(new float3(pos.Value.x, pos.Value.y, pos.Value.z), 100);
			MoveRangeDisplay(moveRange);
			
            UpdateInjectedComponentGroups();
            PostUpdateCommands.RemoveComponent<PreMove>(mover.entity[0]);
        }

		private List<float3> CreateMoveRange(float3 position, int ActionPoint)
		{
			MapDataManager mdm = MapDataManager.GetInstance();
			List<float3> moveRange = new List<float3>();
			List<float3> testRange = new List<float3>();
			List<float3> lastRange = new List<float3> { position };
			List<float> surplusAP = new List<float> { ActionPoint };
			List<float> testAP = new List<float>();
			Entity testGround = new Entity();
			int mobility = EntityManager.GetComponentData<BaseCharacterAttribute>(mover.entity[0]).Mobility;
			while (ActionPoint > 0)
			{
				for (int i = 0; i < lastRange.Count; i++)
				{
					List<float3> tempRange = new List<float3> { lastRange[i] + new float3(-1, 0, 0), lastRange[i] + new float3(1, 0, 0), lastRange[i] + new float3(0, 0, -1), lastRange[i] + new float3(0, 0, 1) };
					foreach (var item in tempRange)
					{
						testGround = mdm.FindGroundCell(item);
						float ap = surplusAP[i] - MoveCostCalculat(EntityManager.GetComponentData<PassCost>(testGround).Value, mobility);
						if (!moveRange.Contains(item) && EntityManager.GetComponentData<Passable>(testGround).Value && ap >= 0)
						{
							moveRange.Add(item);
							testAP.Add(ap);
							testRange.Add(item);
						}
					}
				}
				lastRange = testRange;
				testRange.Clear();
				surplusAP = testAP;
				testAP.Clear();
			}

			Debug.Log(moveRange.Count);
			return moveRange;
		}



		public int MoveCostCalculat(int groundCost, int mobility)
		{
			int cost = groundCost / mobility;
			return cost;

		}

		//private List<int3> MoveRangeFilt(int3 position, int stepCount, List<int3> blockCells)
		//{
		//	List<int3> finalMoveRange;
		//	for (int i = 0; i < stepCount; i++)
		//	{
		//		testPosition = position
		//		position
		//	}
		//	return finalMoveRange;
		//}

		private void MoveRangeDisplay(List<float3> moveRange)
		{
			
			foreach (var i in moveRange)
			{
				Debug.Log(i.x +" " + i.y + " " + i.z);
				var go = GameObject.Instantiate(Resources.Load<GameObject>("MoveCell"));
				var e = go.GetComponent<GameObjectEntity>().Entity;
				Debug.Log(e.GetHashCode());
				EntityManager.SetComponentData(e, new Position { Value = new float3 { x = i.x, y = i.y, z = i.z } });
				EntityManager.AddComponent(e, typeof(MoveDes));
			}			
		}
    }
}

