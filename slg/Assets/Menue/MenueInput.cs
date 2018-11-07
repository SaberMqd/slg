using slg.controler;
using Unity.Entities;
using UnityEngine;
public class MenueInput : MonoBehaviour {

    private void Start() {
    }
	
	public void AddPreMoveComponent()
    {
		PreAction(typeof(PreMove));
	}

    public void AddPreAttackComponent()
    {
		PreAction(typeof(PreAttack));
	}

    public void AddPreSkillComponent()
    {
		PreAction(typeof(PreSkill));
	}

    public void AddPreFinishComponent()
    {
		PreAction(typeof(RoundOverData));
	}

	private void PreAction(ComponentType type)
	{
        var em = World.Active.GetOrCreateManager<EntityManager>();
        em.AddComponent(GameProcessManager.current_entity, type);
		Debug.Log("PreAction is" + type);
	}
}
