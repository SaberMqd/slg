using slg.move;
using Unity.Entities;
using Unity.Transforms;

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

        private ActionType actionType = ActionType.ACTION_NONE;

        [Inject] Group group;

        protected override void OnUpdate()
        {
            if (group.data[0].actionType == ActionType.ACTION_ATTACK && actionType == ActionType.ACTION_SELECT) {
                actionType = ActionType.ACTION_ATTACK;
                EntityManager.AddComponent(GameProcessManager.current_entity, typeof(PreAttack));
                PostUpdateCommands.DestroyEntity(group.entity[0]);
            } else if (group.data[0].actionType == ActionType.ACTION_MOVE && actionType == ActionType.ACTION_SELECT) {
                actionType = ActionType.ACTION_MOVE;
                if (EntityManager.Exists(GameProcessManager.current_entity))
                {
                    PostUpdateCommands.AddComponent(GameProcessManager.current_entity, new PreMove{ });
                }
                PostUpdateCommands.DestroyEntity(group.entity[0]);
            }
            else if (group.data[0].actionType == ActionType.ACTION_SELECT && actionType == ActionType.ACTION_NONE)
            {
                actionType = ActionType.ACTION_SELECT;
                GameProcessManager.current_entity = group.entity[0];
                PostUpdateCommands.RemoveComponent<PreAction>(group.entity[0]);
            }
            else if (group.data[0].actionType == ActionType.ACTION_SKILL && actionType == ActionType.ACTION_SELECT)
            {
                actionType = ActionType.ACTION_SKILL;
                EntityManager.AddComponent(GameProcessManager.current_entity, typeof(PreSkill));
                PostUpdateCommands.DestroyEntity(group.entity[0]);
            }
            else if (group.data[0].actionType == ActionType.ACTION_MOVE_TO && actionType == ActionType.ACTION_SELECT)
            {
                var pos = EntityManager.GetComponentData<Position>(group.entity[0]);
                EntityManager.AddComponentData(GameProcessManager.current_entity, new MoveTo { position = pos });
                actionType = ActionType.ACTION_NONE;
            }
            else {
                GameProcessManager.current_entity = new Entity();
            }
        }


    }
}