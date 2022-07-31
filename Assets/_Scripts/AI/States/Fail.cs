namespace panteon
{
	public class Fail : IState
	{
		private Enemy _enemy;

		public Fail(Enemy enemy)
		{
			_enemy = enemy;
		}

		public void OnEnter()
		{
			_enemy.SetState(EnemyState.Fail);
			_enemy.gameObject.SetActive(false);
		}

		public void OnExit()
		{

		}

		public void Tick()
		{

		}
	}
}