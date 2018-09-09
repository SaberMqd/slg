using slg.Round;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using Unity.Transforms2D;
using UnityEngine;

public class GameProcessManager
{
	private static GameProcessManager _GameProcessManager = null;
	private static Entity entity;
	private static EntityManager entityManager;
	private static EntityArchetype archetype;

	public static GameProcessManager GetInstance()
	{
		if (_GameProcessManager == null)
		{
			Intialize();
		}
		return _GameProcessManager;
	}

	public static Entity GetEntity()
	{
		if (_GameProcessManager == null)
		{
			Intialize();
		}
		return entity;
	}

	public static EntityManager GetEntityManager()
	{
		if (_GameProcessManager == null)
		{
			Intialize();
		}
		return entityManager;
	}


	[RuntimeInitializeOnLoadMethod]
	private static void OnRuntimeMethodLoad()
	{
		GetInstance();
		Debug.Log("GameProcessManager Initialize Complite");
	}

	private static void Intialize()
	{
		_GameProcessManager = new GameProcessManager();
		entityManager = World.Active.GetOrCreateManager<EntityManager>();
		archetype = entityManager.CreateArchetype(
		typeof(CurrentSelection),
		typeof(CampArray),
		typeof(CurrentPhase),
		typeof(Step)
		);
		entity = entityManager.CreateEntity(archetype);
		entityManager.SetComponentData<CurrentPhase>(entity, new CurrentPhase() { value = new slg.character.attribute.Camp() { campType = 0 } });
	}
	//[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	//public static void Initalize()
	//{



	//}
}