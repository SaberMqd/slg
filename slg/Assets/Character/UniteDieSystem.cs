using slg;
using slg.character.attribute;
using slg.Unite;
using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

public class UniteDieSystem : ComponentSystem
{
	struct Dead
	{
		public int Length;
		public EntityArray entity;
		public ComponentDataArray<Camp> campData;
		public ComponentDataArray<UniteDie> uniteDieData;
	}

	[Inject] Dead d_Group;

	struct allUnite
	{
		public int Length;
		public ComponentDataArray<UniteAlive> uniteAliveData;
		public ComponentDataArray<Camp> campData;
	}

	[Inject] allUnite a_Group;

	protected override void OnUpdate()
	{
		if (d_Group.Length > 0)
		{
		    Camp deadCamp = new Camp();
			List<Camp> aliveCampList = ConvertDataType.ComponentDataArrayToList(a_Group.campData);
			bool campEliminate;

			//Check dead unite is the last menber of a camp or not
			for (int i = 0; i < d_Group.Length; i++)
			{
				deadCamp = d_Group.campData[i];
				if (!aliveCampList.Contains(deadCamp))
				{
					campEliminate = true;
				}
				else
				{
					campEliminate = false;
				}
				if (campEliminate = true)
				{
					Entity e = EntityManager.CreateEntity();
					CampEliminate ce = new CampEliminate();
					ce.Value = deadCamp;
					EntityManager.AddComponentData<CampEliminate>(e, ce);
				}
			}
		}
		
	}
}
