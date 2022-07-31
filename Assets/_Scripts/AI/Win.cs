namespace panteon
{
	public class Win : IState
	{
		private Enemy _enemy;

		public Win(Enemy enemy)
		{
			_enemy = enemy;
		}

		public void OnEnter()
		{
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