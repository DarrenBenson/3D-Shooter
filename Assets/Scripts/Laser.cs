using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{

    [Tooltip("Time in seconds")][SerializeField] private float laserDuration = 0.5f;
    [SerializeField] private float laserDistance = 300f;
    private LineRenderer _lineRenderer;
    private bool _canFire = true;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        _lineRenderer.enabled = false;
    }

    public void FireLaser(Vector3 targetPosition) {
        if (_canFire)
        {
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, targetPosition);
            _lineRenderer.enabled = true;
            _canFire = false;
        }
        Invoke("TurnOffLaser", laserDuration);
    }

    private void TurnOffLaser() {
        _lineRenderer.enabled = false;
        _canFire = true;
    }

}
