using UnityEngine;
using Unity.Entities;

public class Main : MonoBehaviour
{
    EntityManager entityManager;

    void Start()
    {
        entityManager = World.Active.GetOrCreateManager<EntityManager>();
        var mapEntity = entityManager.CreateEntity(typeof(MapType));
        entityManager.SetComponentData<MapType>(mapEntity, new MapType { Type = 1 });
    }

    private void Update()
    {
       
    }

}