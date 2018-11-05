using slg.controler;
using Unity.Entities;
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
				var e = hit.collider.gameObject.GetComponent<GameObjectEntity>().Entity;
                EntityManager.AddComponentData(e, new PreAction { actionType = ActionType.ACTION_SELECT});
			}
		}
	}
}
