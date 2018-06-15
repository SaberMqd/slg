using Unity.Entities;

public class CreateMoveRangeSystem : ComponentSystem
{

    struct Group
    {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<CreateMoveRangeData> data;
    }

    [Inject] Group group;

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {

        }

    }
}
