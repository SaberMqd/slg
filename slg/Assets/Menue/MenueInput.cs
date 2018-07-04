using slg.controler;
using Unity.Entities;
using UnityEngine;

public class MenueInput : MonoBehaviour {

    private void Start() {
    }

    public void AddPreMoveComponent()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        var e = entityManager.CreateEntity(typeof(PreAction));
        entityManager.SetComponentData(e, new PreAction { actionType = ActionType.ACTION_MOVE });
    }

    public void AddPreAttackComponent()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        var e = entityManager.CreateEntity(typeof(PreAction));
        entityManager.SetComponentData(e, new PreAction { actionType = ActionType.ACTION_ATTACK });
    }

    public void AddPreSkillComponent()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        var e = entityManager.CreateEntity(typeof(PreAction));
        entityManager.SetComponentData(e, new PreAction { actionType = ActionType.ACTION_SKILL });
    }

    public void AddPreOverComponent()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        entityManager.CreateEntity(typeof(RoundOverData));
    }


}
