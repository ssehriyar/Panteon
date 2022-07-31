using System;
using UnityEngine;

namespace panteon
{
	public class JoystickInputController : MonoBehaviour
	{
		public event Action<Vector2> OnJoystickInputChange;

		[SerializeField] private Joystick _joystick;

		private void Start() => _joystick = GetComponent<Joystick>();

		private void FixedUpdate() => JoystickActionInvoke();

		private void JoystickActionInvoke()
		{
			OnJoystickInputChange?.Invoke(_joystick.Direction);
		}
	}
}