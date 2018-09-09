using Unity.Entities;
using slg.controler;
using slg.Round;
using slg.character.attribute;
using slg;
using UnityEngine;

public class ClickExecutSystem : ComponentSystem
{
	struct Group
	{
		public int Length;
		public EntityArray entity;
		public ComponentDataArray<MouseClick> mouseClick;
	}
	[Inject] Group group;

	protected override void OnUpdate()
	{
		
		if (group.Length > 0)
		{
			Entity gpm = GameProcessManager.GetEntity();
			
			
			for (int i = 0; i < group.Length; i++)
			{
				
				Entity e = group.entity[i];
				MouseClick mc = group.mouseClick[i];

				switch (mc.Value)
				{
					case 0:
						switch ((int)EntityManager.GetComponentData<ObjectType>(e).Value)
						{
							case 0:
								//如果是玩家单位并且是玩家行动回合
								if (EntityManager.HasComponent<Player>(e) && (EntityManager.GetComponentData<CurrentPhase>(gpm).value.campType == EntityManager.GetComponentData<Camp>(e).campType))
								{
									//行动菜单
									Debug.Log("true");
									EntityManager.AddComponent(e, typeof(PreAction));
									EntityManager.SetComponentData(e, new PreAction { actionType = ActionType.ACTION_SELECT });
									EntityManager.SetComponentData(gpm, new CurrentSelection { Value = e });
									Debug.Log("Unite Add PreAction");
									Debug.Log(EntityManager.GetComponentData<PreAction>(e).actionType);
									Debug.Log(e.GetHashCode());
									Debug.Log(EntityManager.GetComponentData<CurrentSelection>(gpm).Value.GetHashCode());
								}
								else
								{
									//显示单位信息
									EntityManager.AddComponent(e, typeof(DisplayInfo));
								}

								break;

							case 1:
								Entity cs = EntityManager.GetComponentData<CurrentSelection>(gpm).Value;
								break;
						}
						break;
					case 1:

						break;
					case 2:

						break;
				}
				PostUpdateCommands.RemoveComponent<MouseClick>(e);
			}
		}
	}
}
