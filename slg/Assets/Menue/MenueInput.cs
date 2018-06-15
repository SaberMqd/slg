using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class MenueInput : MonoBehaviour {

    private GameObject buttonMoveObj;
    private GameObject buttonAttackObj;
    private GameObject buttonSkillObj;

    private void Start() {
        Debug.Log("Start");

        buttonMoveObj = GameObject.Find("ButtonMove");
        if (buttonMoveObj) {
            Debug.Log("buttonMoveObj");
        }
        buttonMoveObj.GetComponent<Button>().onClick.AddListener(AddPreMoveComponent);

        buttonAttackObj = GameObject.Find("ButtonAttack");
        buttonAttackObj.GetComponent<Button>().onClick.AddListener(AddPreAttackComponent);

        buttonSkillObj = GameObject.Find("ButtonSkill");
        buttonSkillObj.GetComponent<Button>().onClick.AddListener(AddPreSkillComponent);
    }

    //EntityManager entityManager = World.Active.GetOrCreateManager<EntityManager>();
    //Entity e;

    public void AddPreMoveComponent() {
        //Debug.Log("AddPreMoveComponent");
        //entityManager.AddComponent(e, typeof(CreateMoveRangeData));
    }

    public void AddPreAttackComponent()
    {
        Debug.Log("AddPreAttackComponent");

        //entityManager.AddComponent(e, typeof(CreateMoveRangeData));
    }

    public void AddPreSkillComponent()
    {
        Debug.Log("AddPreSkillComponent");

        //entityManager.AddComponent(e, typeof(CreateMoveRangeData));
    }


    /**************************/
    public void AddPreActionComponent() {
        //entityManager.AddComponent(e, typeof(PreActionData));
    }


    public void AddMoveComponent()
    {
        //entityManager.AddComponent(e, typeof(CreateMoveRangeData));
    }

    public void AddAttackComponent()
    {
        //entityManager.AddComponent(e, typeof(CreateMoveRangeData));
    }

}
