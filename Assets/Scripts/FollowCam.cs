using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _followPosition = new Vector3(0f, 2f, -10f);
    [SerializeField] private float _followDelay = 0.15f;

    private Vector3 _velocity = Vector3.one;

    private void LateUpdate()
    {
        SmoothFollow();
    }

   private void SmoothFollow()
    {
        if (!FindTarget()) return;

        Vector3 toPosition = _target.position + (_target.rotation * _followPosition);
        transform.position = Vector3.SmoothDamp(transform.position, toPosition, ref _velocity, _followDelay);
        transform.LookAt(_target, _target.up);
    }

    private bool FindTarget()
    {
        if (_target == null)
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                _target = player.transform;
            }
        }
        var foundTarget = (_target != null);
        return foundTarget;
    }

}