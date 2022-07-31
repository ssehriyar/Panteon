using UnityEngine;

namespace panteon
{
	public class RotatingPlatform : PlatformBase
	{
		private Vector3 _rotate;

		private void Start()
		{
			_rotate = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, _speed);
		}

		private void Update()
		{
			RotateModel();
		}

		private void RotateModel()
		{
			transform.Rotate(_rotate * Time.deltaTime);
		}
	}
}
