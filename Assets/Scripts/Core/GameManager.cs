using System;
using Core.Factory;
using UnityEngine;

namespace Core
{
	public class GameManager : MonoBehaviour
	{
		private int _points;

		public int Points
		{
			get => _points;
			private set
			{
				_points = value;
				OnPointsChanged?.Invoke(_points);
			}
		}

		public Action<int> OnPointsChanged;
	
		[SerializeField] private FactoryBehaviour factoryBehaviour;

		private void Start()
		{
			factoryBehaviour.OnPointsProduced += ObtainPoints;
		}

		private void OnDestroy()
		{
			factoryBehaviour.OnPointsProduced -= ObtainPoints;
		}

		private void ObtainPoints(int obtainPoints)
		{
			Points += obtainPoints;
		}
	}
}
