using Unity.Entities;
using slg.Round;

public class PhaseStepSystem : ComponentSystem
{
	struct Group
	{
		public EntityArray entity;
		public ComponentDataArray<Step> stepData;
	}

	[Inject] Group group;

	protected override void OnUpdate()
	{
		Entity e = group.entity[0];
		Step currenStep = group.stepData[0];
		switch ((int)currenStep.value)
		{
			case 0:
				currenStep.value += 1;
				break;
			case 1:
				currenStep.value += 1;
				break;
			case 2:
				currenStep.value = 0;
				EntityManager.CreateEntity(typeof(RoundOverData));
				break;
		}
		EntityManager.SetComponentData(e, currenStep);
	}
}