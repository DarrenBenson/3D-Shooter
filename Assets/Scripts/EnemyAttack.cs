using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private Transform _target;

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

    private void TargetInfront()
    {
        Vector3 directionToTarget = MyTransform.position - _target.position;
        float angle = Vector3.Angle(MyTransform.forward, directionToTarget);

        Debug.DrawLine(transform.position, _target.position);
    }

}
