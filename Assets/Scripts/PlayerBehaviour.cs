using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private int sphereCount = 0;

    public static event Action<int> OnScoreChanged;

    public void PickUpSphere(SphereBehaviour sphere)
    {
        ++sphereCount;
        OnScoreChanged?.Invoke(sphereCount);
        Destroy(sphere.gameObject);
    }
}
