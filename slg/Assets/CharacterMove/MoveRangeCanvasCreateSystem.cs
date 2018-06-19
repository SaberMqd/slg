using Unity.Entities;
using UnityEngine;

public class CreateMoveRangeSystem : ComponentSystem
{

    struct Group
    {
        public int Length;
        public EntityArray entity;
        public ComponentDataArray<PreMoveData> data;
    }

    [Inject] Group group;
    EntityManager em = World.Active.GetOrCreateManager<EntityManager>();

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            /*
             创建移动范围
             */
            GameObject move_cell = GameObject.Instantiate(Resources.Load<GameObject>("range_cell"));
            var pos = em.GetComponentData<CharacterCoordinate>(group.entity[i]);
            move_cell.transform.position = new Vector3(pos.X, pos.Y+0.1f, pos.Z+1);

            GameObject move_cell1 = GameObject.Instantiate(Resources.Load<GameObject>("range_cell"));
            var pos1 = em.GetComponentData<CharacterCoordinate>(group.entity[i]);
            move_cell1.transform.position = new Vector3(pos1.X, pos1.Y + 0.1f, pos1.Z-1);

            GameObject move_cell2 = GameObject.Instantiate(Resources.Load<GameObject>("range_cell"));
            var pos2 = em.GetComponentData<CharacterCoordinate>(group.entity[i]);
            move_cell2.transform.position = new Vector3(pos2.X-1, pos2.Y + 0.1f, pos2.Z);

            GameObject move_cell3 = GameObject.Instantiate(Resources.Load<GameObject>("range_cell"));
            var pos3 = em.GetComponentData<CharacterCoordinate>(group.entity[i]);
            move_cell3.transform.position = new Vector3(pos3.X+1, pos3.Y + 0.1f, pos3.Z);

            PostUpdateCommands.RemoveComponent<PreMoveData>(group.entity[i]);
        }

    }
}
