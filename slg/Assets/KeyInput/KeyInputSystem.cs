using Unity.Entities;
using UnityEngine;

public class KeyInputSystem : ComponentSystem
{
    private EntityManager em = World.Active.GetOrCreateManager<EntityManager>();
    private float speed = 0.3f;
    private bool isOverlook = true;
    protected override void OnUpdate()
    {
        if (Input.GetKey("down"))
        {
            Camera.main.transform.Translate(new Vector3(0, 0, -1 * speed), Space.World);
        }
        if (Input.GetKey("up"))
        {
            Camera.main.transform.Translate(new Vector3(0, 0, 1 * speed), Space.World);
        }
        if (Input.GetKey("left"))
        {
            Camera.main.transform.Translate(new Vector3(-1 * speed, 0, 0), Space.World);
        }
        if (Input.GetKey("right"))
        {
            Camera.main.transform.Translate(new Vector3(1 * speed, 0, 0),Space.World);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 70)
                Camera.main.fieldOfView += 2;
            if (Camera.main.orthographicSize <= 20)
                Camera.main.orthographicSize += 0.5F;
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 2;
            if (Camera.main.orthographicSize >= 1)
                Camera.main.orthographicSize -= 0.5F;
        }

        if (Input.GetKeyDown("q"))
        {
            if (isOverlook) {
                Camera.main.transform.Rotate(-45, 0, 0);
                isOverlook = false;
            } else if (!isOverlook) {
                Camera.main.transform.Rotate(45, 0, 0);
                isOverlook = true;
            }
        }
        if (isOverlook && Input.GetKeyDown("w"))
        {
            Camera.main.transform.Rotate(0,0,90);
        }

    }
}
