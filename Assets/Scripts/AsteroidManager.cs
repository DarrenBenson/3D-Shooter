using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] private Asteroid _asteroid;
    [SerializeField] private int _gridSpacing = 10;

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

    private void Start()
    {
        PlaceAsteroids();
    }

    private void PlaceAsteroids()
    {
        for (var x = 0; x < _gridSpacing; x++)
        {
            for (var y = 0; y < _gridSpacing; y++)
            {
                for (var z = 0; z < _gridSpacing; z++){
                    var xPos = MyTransform.position.x + (x * _gridSpacing) + RandomGridOffset();
                    var yPos = MyTransform.position.y + (y * _gridSpacing) + RandomGridOffset();
                    var zPos = MyTransform.position.z + (z * _gridSpacing) + RandomGridOffset();
                    SpawnAsteroid(new Vector3(xPos, yPos, zPos));
                }
            }            
        }
    }

    private float RandomGridOffset()
    {
        return Random.Range(-_gridSpacing/2f, _gridSpacing/2f);
    }

    private void SpawnAsteroid(Vector3 asteroidPosition)
    {
        Instantiate(_asteroid, asteroidPosition, Quaternion.identity, MyTransform);
    }

}