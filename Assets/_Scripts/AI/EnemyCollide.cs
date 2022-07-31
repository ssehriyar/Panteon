using UnityEngine;

namespace panteon
{
	public class EnemyCollide : MonoBehaviour
	{
		private int _id;
		private float _rayDistance;
		private Enemy _enemy;
		private RaycastHit _hit;
		private PlatformBase _platform;
		[SerializeField] private LayerMask _rotatinglayerMask;

		private void Awake()
		{
			_enemy = GetComponent<Enemy>();
			_rayDistance = 0.5f;
		}

		private void OnCollisionEnter(Collision collision)
		{
			//_platform = collision.transform.GetComponent<PlatformBase>();
			//if (_platform != null && _id != collision.gameObject.GetInstanceID())
			//{
			//	if (Physics.Raycast(transform.position, Vector3.down, out _hit, _rayDistance, _rotatinglayerMask))
			//	{
			//		Debug.Log(transform.name + "  Raycast: " + _hit.transform.parent.name);
			//		transform.up = _hit.normal;
			//	}
			//	_id = collision.gameObject.GetInstanceID();
			//}
			if (collision.gameObject.GetComponent<ObstacleBase>())
			{
				_enemy.SetState(EnemyState.Hit);
			}
			if (collision.gameObject.GetComponent<RotatingStick>())
			{
				StartCoroutine(_enemy.DisableMoveForATime());
				_enemy.GetHit(collision.GetContact(0).normal.normalized);
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<Ending>())
			{
				_enemy.SetState(EnemyState.Win);
				GameStateManager.SetState(GameState.Fail);
			}
		}
	}
}
