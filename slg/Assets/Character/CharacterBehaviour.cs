using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class CharacterBehaviour : MonoBehaviour {

    private int id = 0;

    public int Lv = 1;
    public int XP = 0;
    public int Movement = 3;
    public int HP = 100;
    public int Power = 2;
    public int MP = 100;
    public int Skill = 1;
    public int Speed = 1;
    public int Lucky = 1;
    public int Defense = 1;
    public int MagicResistance = 1;

    public int Attack = 1;
    public int HitRate = 1;
    public int Cri = 1;
    public int Dodge = 1;

    public bool useDefault = true;

    // Use this for initialization
    void Start () {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        var archetype = entityManager.CreateArchetype(
            typeof(CombatAttributes),
            typeof(BaseCharacterAttribute));

        BaseCharacterAttribute baseCharacterAttribute;
        CombatAttributes combatAttributes;
        Entity entity = entityManager.CreateEntity(archetype);
        if (useDefault) {
            baseCharacterAttribute = new BaseCharacterAttribute { Lv = 1, XP = 0, Movement = 3, HP = 100, Power = 2, MP = 100, Skill = 1, Speed = 1, Lucky = 1, Defense = 1, MagicResistance = 1 };
            combatAttributes = new CombatAttributes { Attack = 1, HitRate = 1, Cri = 1, Dodge = 1, };
        }
        else{
            baseCharacterAttribute = new BaseCharacterAttribute { Lv = Lv, XP = XP, Movement = Movement, HP = HP, Power = Power, MP = MP, Skill = Skill, Speed = Speed, Lucky = Lucky, Defense = Defense, MagicResistance = MagicResistance };
            combatAttributes = new CombatAttributes { Attack = Attack, HitRate = HitRate, Cri = Cri, Dodge = Dodge, };
        }
        entityManager.SetComponentData(entity, baseCharacterAttribute);
        entityManager.SetComponentData(entity, combatAttributes);

        GameObjectEntityManager.GetInstance().SetAddGameObjectAndEntity(out id, gameObject , entity);
        Debug.Log("Create Character id " + id);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click() {
        Debug.Log("Create Character ClickClickClickClick " + id);

    }
}
