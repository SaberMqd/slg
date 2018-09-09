using slg.controler;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class MouseInputSystem : ComponentSystem
{


	protected override void OnUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				Entity e = hit.collider.gameObject.GetComponent<GameObjectEntity>().Entity;
				Entity gpm = GameProcessManager.GetEntity();
				EntityManager.AddComponentData<MouseClick>(e, new MouseClick() { Value = 0 });
				EntityManager.SetComponentData<CurrentSelection>(gpm, new CurrentSelection() { Value = e });
				Debug.Log("Click:" + e.GetHashCode());


			}
		}
	}
}
