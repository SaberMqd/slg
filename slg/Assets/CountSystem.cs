using Unity.Entities;

public class CountSystem : ComponentSystem
{
    // System所需的ComponentData列表
    struct Group
    {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<CountData> countData;
        //public ComponentDataArray<CountData1> countData1;
    }

    [Inject] Group group; // 注入请求的ComponentData

    // 调用每一帧
    protected override void OnUpdate()
    {
        UnityEngine.Debug.Log(group.Length);
        for (int i = 0; i < group.Length; i++)
        {
            var countData = group.countData[i];
            countData.count++;
            group.countData[i] = countData;
            PostUpdateCommands.DestroyEntity(group.entity[i]);
            break;
        }
        
    }
}