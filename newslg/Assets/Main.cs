using UnityEngine;
using Unity.Entities;

public class Main : MonoBehaviour
{
    EntityManager entityManager;
    void Start()
    {
        // 获取EntityManager
        entityManager = World.Active.GetOrCreateManager<EntityManager>();

        // 定义实体的原型
        //var sampleArchetype = entityManager.CreateArchetype(typeof(CountData),typeof(CountData1));
        //entityManager.CreateEntity(sampleArchetype);
    }

    private void Update()
    {
        if (Input.GetKeyUp("a"))
        {
            Debug.Log("a");
            entityManager.CreateEntity(typeof(CountData));
            entityManager.CreateEntity(typeof(CountData1), typeof(CountData));
        }
    }
}