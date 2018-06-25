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
    public bool isEnemy = false;

    Entity entity;

    void Start () {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
        var archetype = entityManager.CreateArchetype(
            typeof(CombatAttributes),
            typeof(BaseCharacterAttribute),
            typeof(CharacterCoordinate));

        BaseCharacterAttribute baseCharacterAttribute;
        CombatAttributes combatAttributes;
        CharacterCoordinate pos = new CharacterCoordinate();
        entity = entityManager.CreateEntity(archetype);
        if (isEnemy) {
            entityManager.AddComponent(entity, typeof(IsEnemyData));
        }
        if (useDefault) {
            baseCharacterAttribute = new BaseCharacterAttribute { Lv = 1, XP = 0, Movement = 3, HP = 100, Power = 2, MP = 100, Skill = 1, Speed = 1, Lucky = 1, Defense = 1, MagicResistance = 1 };
            combatAttributes = new CombatAttributes { Attack = 1, HitRate = 1, Cri = 1, Dodge = 1, };
        }
        else
        {
            baseCharacterAttribute = new BaseCharacterAttribute { Lv = Lv, XP = XP, Movement = Movement, HP = HP, Power = Power, MP = MP, Skill = Skill, Speed = Speed, Lucky = Lucky, Defense = Defense, MagicResistance = MagicResistance };
            combatAttributes = new CombatAttributes { Attack = Attack, HitRate = HitRate, Cri = Cri, Dodge = Dodge, };
        }

        transform.position = new Vector3((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);

        pos.X = transform.position.x;
        pos.Y = transform.position.y;
        pos.Z = transform.position.z;

        entityManager.SetComponentData(entity, baseCharacterAttribute);
        entityManager.SetComponentData(entity, combatAttributes);
        entityManager.SetComponentData(entity, pos);

        GameObjectEntityManager.GetInstance().SetAddGameObjectAndEntity(out id, gameObject , entity);
        gameObject.name = "character_1001";
	}

    public void PreAction() {
        //Debug.Log(gameObject.GetComponent<CharacterBehaviour>());
        if (isEnemy != RoundManager.GetInstance().IsEnemyRound()) {
            return;
        }
        var em = World.Active.GetOrCreateManager<EntityManager>();
        var gm = GameObjectEntityManager.GetInstance();
        if (!em.HasComponent(entity, typeof(PreActionData))) {
            em.AddComponent(entity, typeof(PreActionData));
        }
        gm.SetCurrentEntity(entity);
        gm.SetCurrentGameObject(gameObject);
    }
}
