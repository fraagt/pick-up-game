using Core.Player;
using TMPro;
using UnityEngine;

namespace UI
{
	public class PlayerUiBehaviour : MonoBehaviour
	{
		[SerializeField] private PlayerBehaviour playerBehaviour;
		
		[SerializeField] private TMP_Text itemsAmountText;

		private void Awake()
		{
			playerBehaviour.OnScoreChanged += OnScoreChanged;
		}

		private void OnScoreChanged(int itemsAmount)
		{
			itemsAmountText.text = $"{itemsAmount}";
		}
	}
}
