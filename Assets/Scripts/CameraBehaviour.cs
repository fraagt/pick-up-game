using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;

    // private void LateUpdate()
    // {
    //     var r =Random.Range(0, 100);
    //     var currentPosition = transform.position;
    //     offset.x = r;
    //     var newPosition = target.position + offset;
    //     transform.position = Vector3.Lerp(currentPosition, newPosition,
    //         Time.deltaTime * (newPosition - currentPosition).normalized);
    // }
}
