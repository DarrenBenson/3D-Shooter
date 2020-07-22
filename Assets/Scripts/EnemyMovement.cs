using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] private float _movementSpeed = 20f;
    [SerializeField] private float _turnSpeed = 0.5f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        Turn();
        Move();
    }

    private void Turn()
    {
        Vector3 pos = _target.position - _transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(_transform.rotation, rotation, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        _transform.position += _transform.forward * _movementSpeed * Time.deltaTime;
    }

}
