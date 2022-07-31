using UnityEngine;

namespace panteon
{
	public class PlayerCollide : MonoBehaviour
	{
		private int _id;
		private float _rayDistance;
		private RaycastHit _hit;
		private PlatformBase _platform;
		[SerializeField] private PlayerMovement _playerMovement;
		[SerializeField] private LayerMask _groundlayerMask;

		private void Awake()
		{
			_rayDistance = 0.2f;
		}

		private void OnCollisionEnter(Collision collision)
		{
			_platform = collision.transform.GetComponent<PlatformBase>();
			if (_platform != null && _id != collision.gameObject.GetInstanceID())
			{
				if (Physics.Raycast(transform.position, Vector3.down, out _hit, _rayDistance, _groundlayerMask))
				{
					transform.up = _hit.normal;
				}
				_id = collision.gameObject.GetInstanceID();
				_playerMovement.PlatformChanged(_platform.transform, _platform.GetSpeed);
			}

			 if (collision.gameObject.GetComponent<ObstacleBase>())
			{
				GameManager.Instance.RestartGame();
			}

			if (collision.gameObject.GetComponent<RotatingStick>())
			{
				StartCoroutine(_playerMovement.DisableMoveForATime());
				_playerMovement.GetHit(collision.GetContact(0).normal.normalized);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<Ending>())
			{
				GameStateManager.SetState(GameState.Draw);
			}
		}
	}
}
