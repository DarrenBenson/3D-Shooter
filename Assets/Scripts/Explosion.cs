using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{

    [SerializeField] private GameObject explosion;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float _laserHitForce = 10f;

    public void OnHit(Vector3 pos)
    {
        GameObject myExplosion = Instantiate(explosion, pos, Quaternion.identity, transform);
        Destroy(myExplosion, 6f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach(var contactPoint in collision.contacts)
        {
            OnHit(contactPoint.point);
        }
    }

    public void AddForce(Vector3 hitPosition, Transform hitSource)
    {
        Debug.LogWarning("AddForce: " + gameObject.name + " -> " + hitSource.name);
        if (rigidBody == null) return;
        Vector3 forceDirection = (hitSource.position - transform.position).normalized;
        rigidBody.AddForceAtPosition(forceDirection * _laserHitForce, hitPosition, ForceMode.Impulse);
    }

}
