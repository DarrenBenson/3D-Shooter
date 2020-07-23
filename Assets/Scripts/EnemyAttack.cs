using TMPro;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private Laser[] _lasers;

    private Vector3 _hitPosition;

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
        var inFront = TargetInfront();
        var canHit = HaveRaycastLineOfSight();
        if (TargetInfront() && HaveRaycastLineOfSight())
        {
            FireLaser();
        }
    }

    private bool TargetInfront()
    {
        Vector3 directionToTarget = MyTransform.position - _target.position;
        float angle = Vector3.Angle(MyTransform.forward, directionToTarget);
        if (Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private bool HaveRaycastLineOfSight()
    {
        Vector3 attackDirection = _target.position - MyTransform.position;
        foreach (var laser in _lasers)
        {
            if (Physics.Raycast(laser.transform.position, attackDirection, out RaycastHit hit, laser.Distance))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.DrawRay(laser.transform.position, attackDirection, Color.green);
                    _hitPosition = hit.transform.position;
                    return true;
                }
            }

        }
        return false;
    }

    private void FireLaser()
    {
        foreach (var laser in _lasers)
        {
            laser.FireLaser(_hitPosition, _target);
        }
    }

}
