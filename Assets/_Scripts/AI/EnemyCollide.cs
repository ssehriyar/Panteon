using UnityEngine;

namespace panteon
{
	public class EnemyCollide : MonoBehaviour
	{
		private Enemy _enemy;
		[SerializeField] private LayerMask _rotatinglayerMask;

		private void Awake()
		{
			_enemy = GetComponent<Enemy>();
		}

		private void OnCollisionEnter(Collision collision)
		{
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
