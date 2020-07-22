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

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _laserBeam = GetComponent<LineRenderer>();
        _laserLight = GetComponent<Light>();
    }

    private void Start()
    {
        _laserBeam.enabled = false;
        _laserLight.enabled = false;
        _canFire = true;
    }

    public void FireLaser(Vector3 targetPosition) {
        if (_canFire)
        {
            _laserBeam.SetPosition(0, _transform.position);
            _laserBeam.SetPosition(1, targetPosition);
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
