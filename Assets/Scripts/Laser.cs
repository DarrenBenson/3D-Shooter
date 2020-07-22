using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Light))]
[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{

    [Tooltip("Time in seconds")][SerializeField] private float _laserDuration = 0.5f;
    [SerializeField] private float _laserDistance = 300f;
    [SerializeField] private float _fireDelay = 2f;
    private LineRenderer _laserBeam;
    private Light _laserLight;
    private bool _canFire = true;

    private Transform _myTransform;
    private Transform MyTransform
    {
        get
        {
            if (_myTransform == null)
            {
                _myTransform = transform;
            }
            return _myTransform;
        }
    }
    private void Awake()
    {
        _laserBeam = GetComponent<LineRenderer>();
        _laserLight = GetComponent<Light>();
    }

    private void Start()
    {
        _laserBeam.enabled = false;
        _laserLight.enabled = false;
        _canFire = true;
    }

    private void Update()
    {
        Debug.DrawRay(MyTransform.position, MyTransform.TransformDirection(Vector3.forward) * _laserDistance, Color.yellow);
    }

    private Vector3 CastRay()
    {
        RaycastHit hit;
        Vector3 laserDirection = MyTransform.TransformDirection(Vector3.forward) * _laserDistance;
        if (Physics.Raycast(transform.position, laserDirection, out hit))
        {
            Debug.Log("Raycast Hit: " + hit.transform.name);
            Explosion hitExplosion = hit.transform.GetComponent<Explosion>();
            if(hitExplosion != null)
                hitExplosion.OnHit(hit.point);
            return hit.point;
        }
        else
        {
            Debug.Log("Raycast Miss");
            return MyTransform.position + (MyTransform.forward * _laserDistance);
        }
    }
    public void FireLaser() {
        if (_canFire)
        {
            _laserBeam.SetPosition(0, _transform.position);
            _laserBeam.SetPosition(1, CastRay());
            _laserBeam.enabled = true;
            _laserLight.enabled = true;
            _canFire = false;
            Invoke("TurnOffLaser", _laserDuration);
            Invoke("CanFire", _fireDelay);
        }
    }

    private void TurnOffLaser() {
        _laserBeam.enabled = false;
        _laserLight.enabled = false;
    }

    public float Distance
    {
        get { return _laserDistance; }
    }

    private void CanFire()
    {
        _canFire = true;
    }

}
