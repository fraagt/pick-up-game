using System;
using UnityEngine;

namespace Core.Player
{
	public class PlayerBehaviour : MonoBehaviour
	{
		[SerializeField] private ItemCollectingBehaviour itemCollectingBehaviour;
		[SerializeField] private ItemGivingBehaviour itemGivingBehaviour;

		private int _sphereCount;

		public int SphereCount
		{
			get => _sphereCount;
			private set
			{
				_sphereCount = value > 0 ? value : 0;
				OnScoreChanged?.Invoke(_sphereCount);
			}
		}

		public Action<int> OnScoreChanged;

		public void Start()
		{
			itemCollectingBehaviour.OnItemCollected += CollectItem;
			itemGivingBehaviour.GivingItems += GiveItems;
		}

		public void OnDestroy()
		{
			itemCollectingBehaviour.OnItemCollected -= CollectItem;
			itemGivingBehaviour.GivingItems -= GiveItems;
		}

		private void CollectItem()
		{
			SphereCount++;
		}

		public int GiveItems(int quantity)
		{
			if (SphereCount < quantity)
				quantity = SphereCount;

			SphereCount -= quantity;
			return quantity;
		}
	}
}
