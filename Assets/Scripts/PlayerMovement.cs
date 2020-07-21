using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float movementSpeed = 50f;
    [SerializeField] private float turnSpeed = 60f;

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
        float yaw = turnSpeed * Time.deltaTime * CrossPlatformInputManager.GetAxis("Mouse X");
        float pitch = turnSpeed * Time.deltaTime * -CrossPlatformInputManager.GetAxis("Mouse Y");
        float roll = turnSpeed * Time.deltaTime * -CrossPlatformInputManager.GetAxis("Horizontal");
        _transform.Rotate(pitch, yaw, roll);
    }

    private void Thrust()
    {
            _transform.position += _transform.forward * movementSpeed * Time.deltaTime * CrossPlatformInputManager.GetAxis("Vertical");
    }

}