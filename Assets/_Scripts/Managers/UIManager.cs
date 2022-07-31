using UnityEngine;

namespace panteon
{
	public class UIManager : MonoBehaviour
	{
		[SerializeField] private GameObject _joystick;
		[SerializeField] private GameObject _tapToPlay;
		[SerializeField] private GameObject _paintTheWall;

		private void Start()
		{
			GameStateManager.OnGameStateChanged += StateChange;
		}

		private void StateChange(GameState gameState)
		{
			switch (gameState)
			{
				case GameState.Play:
					_tapToPlay.SetActive(false);
					break;
				case GameState.Draw:
					_paintTheWall.SetActive(true);
					_joystick.SetActive(false);
					break;
			}
		}

		private void OnDestroy()
		{
			GameStateManager.OnGameStateChanged -= StateChange;
		}
	}
}
