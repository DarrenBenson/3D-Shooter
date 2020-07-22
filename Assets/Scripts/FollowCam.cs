using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _followPosition = new Vector3(0f, 2f, -10f);
    [SerializeField] private float _followDelay = 0.15f;

    private Vector3 _velocity = Vector3.one;

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

    private void LateUpdate()
    {
        SmoothFollow();
    }

   private void SmoothFollow()
    {
        Vector3 toPosition = _target.position + (_target.rotation * _followPosition);
        MyTransform.position = Vector3.SmoothDamp(MyTransform.position, toPosition, ref _velocity, _followDelay);
        MyTransform.LookAt(_target, _target.up);
    }


}