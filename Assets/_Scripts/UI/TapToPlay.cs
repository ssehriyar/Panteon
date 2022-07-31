using UnityEngine;
using UnityEngine.EventSystems;

namespace panteon
{
	public class TapToPlay : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
	{
		//private void Update()
		//{
		//	if (Input.GetMouseButtonDown(0))
		//	{
		//		GameStateManager.SetState(GameState.Play);
		//	}
		//}

		public void OnPointerDown(PointerEventData eventData)
		{
			GameStateManager.SetState(GameState.Play);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			//GameStateManager.SetState(GameState.Play);
		}
	}
}
