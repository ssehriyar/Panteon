using System.Collections.Generic;
using UnityEngine;

namespace panteon
{
	public class HorizontalObstacle : ObstacleBase
	{
		private int _currentIndex;
		private Vector3 _targetPosition;
		[SerializeField] private float _speed;
		//[SerializeField] private Transform _model;
		[SerializeField] private List<Transform> _patrolPoints;

		private void Start()
		{
			_currentIndex = 0;
			_targetPosition = new Vector3(_patrolPoints[_currentIndex].position.x, transform.position.y, _patrolPoints[_currentIndex].position.z);
		}

		private void Update()
		{
			MoveToTarget();
			if (TargetReached())
				NextTarget();
		}

		private void MoveToTarget()
		{
			transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
		}

		private bool TargetReached()
		{
			if (Vector3.Distance(transform.position, _targetPosition) <= float.Epsilon)
				return true;
			return false;
		}

		private void NextTarget()
		{
			_currentIndex++;
			if (_currentIndex == _patrolPoints.Count)
				_currentIndex = 0;
			_targetPosition = new Vector3(_patrolPoints[_currentIndex].position.x, transform.position.y, _patrolPoints[_currentIndex].position.z);
		}
	}
}
