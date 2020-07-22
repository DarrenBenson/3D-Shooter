using TMPro;
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

    private void Update()
    {
        TargetInfront();
    }

    private bool TargetInfront()
    {
        Vector3 directionToTarget = MyTransform.position - _target.position;
        float angle = Vector3.Angle(MyTransform.forward, directionToTarget);
        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            Debug.DrawLine(transform.position, _target.position, Color.red);
            return true;
        }
        else
        {
            Debug.DrawLine(transform.position, _target.position, Color.green);
            return false;
        }

    }

}
