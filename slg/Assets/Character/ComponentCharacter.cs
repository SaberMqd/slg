﻿using Unity.Entities;
using UnityEngine;

public struct BaseCharacterAttribute : IComponentData
{
    public int Lv;
    public int XP;
    public int Movement;
    public int HP;
    public int Power;
    public int MP;
    public int Skill;
    public int Speed;
    public int Lucky;
    public int Defense;
    public int MagicResistance;
}

public struct CombatAttributes : IComponentData
{
    public int Attack;
    public int HitRate;
    public int Cri;
    public int Dodge;
}

public struct CharacterCoordinate : IComponentData {
    public float X;
    public float Y;
    public float Z;
}

public struct CreateCharaterData : IComponentData { }

public struct IsEnemyData : IComponentData { }

public struct PreActionData : IComponentData { }

public struct PreMoveData : IComponentData { }

public struct PreAttackData : IComponentData { }

public struct PreSkillData : IComponentData { }