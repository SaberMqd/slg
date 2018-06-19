using Unity.Entities;
using UnityEngine;

[UpdateAfter(typeof(MapCreateSystem))]
public class CharacterCreateSystem : ComponentSystem
{
    struct Group
    {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<CreateCharaterData> data;

    }

    EntityManager entityManager = World.Active.GetOrCreateManager<EntityManager>();

    [Inject] Group group;

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            GameObject gameObject = GameObject.Instantiate(Resources.Load<GameObject>("character_1001"));
            var coordinate = entityManager.GetComponentData<CharacterCoordinate>(group.entity[i]);
            gameObject.transform.position = new Vector3(coordinate.X, coordinate.Z, coordinate.Y);
            PostUpdateCommands.RemoveComponent<CreateCharaterData>(group.entity[i]);
        }
    }
}
