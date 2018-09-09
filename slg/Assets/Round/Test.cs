using slg.character.attribute;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class Test : ComponentSystem {
	struct Group
	{
		public EntityArray entity;
		public int Length;
		public ComponentDataArray<Position> positionData;
		public ComponentDataArray<Camp> campData;
	}
	[Inject] Group group;
	protected override void OnUpdate()
	{
		//if ((int)group.campData[0].campType != 2)
		//{
		//	for (int i = 0; i <= group.campData.Length; i++)
		//	{
		//		Entity e = group.entity[i];
		//		Camp camp = group.campData[i];

		//		camp.campType += 1;
		//		EntityManager.SetComponentData(e, camp);
		//	}
		//}
		//Debug.Log(group.Length);
	}
}
