using Unity.Entities;

namespace slg.controler
{

    public enum ActionType {
        ACTION_NONE = 0,
        ACTION_SELECT,
        ACTION_MOVE,
        ACTION_ATTACK,
        ACTION_SKILL,
    }

    public struct PreAction : IComponentData {
        public ActionType actionType;
    }

    public struct PreMove : IComponentData { }
    public struct PreAttack : IComponentData { }
    public struct PreSkill : IComponentData { }

}
