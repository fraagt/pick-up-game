using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Spawner
{
	public class SpawnerBehaviour : MonoBehaviour
	{
		[Tooltip("How many seconds to spawn one item")] [SerializeField]
		private float speed;

		[SerializeField] private GameObject spherePrefab;
		[SerializeField] private Collider spawnArea;

		private Coroutine _spawnCoroutine;

		private void Start()
		{
			if (_spawnCoroutine == null)
				_spawnCoroutine = StartCoroutine(SpawnSphere());
		}

		private IEnumerator SpawnSphere()
		{
			while (true)
			{
				yield return new WaitForSecondsRealtime(speed);
				;

				var areaSize = spawnArea.bounds.size;
				var randomPointInArea = new Vector3(Random.Range(0, areaSize.x), areaSize.y + .5f,
					Random.Range(0, areaSize.z));
				var pointInSpace = spawnArea.bounds.min + randomPointInArea;
				Instantiate(spherePrefab, pointInSpace, Quaternion.identity, transform);
			}
		}
	}
}
