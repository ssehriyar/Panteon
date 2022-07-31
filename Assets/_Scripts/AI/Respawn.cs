using UnityEngine;

namespace panteon
{
	public class Respawn : IState
	{
		private Enemy _enemy;

		public Respawn(Enemy enemy)
		{
			_enemy = enemy;
		}

		public void OnEnter()
		{
			_enemy.Restart();
			_enemy.SetState(EnemyState.Play);
		}

		public void OnExit()
		{

		}

		public void Tick()
		{

		}
	}
}