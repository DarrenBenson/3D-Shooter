using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] private float _movementSpeed = 20f;
    [SerializeField] private float _turnSpeed = 0.5f;

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

    private void Update()
    {
        Turn();
        Move();
    }

    private void Turn()
    {
        Vector3 pos = _target.position - MyTransform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(MyTransform.rotation, rotation, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        MyTransform.position += MyTransform.forward * _movementSpeed * Time.deltaTime;
    }

}
