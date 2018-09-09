using Unity.Entities;
using UnityEngine;

public class KeyInputSystem : ComponentSystem
{
	private EntityManager em = World.Active.GetOrCreateManager<EntityManager>();
	private float speed = 0.3f;
	private bool isOverlook = true;

	protected override void OnUpdate()
    {
		var cameraCtrler = GameObject.Find("CameraController");
		var cameraCtrl = cameraCtrler.GetComponent<CameraControl>();

		if (Input.GetKey("down"))
        {
			if(cameraCtrl.cameraPosition.z > 1)
			{
				cameraCtrl.cameraPosition += -cameraCtrl.cameraForward * speed;
			}
        }
        if (Input.GetKey("up"))
        {
			if (cameraCtrl.cameraPosition.z < 20)
			{
				cameraCtrl.cameraPosition += cameraCtrl.cameraForward * speed;
			}
        }
        if (Input.GetKey("left"))
        {
			if (cameraCtrl.cameraPosition.x > 1)
			{
				cameraCtrl.cameraPosition += -cameraCtrl.cameraRight * speed;
			}
        }
        if (Input.GetKey("right"))
        {
			if (cameraCtrl.cameraPosition.x < 23)
			{
				cameraCtrl.cameraPosition += cameraCtrl.cameraRight * speed;
			}
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
			if(cameraCtrl.stadiaT < 1)
			{
				cameraCtrl.stadiaT += 0.1f;
			}			
			else
			{
				cameraCtrl.stadiaT = 1;
			}
		}
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
			if (cameraCtrl.stadiaT > 0)
			{
				cameraCtrl.stadiaT += -0.1f;
			}
			else
			{
				cameraCtrl.stadiaT = 0;
			}
		}

		if (Input.GetKeyDown("q"))
		{
			if (cameraCtrl.cameraSwitch < 1)
			{
				cameraCtrl.cameraSwitch += 1;
			}
			else
			{
				cameraCtrl.cameraSwitch = 0;
			}
		}

        if (Input.GetKeyDown("w"))
        {
			cameraCtrl.cameraRotate += new Vector3(0,90,0);
			cameraCtrl.cameraForward = Vector3.Cross(Vector3.up, cameraCtrl.cameraForward);
			cameraCtrl.cameraRight = Vector3.Cross(Vector3.up, cameraCtrl.cameraForward);

		}


    }
}
