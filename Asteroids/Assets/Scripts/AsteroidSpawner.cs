using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Spawns asteroids
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;
    Asteroid asteroid;
    float asteroidRadius;
    Vector3 location;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        
        asteroidRadius = prefabAsteroid.GetComponent<CircleCollider2D>().radius;
        // creates asteroid to the right of the screen going left
        GameObject asteroidRight = Instantiate(prefabAsteroid);
        location = new Vector3(ScreenUtils.ScreenRight + asteroidRadius * 2, 0, -Camera.main.transform.position.z);
        asteroid = asteroidRight.GetComponent<Asteroid>();
        asteroid.Initialize(Direction.Left, location);
        // creates asteroid above the screen going down
        GameObject asteroidTop = Instantiate(prefabAsteroid);
        location = new Vector3(0, ScreenUtils.ScreenTop + asteroidRadius * 2, -Camera.main.transform.position.z);
        asteroid = asteroidTop.GetComponent<Asteroid>();
        asteroid.Initialize(Direction.Down, location);
        // creates asteroid to the left of the screen going right
        GameObject asteroidLeft = Instantiate(prefabAsteroid);
        location = new Vector3(ScreenUtils.ScreenLeft - asteroidRadius * 2, 0, -Camera.main.transform.position.z);
        asteroid = asteroidLeft.GetComponent<Asteroid>();
        asteroid.Initialize(Direction.Right, location);
        // creates asteroid below the screen going up
        GameObject asteroidBottom = Instantiate(prefabAsteroid);
        location = new Vector3(0, ScreenUtils.ScreenBottom - asteroidRadius * 2, -Camera.main.transform.position.z);
        asteroid = asteroidBottom.GetComponent<Asteroid>();
        asteroid.Initialize(Direction.Up, location);
    }
}
