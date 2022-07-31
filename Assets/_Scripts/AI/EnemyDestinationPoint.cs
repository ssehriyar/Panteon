using System.Collections.Generic;
using UnityEngine;

namespace panteon
{
	public class EnemyDestinationPoint : MonoBehaviour
	{
		public static EnemyDestinationPoint Instance;

		[SerializeField] private float _minRange;
		[SerializeField] private float _maxRange;
		[SerializeField] private List<Transform> _destinations;

		private void Awake()
		{
			Instance = this;
		}

		public Vector3 GetRandomDestination(int level)
		{
			Vector3 pos;
			Vector3 dum;
			if (level >= _destinations.Count)
			{
				pos = _destinations[_destinations.Count - 1].position;
				dum = new Vector3(Random.Range(_minRange, _maxRange), pos.y, pos.z);
				return dum;
			}

			pos = _destinations[level].position;
			dum = new Vector3(Random.Range(_minRange, _maxRange), pos.y, pos.z);
			return dum;
		}
	}
}
