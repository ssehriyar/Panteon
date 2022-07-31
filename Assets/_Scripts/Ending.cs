using UnityEngine;

namespace panteon
{
	public class Ending : MonoBehaviour
	{
		private void Awake()
		{
			GameStateManager.OnGameStateChanged += StateChange;
		}

		private void StateChange(GameState gameState)
		{
			if (gameState == GameState.Draw)
			{
				gameObject.SetActive(false);
			}
		}

		private void OnDestroy()
		{
			GameStateManager.OnGameStateChanged -= StateChange;
		}
	}
}
