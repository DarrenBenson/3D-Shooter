using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(MeshCollider))]
public class Pickup : MonoBehaviour
{

    [SerializeField] private int _points = 100;
    private bool _isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (!_isCollected)
            {
                _isCollected = true;
                Collect();
            }
        }
    }

    public void Collect()
    {
        GameEventManager.IncrementScore(_points);
        GameEventManager.RespawnPickup();
        Destroy(gameObject);
    }

}
