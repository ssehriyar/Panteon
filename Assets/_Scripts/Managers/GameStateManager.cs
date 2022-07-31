using System;

namespace panteon
{
	public enum GameState
	{
		TapToPlay,
		Play,
		Draw,
		Win,
		Fail
	}
	public class GameStateManager
	{
		private static GameStateManager _instance;
		private GameState _currentGameState;
		public static event Action<GameState> OnGameStateChanged;

		public static GameState GetGameState()
		{
			if (_instance == null)
			{
				_instance = new GameStateManager();
			}

			return _instance._currentGameState;
		}

		public static void SetState(GameState gameState)
		{
			if(_instance == null)
			{
				_instance = new GameStateManager();
			}

			_instance._currentGameState = gameState;
			OnGameStateChanged?.Invoke(gameState);
		}
	}
}
