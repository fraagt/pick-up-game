using System;
using UnityEngine;

namespace Core.Player
{
	public class ItemGivingBehaviour : MonoBehaviour
	{
		public Func<int, int> GivingItems;
	}
}
