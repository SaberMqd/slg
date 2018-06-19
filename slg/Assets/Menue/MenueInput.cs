using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class MenueInput : MonoBehaviour {

    private GameObject buttonMoveObj;
    private GameObject buttonAttackObj;
    private GameObject buttonSkillObj;

    private void Start() {
        buttonMoveObj = GameObject.Find("ButtonMove");
        buttonMoveObj.GetComponent<Button>().onClick.AddListener(AddPreMoveComponent);
        buttonAttackObj = GameObject.Find("ButtonAttack");
        buttonAttackObj.GetComponent<Button>().onClick.AddListener(AddPreAttackComponent);
        buttonSkillObj = GameObject.Find("ButtonSkill");
        buttonSkillObj.GetComponent<Button>().onClick.AddListener(AddPreSkillComponent);
    }

    public void AddPreMoveComponent() {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        bool isExist = false;
        var entity =  GameObjectEntityManager.GetInstance().GetCurrentEntity(out isExist);
        if (isExist)
        {
            entityManager.AddComponentData(entity, new PreMoveData { });
        }
    }

    public void AddPreAttackComponent()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        bool isExist = false;
        var entity = GameObjectEntityManager.GetInstance().GetCurrentEntity(out isExist);
        if (isExist)
        {
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
            entityManager.AddComponentData(entity, new PreSkillData { });
        }
    }

}
