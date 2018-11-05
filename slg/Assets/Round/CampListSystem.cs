using Unity.Entities;
using slg.Round;
using slg.character.attribute;
using slg;
using System.Collections.Generic;

public class CampListSystem : ComponentSystem
{
	struct Message
	{
		public int Length;
		public EntityArray entity;
		public ComponentDataArray<CampEliminate> campEliminate;
	}
	[Inject] Message message;

	protected override void OnUpdate()
	{
		if (message.Length > 0)
		{
            Entity gpm = GameProcessManager.current_entity;
            CampArray campArray = EntityManager.GetSharedComponentData<CampArray>(gpm);
			List<Camp> newList = ConvertDataType.NativeArrayToList(campArray.Value);

			for (int i = 0; i < message.Length; i++)
			{
				if (newList.Contains(message.campEliminate[i].Value))
				{
					newList.Remove(message.campEliminate[i].Value);
				}
				EntityManager.DestroyEntity(message.entity[i]);
			}
			campArray.Value = ConvertDataType.ListToNativeArray<Camp>(newList);
			EntityManager.SetSharedComponentData(gpm, campArray);
		}

	}
				
			
}
