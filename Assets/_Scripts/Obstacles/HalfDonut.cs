using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace panteon
{
	public class HalfDonut : MonoBehaviour
	{
		private int _currentIndex;
		private Vector3 _targetPosition;
		[SerializeField] private float _speed;
		[SerializeField] private Transform _model;
		[SerializeField] private List<Transform> _patrolPoints;

		private void Start()
		{
			_currentIndex = 0;
			_targetPosition = new Vector3(_patrolPoints[_currentIndex].position.x, _model.position.y, _patrolPoints[_currentIndex].position.z);
			StartCoroutine(MoveToTarget());
		}

		private IEnumerator MoveToTarget()
		{
			while (true)
			{
				if (TargetReached())
				{
					NextTarget();
					yield return new WaitForSeconds(Random.Range(0f, 3f));
				}
				_model.position = Vector3.MoveTowards(_model.position, _targetPosition, _speed * Time.deltaTime);
				yield return new WaitForEndOfFrame();
			}
		}

		private bool TargetReached()
		{
			if (Vector3.Distance(_model.position, _targetPosition) <= float.Epsilon)
				return true;
			return false;
		}

		private void NextTarget()
		{
			_currentIndex++;
			if (_currentIndex == _patrolPoints.Count)
				_currentIndex = 0;
			_targetPosition = new Vector3(_patrolPoints[_currentIndex].position.x, _model.position.y, _patrolPoints[_currentIndex].position.z);
		}
	}
}
