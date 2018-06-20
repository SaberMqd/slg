using Unity.Entities;

public class RoundControlerSystem : ComponentSystem
{

    protected override void OnUpdate()
    {
        if (false) {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();
            var entity = entityManager.CreateEntity(typeof(MapDeleteType));
            entityManager.SetComponentData<MapDeleteType>(entity, new MapDeleteType { Type = 1 });
        }
    }
}