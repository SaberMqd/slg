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
		Entity gpm = GameProcessManager.GetEntity();
		var em = GameProcessManager.GetEntityManager();
		Entity cs = em.GetComponentData<CurrentSelection>(gpm).Value;
		Debug.Log(em.GetComponentData<PreAction>(cs));

		em.AddComponent(cs, type);
		Debug.Log(type);
	}
}
