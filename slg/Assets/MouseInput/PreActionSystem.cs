//using slg.move;
//using Unity.Collections;
//using Unity.Entities;
//using Unity.Transforms;

//namespace slg.controler
//{

//    public class PreActionSystem : ComponentSystem
//    {
//        struct Group
//        {
//            public int Length;
//            public EntityArray entity;
//            public ComponentDataArray<PreAction> data;
//        }

//        //[ReadOnly]
//        static private Entity currentEntity;

//        private ActionType actionType = ActionType.ACTION_NONE;

//        [Inject] Group group;

//        protected override void OnUpdate()
//        {
//            if (group.Length == 0) {
//                return;
//            }

//            switch (group.data[0].actionType) {
//                case ActionType.ACTION_ATTACK:
//                    if (actionType == ActionType.ACTION_SELECT)
//                    {
//                        actionType = ActionType.ACTION_ATTACK;
//                        EntityManager.AddComponent(currentEntity, typeof(PreAttack));
//                        PostUpdateCommands.DestroyEntity(group.entity[0]);

//                    }
//                    else
//                    {
//                        UnityEngine.Debug.Log("reset");

//                    }
//                    break;
//                case ActionType.ACTION_MOVE:

//                    if (actionType == ActionType.ACTION_SELECT)
//                    {
//                        actionType = ActionType.ACTION_MOVE;
//                        if (EntityManager.Exists(currentEntity)) {
//                            PostUpdateCommands.AddComponent(currentEntity, new PreMove{ });
//                        }
//                        PostUpdateCommands.DestroyEntity(group.entity[0]);
//                    }
//                    else
//                    {
//                        UnityEngine.Debug.Log("reset");


//                    }
//                    break;
//                case ActionType.ACTION_SELECT:
//                    if (actionType == ActionType.ACTION_NONE)
//                    {
//                        currentEntity = group.entity[0];
//                        actionType = ActionType.ACTION_SELECT;
//                        PostUpdateCommands.RemoveComponent<PreAction>(group.entity[0]);
//                    }
//                    else {
//                        //执行撤销操作
//                        UnityEngine.Debug.Log("reset");
//                        PostUpdateCommands.RemoveComponent<PreAction>(group.entity[0]);
//                    }
//                    break;
//                case ActionType.ACTION_SKILL:
//                    if (actionType == ActionType.ACTION_SELECT)
//                    {
//                        actionType = ActionType.ACTION_SKILL;
//                        EntityManager.AddComponent(currentEntity, typeof(PreSkill));
//                        PostUpdateCommands.DestroyEntity(group.entity[0]);
//                    }
//                    else
//                    {
//                        UnityEngine.Debug.Log("reset");
//                    }
//                    break;
//                case ActionType.ACTION_MOVE_TO:
//                    if (actionType == ActionType.ACTION_MOVE)
//                    {
//                        var pos = EntityManager.GetComponentData<Position>(group.entity[0]);
//                        EntityManager.AddComponentData(currentEntity, new MoveTo { position = pos });
//                        actionType = ActionType.ACTION_NONE;
//                        PostUpdateCommands.DestroyEntity(group.entity[0]);
//                    }
//                    else
//                    {
//                        UnityEngine.Debug.Log("reset");
//                    }

//                    break;
//            }

           

//        }


//    }
//}