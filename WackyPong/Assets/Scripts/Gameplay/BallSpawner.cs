using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/// <summary>
/// A ball spawner
/// </summary>
public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBall;
    Timer ballSpawnTimer;
    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // Saving lower left and upper right corners
        GameObject tempBall = Instantiate<GameObject>(prefabBall);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
        tempBall.transform.position.x - ballColliderHalfWidth,
        tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
        tempBall.transform.position.x + ballColliderHalfWidth,
        tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);

        ballSpawnTimer = gameObject.AddComponent<Timer>();
        ballSpawnTimer.Duration = Random.Range(ConfigurationUtils.MinSpawn, ConfigurationUtils.MaxSpawn);
        ballSpawnTimer.Run();
    }
    /// <summary>
    ///  Checks if a ball will have a collision if it is spawned
    /// </summary>
    public void SpawnBall()
    {
        // make sure ball does not spawn into a collision
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
        }
        else
        {
            retrySpawn = true;
        }
    }
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // checks if the timer is finished before attempting to spawn a ball
        if (ballSpawnTimer.Finished)
        {
            // retry spawn is set to true so the spawnball method will check if there is a spawn collison as long as the spawn timer is finished
            retrySpawn = true;
            if (retrySpawn)
            {
                SpawnBall();
            }
            // if there is no spawn collision a ball is spawned and the timer is reset
            if (!retrySpawn)
            {
                Instantiate(prefabBall, Vector3.zero, Quaternion.identity);
                ballSpawnTimer.Duration = Random.Range(ConfigurationUtils.MinSpawn, ConfigurationUtils.MaxSpawn);
                ballSpawnTimer.Run();
            }
        }
    }
}
