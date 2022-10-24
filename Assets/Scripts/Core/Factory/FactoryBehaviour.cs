using System;
using System.Collections;
using Core.Player;
using UnityEngine;

namespace Core.Factory
{
	public class FactoryBehaviour : MonoBehaviour
	{
		[Tooltip("How many seconds between taking")] [SerializeField]
		private float speed;

		[Tooltip("How many items does it take at a time")] [SerializeField]
		private int itemsPerTime;

		[Tooltip("How many points per an item")] [SerializeField]
		private int pointsPerItem;

		[Tooltip("How long does it take to process items at a time")] [SerializeField]
		private float processSpeed;

		private Coroutine _takingItems;

		public Action<int> OnPointsProduced;

		private void OnTriggerEnter(Collider other)
		{
			var givingBehaviour = other.gameObject.GetComponentInParent<ItemGivingBehaviour>();
			if (givingBehaviour != null && _takingItems == null)
			{
				_takingItems = StartCoroutine(TakingItems(givingBehaviour.GivingItems));
			}
		}

		private void OnTriggerExit(Collider other)
		{
			var givingBehaviour = other.GetComponent<ItemGivingBehaviour>();
			if (givingBehaviour != null && _takingItems != null)
			{
				StopCoroutine(_takingItems);
				_takingItems = null;
			}
		}

		IEnumerator TakingItems(Func<int, int> recieveItems)
		{
			yield return new WaitForSecondsRealtime(1.5f);

			int itemsCount;
			do
			{
				itemsCount = recieveItems(itemsPerTime);

				StartCoroutine(ProcessingItems(itemsCount));

				yield return new WaitForSecondsRealtime(speed);
			} while (itemsCount > 0);

			_takingItems = null;
		}

		IEnumerator ProcessingItems(int items)
		{
			yield return new WaitForSecondsRealtime(processSpeed);

			OnPointsProduced?.Invoke(items * pointsPerItem);
		}
	}
}
