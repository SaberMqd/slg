using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class MenueInput : MonoBehaviour {

    private void Start() {
    }

    public void AddPreMoveComponent()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        bool isExist = false;
        var entity =  GameObjectEntityManager.GetInstance().GetCurrentEntity(out isExist);
        if (isExist)
        {
            if (entityManager.HasComponent(entity, typeof(PreMoveData))) {
                return;
            }
            entityManager.AddComponentData(entity, new PreMoveData { });
        }
    }

    public void AddPreAttackComponent()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        bool isExist = false;
        var entity = GameObjectEntityManager.GetInstance().GetCurrentEntity(out isExist);
        Debug.Log(entity);
        if (isExist)
        {
            if (entityManager.HasComponent(entity, typeof(PreAttackData)))
            {
                return;
            }
            entityManager.AddComponentData(entity, new PreAttackData { });
        }
    }

    public void AddPreSkillComponent()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        bool isExist = false;
        var entity = GameObjectEntityManager.GetInstance().GetCurrentEntity(out isExist);
        if (isExist)
        {
            if (entityManager.HasComponent(entity, typeof(PreSkillData)))
            {
                return;
            }
            entityManager.AddComponentData(entity, new PreSkillData { });
        }
    }

    public void AddPreOverComponent()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        entityManager.CreateEntity(typeof(RoundOverData));
    }


}
