using System;
using UnityEngine;

namespace panteon
{
	public class JoystickInputController : MonoBehaviour
	{
		public event Action<Vector2> OnJoystickInputChange;

		[SerializeField] private Joystick _joystick;

		private void Start() => _joystick = FindObjectOfType<Joystick>();

		private void FixedUpdate() => JoystickActionInvoke();

		private void JoystickActionInvoke()
		{
			//if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
			OnJoystickInputChange?.Invoke(_joystick.Direction);
			//Debug.Log(_joystick.Direction);
		}
	}
}