using UnityEngine;

namespace panteon
{
    public class Rotator : MonoBehaviour
    {
		private Rigidbody _rb;
		private Quaternion _quaternion;
		[SerializeField] private float _speed;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			_quaternion = Quaternion.Euler(new Vector3(0, _speed, 0) * Time.deltaTime);
			_rb.MoveRotation(_rb.rotation * _quaternion);
		}
	}
}
