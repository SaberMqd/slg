using Unity.Entities;

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
    public int X;
    public int Y;
    public int Z;
}

public struct CreateCharaterData : IComponentData { }