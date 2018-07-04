using Unity.Collections;
using Unity.Entities;

namespace slg.controler
{

    public class PreActionSystem : ComponentSystem
    {
        struct Group
        {
            public int Length;
            public EntityArray entity;
            public ComponentDataArray<PreAction> data;
        }

        [ReadOnly]
        private Entity currentEntity;

        private ActionType actionType = ActionType.ACTION_NONE;

        [Inject] Group group;

        protected override void OnUpdate()
        {
            if (group.Length == 0) {
                return;
            }

            switch (group.data[0].actionType) {
                case ActionType.ACTION_ATTACK:
                    if (actionType == ActionType.ACTION_SELECT)
                    {
                        actionType = ActionType.ACTION_ATTACK;
                        EntityManager.AddComponent(currentEntity, typeof(CreateAttackRangeData));
                    }
                    break;
                case ActionType.ACTION_MOVE:

                    if (actionType == ActionType.ACTION_SELECT)
                    {
                        actionType = ActionType.ACTION_MOVE;
                        EntityManager.AddComponent(currentEntity, typeof(slg.move.CreateMoveRangeData));
                    }
                    break;
                case ActionType.ACTION_SELECT:
                    if (actionType == ActionType.ACTION_NONE)
                    {
                        currentEntity = group.entity[0];
                        actionType = ActionType.ACTION_SELECT;
                    }
                    else {
                        //执行撤销操作
                    }
                    break;
                case ActionType.ACTION_SKILL:
                    if (actionType == ActionType.ACTION_SELECT)
                    {
                        actionType = ActionType.ACTION_SKILL;
                        EntityManager.AddComponent(currentEntity, typeof(CreateSkillData));
                    }
                    break;
            }

            EntityManager.RemoveComponent<PreAction>(group.entity[0]);

        }


    }
}