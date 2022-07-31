using UnityEngine;
using System.Collections;

namespace panteon
{
	public class PlayerMovement : MonoBehaviour
	{
		private readonly int Idle = Animator.StringToHash("Idle");
		private readonly int Run = Animator.StringToHash("Run");
		private float _platformSpeed;
		private Transform _platform;
		private float _rotationSpeed;

		[SerializeField] private float _stun;
		[SerializeField] private float _hitForce;
		[SerializeField] private float _forwardSpeed;
		[SerializeField] private float _horizontalSpeed;
		[SerializeField] private Rigidbody _rb;
		[SerializeField] private Animator _animator;
		[SerializeField] private JoystickInputController _joystickInputController;
		[SerializeField] private Transform _drawingPos;

		private void OnEnable() => EnableMove();
		private void OnDisable() => DisableMove();
		
		private void Start()
		{
			GameStateManager.OnGameStateChanged += GameStateChanged;
			enabled = false;
		}
		private void EnableMove()
		{
			_animator.SetTrigger(Run);
			_joystickInputController.OnJoystickInputChange += Move;
		}

		private void DisableMove()
		{
			_animator.SetTrigger(Idle);
			_joystickInputController.OnJoystickInputChange -= Move;
		}

		public void PlatformChanged(Transform platform, float speed)
		{
			_platform = platform;
			_platformSpeed = speed;
		}

		public void Move(Vector2 direction)
		{
			if (_platformSpeed == 0)//Flat Platform Speed = 0
			{
				_rb.velocity = (_forwardSpeed * Vector3.forward) + (_rb.velocity.y * Vector3.up) + (_horizontalSpeed * direction.x * Vector3.right);
			}
			else//Rotating Platform
			{
				_rb.velocity = (_forwardSpeed * Vector3.forward) + (_rb.velocity.y * Vector3.up);
				if (direction.x == 0)//No input/Not using joystick
				{
					transform.RotateAround(_platform.position, Vector3.forward, _platformSpeed * Time.deltaTime);
				}
				else//Using joystick
				{
					if (_platformSpeed > 0)
					{
						_rotationSpeed = (-direction.x * _platformSpeed * 1.5f) + _platformSpeed;
						transform.RotateAround(_platform.position, Vector3.forward, _rotationSpeed * Time.deltaTime);
					}
					else
					{
						_rotationSpeed = (direction.x * _platformSpeed * 1.5f) + _platformSpeed;
						transform.RotateAround(_platform.position, Vector3.forward, _rotationSpeed * Time.deltaTime);
					}
				}
			}
		}

		public IEnumerator MoveToDrawingPosition()
		{
			while (Vector3.Distance(transform.position, _drawingPos.position) >= float.Epsilon)
			{
				transform.position = Vector3.MoveTowards(transform.position, _drawingPos.position, 2 * Time.deltaTime);
				yield return new WaitForEndOfFrame();
			}
		}

		public IEnumerator DisableMoveForATime()
		{
			_joystickInputController.OnJoystickInputChange -= Move;
			yield return new WaitForSeconds(_stun);
			_joystickInputController.OnJoystickInputChange += Move;
		}

		public void GetHit(Vector3 direction)
		{
			_rb.AddForce(direction * _hitForce);
		}

		private void GameStateChanged(GameState gameState)
		{
			switch (gameState)
			{
				case GameState.Play:
					EnableMove();
					break;
				case GameState.Draw:
					DisableMove();
					FixRotation();
					StartCoroutine(MoveToDrawingPosition());
					break;
			}
		}

		private void FixRotation()
		{
			transform.rotation = Quaternion.identity;
		}

		private void OnDestroy()
		{
			_joystickInputController.OnJoystickInputChange -= Move;
			GameStateManager.OnGameStateChanged -= GameStateChanged;
		}
	}
}