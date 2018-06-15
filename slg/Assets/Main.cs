﻿using UnityEngine;
using Unity.Entities;


public class Main : MonoBehaviour
{
    EntityManager entityManager;

    void Start()
    {
        entityManager = World.Active.GetOrCreateManager<EntityManager>();
        var mapEntity = entityManager.CreateEntity(typeof(MapType));
        entityManager.SetComponentData<MapType>(mapEntity, new MapType { Type = 1 });

        var archetype = entityManager.CreateArchetype(
            typeof(CreateCharaterData),
            typeof(CharacterCoordinate),
            typeof(CombatAttributes),
            typeof(BaseCharacterAttribute));

        var e1 = entityManager.CreateEntity(archetype);
        entityManager.SetComponentData(e1, new BaseCharacterAttribute { Lv = 1, XP = 0, Movement = 3, HP = 100, Power = 2, MP = 100, Skill = 1, Speed = 1, Lucky = 1, Defense = 1, MagicResistance = 1 });
        entityManager.SetComponentData(e1, new CombatAttributes { Attack = 1,HitRate = 1,Cri = 1, Dodge = 1, });
        entityManager.SetComponentData(e1, new CharacterCoordinate { X = 5, Y = 6, Z = 0 });
      
        var e2 = entityManager.CreateEntity(archetype);
        entityManager.SetComponentData(e2, new BaseCharacterAttribute { Lv = 1, XP = 0, Movement = 3, HP = 100, Power = 2, MP = 100, Skill = 1, Speed = 1, Lucky = 1, Defense = 1, MagicResistance = 1 });
        entityManager.SetComponentData(e2, new CombatAttributes { Attack = 1, HitRate = 1, Cri = 1, Dodge = 1, });
        entityManager.SetComponentData(e2, new CharacterCoordinate { X = 5, Y = 11, Z = 0 });

    }

    private void Update()
    {
    }
}