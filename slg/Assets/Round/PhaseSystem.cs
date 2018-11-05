using Unity.Entities;
using slg.Round;

public class PhaseSystem : ComponentSystem
{
	struct Message
	{
		public int Length;
		public EntityArray entity;
		public ComponentDataArray<RoundOverData> roundOverData;
	}

	[Inject] Message m;

	protected override void OnUpdate()
	{
        Entity gpm = GameProcessManager.current_entity;
        if (EntityManager.GetSharedComponentData<CampArray>(gpm).Value.Length > 0)
		{
			Entity e = m.entity[0];
			CurrentPhase currentPhase = EntityManager.GetComponentData<CurrentPhase>(gpm);
			CampArray camplist = EntityManager.GetSharedComponentData<CampArray>(gpm);
			int index = 0;
			for (index = 0; index < camplist.Value.Length; index++)
			{
				if (currentPhase.value.campType == camplist.Value[index].campType)
				{
					break;
				}
			}

			if (index < camplist.Value.Length)
			{
				index += 1;
			}
			else
			{
				index = 0;
			}
			currentPhase.value = camplist.Value[index];
			EntityManager.DestroyEntity(e);
			EntityManager.SetComponentData(e, currentPhase);
		}
		
	}
}