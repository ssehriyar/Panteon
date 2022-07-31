using System;
using UnityEngine;

namespace panteon
{
	public abstract class PlatformBase : MonoBehaviour
	{
		[Range(-20, 20)]
		[SerializeField] protected float _speed;
		public float GetSpeed => _speed;
	}
}
