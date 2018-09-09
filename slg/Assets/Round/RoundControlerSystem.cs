//using Unity.Entities;

//public class RoundControlerSystem : ComponentSystem
//{

//    struct Group
//    {
//        public int Length;
//        public EntityArray entity;
//        public ComponentDataArray<RoundOverData> data;
//    }

//    [Inject] Group group;
//    EntityManager em = World.Active.GetOrCreateManager<EntityManager>();

//    protected override void OnUpdate()
//    {
//        for (int i = 0; i < group.Length; i++)
//        {
//            isEnemyRound = !isEnemyRound;
//			Phasemanager.GetInstance().SetEnemyRound(isEnemyRound);
//            PostUpdateCommands.DestroyEntity(group.entity[i]);
//        }
//    }

//    private bool isEnemyRound = false;
//}