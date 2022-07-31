using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace panteon
{
	public class ScoreBoard : MonoBehaviour
	{
		[SerializeField] private List<Transform> _players;
		[SerializeField] private List<GroupInfo> _groups;

		private void Update()
		{
			DescendingSort();
			UpdateScoreboard();
		}

		private void DescendingSort()
		{
			_players = _players.OrderByDescending(p => p.position.z).ToList();
		}

		private void UpdateScoreboard()
		{
			for (int index = 0; index < _groups.Count; index++)
			{
				_groups[index].SetPlayer((index + 1).ToString() + "-" + _players[index].name);
			}
		}
	}
}
