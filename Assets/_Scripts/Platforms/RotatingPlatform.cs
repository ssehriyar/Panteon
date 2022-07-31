using UnityEngine;

namespace panteon
{
	public class RotatingPlatform : PlatformBase
	{
		//[SerializeField] private Transform _model;
		//[SerializeField] private bool _clockwiseRotation;
		private Vector3 _rotate;

		private void Start()
		{
			//if (_clockwiseRotation)
			//_speed *= -1;
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
