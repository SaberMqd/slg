using Unity.Entities;

[UpdateAfter(typeof(MapCreateSystem))]
public class CharacterCreateSystem : ComponentSystem
{
    struct Group
    {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<CreateCharaterData> data;
    }

    [Inject] Group group;
    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            //创建角色
            UnityEngine.Debug.Log("创建角色了");
            PostUpdateCommands.DestroyEntity(group.entity[i]);
            break;
        }
    }
}
