using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace panteon
{
	public class DeathAngle : MonoBehaviour
	{
		[SerializeField] private float _angle;

		private void Update()
		{
			if (Mathf.Abs(transform.rotation.y) > _angle)
				GameManager.Instance.RestartGame();
		}
	}
}
