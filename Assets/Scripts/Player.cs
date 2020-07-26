using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[DisallowMultipleComponent]
public class Player : MonoBehaviour {

    [SerializeField] private float _movementSpeed = 50f;
    [SerializeField] private float _turnSpeed = 60f;
    [SerializeField] private Thruster[] _thrusters;
    [SerializeField] private Laser[] _lasers;

    private void Update()
    {
        Fire();
        Turn();
        Move();
    }

    private void Fire()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            foreach (var laser in _lasers)
            {
                laser.FireLaser();
            }
        }
    }

    private void Turn()
    {
        float yaw = _turnSpeed * Time.deltaTime * CrossPlatformInputManager.GetAxis("Horizontal");
        float pitch = _turnSpeed * Time.deltaTime * -CrossPlatformInputManager.GetAxis("Pitch");
        float roll = _turnSpeed * Time.deltaTime * -CrossPlatformInputManager.GetAxis("Roll");
        transform.Rotate(pitch, yaw, roll);
    }

    private void Move()
    {
        if(CrossPlatformInputManager.GetAxis("Vertical") > 0)
        {
            transform.position += transform.forward * _movementSpeed * Time.deltaTime * CrossPlatformInputManager.GetAxis("Vertical");
            foreach(var thruster in _thrusters)
            {
                thruster.Intensity(CrossPlatformInputManager.GetAxis("Vertical"));
            }
        }
    }

}