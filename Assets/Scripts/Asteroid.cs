using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField] private float _minScale = 0.8f;
    [SerializeField] private float _maxScale = 1.2f;
    [SerializeField] private float _rotationSpeed = 50f;

    private Transform _transform ;
    private Vector3 _currentRotation;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _transform.localScale = GetRandomVector3(_minScale, _maxScale);
        _currentRotation = GetRandomVector3(_rotationSpeed);
    }

    private void Update()
    {
        _transform.Rotate(_currentRotation * Time.deltaTime);
    }

    private Vector3 GetRandomVector3(float offset)
    {
        return GetRandomVector3(-offset, offset);
    }

    private Vector3 GetRandomVector3(float minRange, float maxRange)
    {
        var returnValue = Vector3.zero;
        returnValue.x = Random.Range(minRange, maxRange);
        returnValue.y = Random.Range(minRange, maxRange);
        returnValue.z = Random.Range(minRange, maxRange);
        return returnValue;
    }


}