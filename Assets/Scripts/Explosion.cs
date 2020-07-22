using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{

    [SerializeField] private GameObject explosion;

    public void OnHit(Vector3 pos)
    {
        GameObject myExplosion = Instantiate(explosion, pos, Quaternion.identity, transform);
        Destroy(myExplosion, 6f);
    }

}
