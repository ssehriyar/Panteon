using UnityEngine;

namespace panteon
{
	public class WaitForStart : IState
	{
		private Enemy _enemy;
		private Animator _animator;

		private readonly int EnemyIdle = Animator.StringToHash("EnemyIdle");

		public WaitForStart(Enemy enemy, Animator animator)
		{
			_enemy = enemy;
			_animator = animator;
		}

		public void OnEnter()
		{
			Debug.Log("EnemyIdle");
			_animator.SetTrigger(EnemyIdle);
			GameStateManager.OnGameStateChanged += StateChange;
		}

		public void OnExit()
		{
			GameStateManager.OnGameStateChanged -= StateChange;
		}

		public void Tick()
		{
			
		}

		private void StateChange(GameState gameState)
		{
			if (gameState == GameState.Play)
			{
				_enemy.SetState(EnemyState.Play);
			}
		}
	}
}