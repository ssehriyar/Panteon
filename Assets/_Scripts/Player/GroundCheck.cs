using System.Collections;
using UnityEngine;

namespace panteon
{
	public class GroundCheck : MonoBehaviour
	{
		public static GroundCheck Instance;

		private RaycastHit _hit;
		private Coroutine _coroutine;

		private bool _isGrounded;
		[SerializeField] private float _rayDistance = 0.2f;
		[SerializeField] private LayerMask _groundlayerMask;

		private void Awake()
		{
			Instance = this;
			_isGrounded = true;
		}

		private void FixedUpdate()
		{
			if (!CheckGrounded() && _coroutine == null)
			{
				_coroutine = StartCoroutine(Falling());
			}
		}

		private IEnumerator Falling()
		{
			yield return new WaitForSeconds(2f);
			if (!_isGrounded)
			{
				StopCoroutine(_coroutine);
				GameManager.Instance.RestartGame();
			}
		}

		private bool CheckGrounded()
		{
			Debug.DrawRay(transform.position, Vector3.down * _rayDistance, Color.red);
			if (Physics.Raycast(transform.position, Vector3.down, out _hit, _rayDistance, _groundlayerMask))
			{
				Debug.Log(_hit.transform.name);
				_isGrounded = true;
				return _isGrounded;
			}
			_isGrounded = false;
			return _isGrounded;
		}
	}
}
