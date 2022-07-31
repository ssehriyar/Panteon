using UnityEngine;
using UnityEngine.SceneManagement;

namespace panteon
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

		private void Awake()
		{
			Instance = this;
		}

		private void Start()
		{
			GameStateManager.SetState(GameState.TapToPlay);
		}

		public void RestartGame()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
