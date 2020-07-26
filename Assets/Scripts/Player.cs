using UnityEngine;

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
        if (Input.GetButton("Fire1"))
        {
            foreach (var laser in _lasers)
            {
                laser.FireLaser();
            }
        }
    }

    private void Turn()
    {
        float yaw = _turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = _turnSpeed * Time.deltaTime * -Input.GetAxis("Vertical");
        float roll = _turnSpeed * Time.deltaTime * -Input.GetAxis("Roll");
        transform.Rotate(pitch, yaw, roll);
    }

    private void Move()
    {
        if(Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.forward * _movementSpeed * Time.deltaTime * (Input.GetButton("Fire3")?1:0);
            foreach(var thruster in _thrusters)
            {
                thruster.Intensity(Input.GetAxis("Vertical"));
            }
        }
    }

}