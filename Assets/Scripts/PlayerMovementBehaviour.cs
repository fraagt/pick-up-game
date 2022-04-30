using System;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed;

    private void Update()
    {
        DoMovement();
    }

    private void DoMovement()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            movement.z += 1;
        if (Input.GetKey(KeyCode.S))
            movement.z += -1;
        if (Input.GetKey(KeyCode.D))
            movement.x += 1;
        if (Input.GetKey(KeyCode.A))
            movement.x += -1;

        var currentPosition = transform.position;

        transform.position = Vector3.Lerp(currentPosition, currentPosition + movement * speed, Time.deltaTime);
    }
}
