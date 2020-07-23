using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[DisallowMultipleComponent]
public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float _movementSpeed = 50f;
    [SerializeField] private float _turnSpeed = 60f;
    [SerializeField] private Thruster[] _thrusters;

    private Transform _transformCache;
    private Transform TransformCache 
    {
        get
        { 
            if (_transformCache == null) 
            {
                _transformCache = transform;
            }
            return _transformCache;
        }
    }

    private void Update()
    {
        Turn();
        Move();
    }

    private void Turn()
    {
        float yaw = _turnSpeed * Time.deltaTime * CrossPlatformInputManager.GetAxis("Horizontal");
        float pitch = _turnSpeed * Time.deltaTime * -CrossPlatformInputManager.GetAxis("Pitch");
        float roll = _turnSpeed * Time.deltaTime * -CrossPlatformInputManager.GetAxis("Roll");
        TransformCache.Rotate(pitch, yaw, roll);
    }

    private void Move()
    {
        if(CrossPlatformInputManager.GetAxis("Vertical") > 0)
        {
            TransformCache.position += TransformCache.forward * _movementSpeed * Time.deltaTime * CrossPlatformInputManager.GetAxis("Vertical");
            foreach(var thruster in _thrusters)
            {
                thruster.Intensity(CrossPlatformInputManager.GetAxis("Vertical"));
            }
        }
        else
        {
        }

    }


}