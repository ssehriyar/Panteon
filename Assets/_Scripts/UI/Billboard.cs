using UnityEngine;

public class Billboard : MonoBehaviour
{
	private Camera _cam;

	void Start()
	{
		_cam = Camera.main;
	}

	private void LateUpdate()
	{
		transform.LookAt(transform.position + _cam.transform.forward);
	}
}
