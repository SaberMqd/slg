using Unity.Entities;

[UpdateAfter(typeof(CreateMoveRangeSystem))]
public class CharacterMoveSystem : ComponentSystem
{
    struct Group
    {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<MovePosition> data;
        public ComponentDataArray<CharacterCoordinate> posdata;
    }

    [Inject] Group group;
    EntityManager em = World.Active.GetOrCreateManager<EntityManager>();

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            bool isExist = false;
            var go = GameObjectEntityManager.GetInstance().GetCurrentGameObject(out isExist);
            if (isExist) {
                go.transform.position = new UnityEngine.Vector3(group.data[i].X, group.data[i].Y,group.data[i].Z);
            }
            var pos = group.posdata[i];
            pos.X = group.data[i].X;
            pos.Y = group.data[i].Y;
            pos.Z = group.data[i].Z;
            group.posdata[i] = pos;
            PostUpdateCommands.RemoveComponent<MovePosition>(group.entity[i]);
        }
    }
}
