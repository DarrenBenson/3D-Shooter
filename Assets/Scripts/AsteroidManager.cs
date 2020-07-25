using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] private Asteroid _asteroid;
    [SerializeField] private int _gridSpacing = 10;

    private void OnEnable()
    {
        GameEventManager.OnStartGame += PlaceAsteroids;
    }

    private void OnDisable()
    {
        GameEventManager.OnStartGame -= PlaceAsteroids;
    }

    private void PlaceAsteroids()
    {
        for (var x = 0; x < _gridSpacing; x++)
        {
            for (var y = 0; y < _gridSpacing; y++)
            {
                for (var z = 0; z < _gridSpacing; z++){
                    var xPos = transform.position.x + (x * _gridSpacing) + RandomGridOffset();
                    var yPos = transform.position.y + (y * _gridSpacing) + RandomGridOffset();
                    var zPos = transform.position.z + (z * _gridSpacing) + RandomGridOffset();
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
        Instantiate(_asteroid, asteroidPosition, Quaternion.identity, transform);
    }

}