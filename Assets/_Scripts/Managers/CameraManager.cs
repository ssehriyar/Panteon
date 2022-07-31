using UnityEngine;
using Cinemachine;

namespace panteon
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _playerCam;
        [SerializeField] private CinemachineVirtualCamera _drawCam;

		private void Start()
		{
			GameStateManager.OnGameStateChanged += ChangeCam;
		}

		private void ChangeCam(GameState gameState)
		{
			if(gameState == GameState.Draw)
			{
				_drawCam.Priority = 3;
			}
		}

		private void OnDestroy()
		{
			GameStateManager.OnGameStateChanged -= ChangeCam;
		}
	}
}
