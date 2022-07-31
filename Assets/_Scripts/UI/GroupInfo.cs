using UnityEngine;
using TMPro;

namespace panteon
{
    public class GroupInfo : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private TMP_Text _text;

		private void Start()
		{
			_text.text = _player.name;
		}

		public void SetPlayer(string text)
		{
			_text.text = text;
		}
	}
}
