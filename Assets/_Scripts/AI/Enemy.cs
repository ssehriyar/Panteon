using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace panteon
{
	public enum EnemyState
	{
		WaitForPlay,
		Play,
		Hit,
		Win,
		Fail
	}

	public class Enemy : MonoBehaviour
	{
		private Rigidbody _rb;
		private StateMachine _stateMachine;
		private NavMeshAgent _agent;
		private Animator _animator;
		private EnemyState _enemyState;
		[SerializeField] private float _hitForce;

		[HideInInspector] public int stageLevel;
		public Vector3 StartPos { get; private set; }
		public Quaternion StartRot { get; private set; }

		private void Awake()
		{
			_rb = GetComponent<Rigidbody>();
			_stateMachine = new StateMachine();
			_agent = GetComponent<NavMeshAgent>();
			_animator = GetComponent<Animator>();
			stageLevel = 0;
			StartPos = transform.position;
			StartRot = transform.rotation;
			SetState(EnemyState.WaitForPlay);

			#region Default States
			var waitForStart = new WaitForStart(this, _animator);
			var moveToDestination = new MoveToDestination(this, _agent, _animator);
			var win = new Win(this);
			var fail = new Fail(this);
			#endregion

			#region High Priority States
			var respawn = new Respawn(this);
			#endregion

			#region Default State Transiitons
			At(waitForStart, moveToDestination, GameStarted());
			At(respawn, moveToDestination, GameStarted());
			#endregion

			#region High Priority Transitions
			_stateMachine.AddAnyTransition(respawn, HitDetected());
			_stateMachine.AddAnyTransition(win, Won());
			_stateMachine.AddAnyTransition(fail, Fail());
			#endregion

			_stateMachine.SetState(waitForStart);

			#region Transition Conditions
			Func<bool> GameStarted() => () => _enemyState == EnemyState.Play;
			Func<bool> HitDetected() => () => _enemyState == EnemyState.Hit;
			Func<bool> Won() => () => _enemyState == EnemyState.Win;
			Func<bool> Fail() => () => GameStateManager.GetGameState() == GameState.Draw;
			#endregion

			void At(IState to, IState from, Func<bool> condition) =>
								_stateMachine.AddTransition(to, from, condition);
		}

		private void Update() => _stateMachine.Tick();

		public void Restart()
		{
			stageLevel = 0;
			transform.SetPositionAndRotation(StartPos, StartRot);
		}

		public IEnumerator DisableMoveForATime()
		{
			_agent.isStopped = true;
			yield return new WaitForSeconds(1);
			_agent.isStopped = false;
		}

		public void GetHit(Vector3 direction)
		{
			_rb.AddForce(direction * _hitForce);
		}

		public void SetState(EnemyState enemyState) => _enemyState = enemyState;
	}
}
