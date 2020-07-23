using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] private float _movementSpeed = 20f;
    [SerializeField] private float _turnSpeed = 0.5f;
    [SerializeField] private float _rayCastOffset = 2.5f;
    [SerializeField] private float _rayCastRange = 20f;

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
        Pathfinding();
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

    private void Pathfinding()
    {
        RaycastHit hit;
        Vector3 rayCastOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right * _rayCastOffset;
        Vector3 right = transform.position + transform.right * _rayCastOffset;
        Vector3 up = transform.position + transform.up * _rayCastOffset;
        Vector3 down = transform.position - transform.up * _rayCastOffset;

        Debug.DrawRay(left, transform.forward * _rayCastRange, Color.cyan);
        Debug.DrawRay(right, transform.forward * _rayCastRange, Color.cyan);
        Debug.DrawRay(up, transform.forward * _rayCastRange, Color.cyan);
        Debug.DrawRay(down, transform.forward * _rayCastRange, Color.cyan);

        if (Physics.Raycast(left, transform.forward, out hit, _rayCastRange))
        {
            rayCastOffset += Vector3.right;
        }
        else if (Physics.Raycast(right, transform.forward, out hit, _rayCastRange))
        {
            rayCastOffset -= Vector3.right;
        }


        if (Physics.Raycast(up, transform.forward, out hit, _rayCastRange))
        {
            rayCastOffset -= Vector3.up;
        }
        else if (Physics.Raycast(down, transform.forward, out hit, _rayCastRange))
        {
            rayCastOffset = Vector3.up;
        }

        if (rayCastOffset != Vector3.zero)
        {
            transform.Rotate(rayCastOffset * 5f * Time.deltaTime);
        }
        else
        {
            Turn();
        }
    }
}
