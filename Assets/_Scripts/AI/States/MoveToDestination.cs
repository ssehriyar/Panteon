using UnityEngine;
using UnityEngine.AI;

namespace panteon
{
	public class MoveToDestination : IState
	{
		private Enemy _enemy;
		private NavMeshAgent _agent;
		private Vector3 _lastPosition;
		public float TimeStuck;
		private Animator _animator;

		private readonly int EnemyRun = Animator.StringToHash("EnemyRun");

		public MoveToDestination(Enemy enemy, NavMeshAgent agent, Animator animator)
		{
			_enemy = enemy;
			_agent = agent;
			_animator = animator;
			_lastPosition = Vector3.zero;
		}

		public void OnEnter()
		{
			Debug.Log("MoveTo");
			TimeStuck = 0;
			_animator.SetTrigger(EnemyRun);
			_agent.enabled = true;
			SetDestination();
		}

		public void OnExit()
		{
			_agent.enabled = false;
		}

		public void Tick()
		{
			if (Vector3.Distance(_enemy.transform.position, _lastPosition) <= 0f)
			{
				TimeStuck += Time.deltaTime;
			}

			if (!_agent.pathPending && _agent.remainingDistance <= 0.1f)
			{
				_agent.ResetPath();
				SetDestination();
			}

			_lastPosition = _enemy.transform.position;

			if (TimeStuck > 1f)
			{
				TimeStuck = 0f;
				SetDestination();
			}
		}

		private void SetDestination()
		{
			if (_agent.SetDestination(EnemyDestinationPoint.Instance.GetRandomDestination(_enemy.stageLevel)))
			{
				_enemy.stageLevel++;
			}
		}
	}
}