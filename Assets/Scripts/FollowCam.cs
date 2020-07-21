using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _followPosition = new Vector3(0f, 2f, -10f);
    [SerializeField] private float _followDelay = 0.15f;

    private Transform _transform;
    private Vector3 _velocity = Vector3.one;

    private void Awake()
    {
        _transform = transform;
    }

    private void LateUpdate()
    {
        SmoothFollow();
    }

   private void SmoothFollow()
    {
        Vector3 toPosition = _target.position + (_target.rotation * _followPosition);
        _transform.position = Vector3.SmoothDamp(_transform.position, toPosition, ref _velocity, _followDelay);
        _transform.LookAt(_target, _target.up);
    }


}