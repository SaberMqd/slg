using UnityEngine;
using Unity.Entities;


public class Main : MonoBehaviour
{
    EntityManager entityManager;

    void Start()
    {
        entityManager = World.Active.GetOrCreateManager<EntityManager>();
        var mapEntity = entityManager.CreateEntity(typeof(MapType));
        entityManager.SetComponentData<MapType>(mapEntity, new MapType { Type = 1 });
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "character_1001")
                {
                    var ch = hit.collider.gameObject.GetComponentInParent<CharacterBehaviour>();
                    ch.PreAction();
                }
                if (hit.collider.gameObject.name == "range_cell")
                {
                    var ch = hit.collider.gameObject.GetComponent<MoveCellBehaviour>();
                    ch.MoveTo();
                }
                if (hit.collider.gameObject.name == "attack_cell")
                {
                    var ch = hit.collider.gameObject.GetComponent<AttackCellBehaviour>();
                    ch.AttackTo();
                }
            }
            //右键撤销。 以及点击无用的区域也要撤销。

        }
    }

}