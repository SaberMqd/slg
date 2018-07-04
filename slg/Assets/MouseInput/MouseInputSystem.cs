using slg.controler;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class MouseInputSystem : ComponentSystem
{

    private EntityManager em = World.Active.GetOrCreateManager<EntityManager>();

    protected override void OnUpdate()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "Character_1001")
                {
                    var e = hit.collider.gameObject.GetComponent<GameObjectEntity>();
                    if (!em.HasComponent(e.Entity, typeof(PreAction))) {
                        em.AddComponent(e.Entity, typeof(PreAction));
                        em.SetComponentData(e.Entity, new PreAction { actionType = ActionType.ACTION_SELECT });
                    }
                }
                else if (hit.collider.gameObject.name == "MoveCell")
                {
                    var e = hit.collider.gameObject.GetComponent<GameObjectEntity>();
                    var pos = em.GetComponentData<Position>(e.Entity);
                    em.CreateEntity(typeof(Position), typeof(PreAction));
                    em.SetComponentData(e.Entity, new Position { Value = pos.Value });
                    em.SetComponentData(e.Entity, new PreAction { actionType = ActionType.ACTION_MOVE_TO });
                }
                else if(hit.collider.gameObject.name == "mapcell")
                {
                }
            }
        }

        //右键撤销。
        if (Input.GetMouseButtonDown(1))
        {
        }
        
    }
}
