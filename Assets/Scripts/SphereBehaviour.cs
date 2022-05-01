using UnityEngine;

public class SphereBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerBehaviour>(out var player))
        {
            player.PickUpSphere(this);
            return;
        }
    }
}
