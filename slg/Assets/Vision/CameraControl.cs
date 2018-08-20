using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Transform cameraController;
	public Transform mainCamera;
	public Transform tacticsCamera;

	public float minFOV = 5f;
	public float maxFOV = 70f;
	
	public float minSize = 2f;
	public float maxSize = 10f;

	public float stadiaT;
	public int cameraSwitch;
	public Vector3 cameraPosition;
	public Vector3 cameraRotate;
	public Vector3 cameraForward = Vector3.forward;
	public Vector3 cameraRight = Vector3.right;

	Camera mCC;
	Camera tCC;
	float CurrentFOV;
	float CurrentSize;
	int currentCamera;

	void Start ()
	{
		stadiaT = 0.5f;
		ZoomOutZoomIN();

		mCC = mainCamera.GetComponent<Camera>();
		tCC = tacticsCamera.GetComponent<Camera>();

		transform.position = cameraPosition;
		transform.rotation = Quaternion.Euler(cameraRotate);

		mCC.fieldOfView = CurrentFOV;
		tCC.orthographicSize = CurrentSize;

		SwitchCamera(cameraSwitch);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.Lerp(transform.position, cameraPosition, 0.2f);
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(cameraRotate), 0.2f);

		ZoomOutZoomIN();
		mCC.fieldOfView = Mathf.Lerp(mCC.fieldOfView, CurrentFOV, 0.2f);
		tCC.orthographicSize = Mathf.Lerp(tCC.orthographicSize, CurrentSize, 0.2f);

		SwitchCamera(cameraSwitch);
	}

	void ZoomOutZoomIN()
	{
		CurrentFOV = Mathf.Lerp(minFOV, maxFOV, stadiaT);
		CurrentSize = Mathf.Lerp(minSize, maxSize, stadiaT);
	}

	void SwitchCamera(int cameraSwitch)
	{
		if (currentCamera != cameraSwitch)
		{
			switch (currentCamera)
			{
				case 0:
					mCC.enabled = false;
					break;
				case 1:
					tCC.enabled = false;
					break;
			}
			switch (cameraSwitch)
			{
				case 0:
					mCC.enabled = true;
					break;
				case 1:
					tCC.enabled = true;
					break;
			}
			currentCamera = cameraSwitch;
		}
	}
}
