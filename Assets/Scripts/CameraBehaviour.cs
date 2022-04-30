using System;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        var currentPosition = transform.position;
        var newPosition = target.position + offset;
        transform.position = Vector3.Lerp(currentPosition, newPosition, Time.deltaTime * (newPosition - currentPosition).magnitude);
    }
}
