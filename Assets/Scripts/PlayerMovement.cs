using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float _movementSpeed = 50f;
    [SerializeField] private float _turnSpeed = 60f;
    [SerializeField] private Thruster[] _thrusters;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        Turn();
        Thrust();
    }

    private void Turn()
    {
        float yaw = _turnSpeed * Time.deltaTime * CrossPlatformInputManager.GetAxis("Horizontal");
        float pitch = _turnSpeed * Time.deltaTime * -CrossPlatformInputManager.GetAxis("Mouse Y");
        float roll = _turnSpeed * Time.deltaTime * -CrossPlatformInputManager.GetAxis("Mouse X");
        _transform.Rotate(pitch, yaw, roll);
    }

    private void Thrust()
    {
        if(CrossPlatformInputManager.GetAxis("Vertical") > 0)
        {
            _transform.position += _transform.forward * _movementSpeed * Time.deltaTime * CrossPlatformInputManager.GetAxis("Vertical");
            foreach (var thruster in _thrusters)
            {
                thruster.Activate(true);
            }
        }
        else
        {
            foreach (var thruster in _thrusters)
            {
                thruster.Activate(false);
            }
        }

    }

}