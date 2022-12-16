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
    // ball prefabs
    [SerializeField]
    GameObject prefabStandardBall;
    [SerializeField]
    GameObject prefabBonusBall;
    [SerializeField]
    GameObject prefabSpeedupBallPickup;
    [SerializeField]
    GameObject prefabFreezerBallPickup;
    // ball spawning
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
        GameObject tempBall = Instantiate<GameObject>(prefabStandardBall);
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

        // spawn timer 
        ballSpawnTimer = gameObject.AddComponent<Timer>();
        ballSpawnTimer.AddTimerFinishedListener(HandleSpawnTimerFinished);
        ballSpawnTimer.Duration = Random.Range(ConfigurationUtils.MinSpawn, ConfigurationUtils.MaxSpawn);
        ballSpawnTimer.Run();

        // event management
        EventManager.AddBallDiedListener(SpawnBall);
        EventManager.AddBallLostListener(SpawnBall);
    }
    /// <summary>
    /// Checks if a ball will have a collision if it is spawned
    /// </summary>
    /// <param name="arg0"></param>
    /// <param name="arg1"></param>
    void SpawnBall(ScreenSide ss, float hits)
    {
        SpawnBall();
    }

    /// <summary>
    ///  Checks if a ball will have a collision if it is spawned
    /// </summary>
    void SpawnBall()
    {
        // make sure ball does not spawn into a collision
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
            // spawns one of the four balls types depending on their probability
            float spawnDecider = Random.Range(0, 100);
            if (spawnDecider <= ConfigurationUtils.StandardBallSpawnRate)
            {
                 Instantiate(prefabStandardBall, Vector3.zero, Quaternion.identity);
            }
            else if (spawnDecider > ConfigurationUtils.StandardBallSpawnRate && spawnDecider <= (ConfigurationUtils.StandardBallSpawnRate + ConfigurationUtils.BonusBallSpawnRate))
            {
                Instantiate(prefabBonusBall, Vector3.zero, Quaternion.identity);
            }
            else if (spawnDecider > (ConfigurationUtils.StandardBallSpawnRate + ConfigurationUtils.BonusBallSpawnRate) && spawnDecider <= (ConfigurationUtils.StandardBallSpawnRate + ConfigurationUtils.BonusBallSpawnRate + ConfigurationUtils.FreezerBallPickupSpawnRate))
            {
                Instantiate(prefabFreezerBallPickup, Vector3.zero, Quaternion.identity);
            }
            else if (spawnDecider > (ConfigurationUtils.StandardBallSpawnRate + ConfigurationUtils.BonusBallSpawnRate + ConfigurationUtils.FreezerBallPickupSpawnRate) && spawnDecider <= 100)
            {
                Instantiate(prefabSpeedupBallPickup, Vector3.zero, Quaternion.identity);
            }
            AudioManager.Play(AudioClipName.Spawn);
        }
        else
        {
            retrySpawn = true;
        }
    }

    /// <summary>
    /// spawns a ball when the timer finishes
    /// </summary>
    void HandleSpawnTimerFinished()
    {
        // don't stack with a spawn still pending
        retrySpawn = false;
        SpawnBall();
        ballSpawnTimer.Duration = Random.Range(ConfigurationUtils.MinSpawn, ConfigurationUtils.MaxSpawn);
        ballSpawnTimer.Run();
    }
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // try again if spawn still pending
        if (retrySpawn)
        {
            SpawnBall();
        }
    }
}
