using UnityEngine;
using Unity.Entities;

public class Main : MonoBehaviour
{
    void Start()
    {
        World.Active.GetOrCreateManager<EntityManager>();
        Camera.main.transform.position = new Vector3(12, 15, 7);
    }

    private void Update()
    {
      
    }

}            