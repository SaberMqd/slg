using Unity.Entities;

namespace slg.controler
{

    public enum ActionType {
        ACTION_NONE = 0,
        ACTION_SELECT,
        ACTION_MOVE,
        ACTION_ATTACK,
        ACTION_SKILL,
        ACTION_MOVE_TO,
    }

    public struct PreAction : IComponentData {
        public ActionType actionType;
    }

    public struct PreMove : IComponentData { }
    public struct PreAttack : IComponentData { }
    public struct PreSkill : IComponentData { }
    public struct MoveOver : IComponentData { }
    public struct AttackOver : IComponentData { }
    public struct SkillOver : IComponentData { }

}
