using Unity.Entities;

public class CreateMoveRangeSystem : ComponentSystem
{

    struct Group
    {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<CountData> countData;
        //public ComponentDataArray<CountData1> countData1;
    }

    struct CanvesGroup {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<CountData> countData;
    }

    [Inject] CanvesGroup canvesGroup; // 注入请求的ComponentData
    [Inject] Group group; // 注入请求的ComponentData

    protected override void OnUpdate()
    {
        //如果点击了移动按钮，并且鼠标点击某个角色上， 则显示其可移动范围。
        //
    }
}
