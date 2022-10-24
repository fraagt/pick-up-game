using System;
using Core.Spawner.Items;
using UnityEngine;

namespace Core.Player
{
	public class ItemCollectingBehaviour : MonoBehaviour
	{
		public Action OnItemCollected;

		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<ItemBehaviour>())
			{
				OnItemCollected?.Invoke();
				Destroy(other.gameObject);
			}
		}
	}
}
