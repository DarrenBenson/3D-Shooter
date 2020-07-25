using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] private Asteroid _asteroidPrefab;
    [SerializeField] private int _gridSpacing = 10;

    private List<Asteroid> _asteroidList = new List<Asteroid>();

    private void OnEnable()
    {
        GameEventManager.OnStartGame += PlaceAsteroids;
        GameEventManager.OnPlayerDestroyed += DestroyAsteroids;
    }

    private void OnDisable()
    {
        GameEventManager.OnStartGame -= PlaceAsteroids;
        GameEventManager.OnPlayerDestroyed -= DestroyAsteroids;
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
        var spawnedAsteroid = Instantiate(_asteroidPrefab, asteroidPosition, Quaternion.identity, transform);
        _asteroidList.Add(spawnedAsteroid);
    }

    private void DestroyAsteroids()
    {
        foreach(var asteroid in _asteroidList)
        {
            asteroid.SelfDestruct();
        }
        _asteroidList.Clear();
    }
}