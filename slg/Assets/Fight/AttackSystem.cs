using Unity.Entities;

[UpdateAfter(typeof(AttackRangeCanvasCreateSystem))]
public class AttackSystem : ComponentSystem
{

    protected override void OnUpdate()
    {

    }
}
