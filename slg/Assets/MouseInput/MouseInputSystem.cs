using Unity.Entities;
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
                bool isExist = false;
                var e = GameObjectEntityManager.GetInstance().GetCurrentEntity(out isExist);
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "character_1001")
                {
                    if (isExist)
                    {
                        em.AddComponent(e, typeof(DestroyMoveRangeData));
                        em.AddComponent(e, typeof(DestroyAttackRange));
                        GameObjectEntityManager.GetInstance().SetCurrentExist(false);
                    }
                    var ch = hit.collider.gameObject.GetComponentInParent<CharacterBehaviour>();
                    ch.PreAction();
                }
                else if (hit.collider.gameObject.name == "range_cell")
                {
                    em.AddComponent(e, typeof(DestroyMoveRangeData));
                    em.AddComponent(e, typeof(DestroyAttackRange));
                    var ch = hit.collider.gameObject.GetComponent<MoveCellBehaviour>();
                    ch.MoveTo();
                }
                else if (hit.collider.gameObject.name == "attack_cell")
                {
                    em.AddComponent(e, typeof(DestroyMoveRangeData));
                    em.AddComponent(e, typeof(DestroyAttackRange));
                    var ch = hit.collider.gameObject.GetComponent<AttackCellBehaviour>();
                    ch.AttackTo();
                }
                else if(hit.collider.gameObject.name == "mapcell")
                {
                    if (isExist)
                    {
                        em.AddComponent(e, typeof(DestroyMoveRangeData));
                        em.AddComponent(e, typeof(DestroyAttackRange));
                        GameObjectEntityManager.GetInstance().SetCurrentExist(false);
                    }
                }
            }
        }

        //右键撤销。
        if (Input.GetMouseButtonDown(1))
        {
            bool isExist = false;
            var e = GameObjectEntityManager.GetInstance().GetCurrentEntity(out isExist);
            if (isExist)
            {
                em.AddComponent(e, typeof(DestroyMoveRangeData));
                em.AddComponent(e, typeof(DestroyAttackRange));
                GameObjectEntityManager.GetInstance().SetCurrentExist(false);
            }
        }
    }
}
