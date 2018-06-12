using UnityEngine;
using Unity.Entities;


public class Main : MonoBehaviour
{
    EntityManager entityManager;

    void Start()
    {
        // 获取EntityManager
        entityManager = World.Active.GetOrCreateManager<EntityManager>();

        //创建地图实体
        var mapEntity = entityManager.CreateEntity(typeof(MapType));
        entityManager.SetComponentData<MapType>(mapEntity, new MapType { Type = 1 });
    }

    private void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            var e = entityManager.CreateEntity(typeof(MapDeleteType));
            entityManager.SetComponentData<MapDeleteType>(e, new MapDeleteType { Type = 1 });

        }
    }
}