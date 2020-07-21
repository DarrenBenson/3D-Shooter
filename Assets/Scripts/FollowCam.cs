using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _followPosition = new Vector3(0f, 2f, -10f);
    [SerializeField] private float _followDelay = 10f;
    [SerializeField] private float _rotationDelay = 10f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void LateUpdate()
    {
        MoveToTarget(_target, _followPosition, _followDelay);
        RotateToTarget(_target, _rotationDelay);
    }

    private void MoveToTarget(Transform target, Vector3 followPosition, float followDelay)
    {
        Vector3 toPosition = target.position + (target.rotation * followPosition);
        Vector3 currentPosition = Vector3.Lerp(transform.position, toPosition, followDelay * Time.deltaTime);
        _transform.position = currentPosition;
    }

    private void RotateToTarget(Transform target, float rotationDelay)
    {
        Quaternion toRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        Quaternion currentRotation = Quaternion.Slerp(transform.rotation, toRotation, rotationDelay * Time.deltaTime);
        _transform.rotation = currentRotation;
    }

}