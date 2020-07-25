using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{

    [SerializeField] private GameObject explosion;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Shield _shield;
    [SerializeField] private float _laserHitForce = 10f;
    [SerializeField] private float _explosionDuration = 6f;

    private void OnCollisionEnter(Collision collision)
    {
        foreach(var contactPoint in collision.contacts)
        {
            SpawnExplosion(contactPoint.point);
        }
    }

    private void SpawnExplosion(Vector3 explosionPosition)
    {
        GameObject spawnedExplosion = Instantiate(explosion, explosionPosition, Quaternion.identity, transform);
        Destroy(spawnedExplosion, _explosionDuration);
        if (_shield != null)
        {
            _shield.TakeDamage();
        }
    }

    public void AddForce(Vector3 hitPosition, Transform hitSource)
    {
        Debug.LogWarning("AddForce: " + gameObject.name + " -> " + hitSource.name);
        SpawnExplosion(hitPosition);
        if (rigidBody == null) return;
        Vector3 forceDirection = (hitSource.position - transform.position).normalized;
        rigidBody.AddForceAtPosition(forceDirection * _laserHitForce, hitPosition, ForceMode.Impulse);
    }

}
