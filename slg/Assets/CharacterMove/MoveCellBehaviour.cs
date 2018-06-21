using Unity.Entities;
using UnityEngine;

public class MoveCellBehaviour : MonoBehaviour {

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    public void MoveTo() {
        var em = World.Active.GetOrCreateManager<EntityManager>();
        bool isExist = false;
        var entity = GameObjectEntityManager.GetInstance().GetCurrentEntity(out isExist);
        if (isExist)
        {
            em.AddComponentData(entity, new MovePosition { X = transform.position.x, Y = transform.position.y, Z = transform.position.z });
        }
    }
}
