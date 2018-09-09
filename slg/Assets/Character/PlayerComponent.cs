using Unity.Entities;

public struct Player : IComponentData
{

}
public class PlayerComponent : ComponentDataWrapper<Player> { }