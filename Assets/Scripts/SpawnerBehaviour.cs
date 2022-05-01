using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerBehaviour : MonoBehaviour
{
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
        var watier = new WaitForSecondsRealtime(0.25f);

        while (true)
        {
            yield return watier;

            var areaSize = spawnArea.bounds.size;
            var randomPointInArea = new Vector3(Random.Range(0, areaSize.x), areaSize.y + .5f, Random.Range(0, areaSize.z));
            var pointInSpace = spawnArea.bounds.min + randomPointInArea;
            var sphereSpawnPosition = Instantiate(spherePrefab, pointInSpace, Quaternion.identity);
        }
    }
}
