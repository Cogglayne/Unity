using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
	Rigidbody2D ballBody;
	static float hits = 0;
	Timer ballDestroyTimer;
    Timer ballMoveTimer;
	BallSpawner spawner;
    float halfColliderWidth;
    bool ballShouldBeMoving = false;
    /// <summary>
    /// Returns number of hits
    /// </summary>
    public static float Hits
    {
        get { return hits; }
    }
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
	{
		spawner = Camera.main.GetComponent<BallSpawner>();
        // timer for ball life time
        ballDestroyTimer = gameObject.AddComponent<Timer>();
		ballDestroyTimer.Duration = ConfigurationUtils.BallLifeTime;
		ballDestroyTimer.Run();
        // timer for movement delay
        ballMoveTimer = gameObject.AddComponent<Timer>();
        ballMoveTimer.Duration = 1;
        ballMoveTimer.Run();
        hits = ConfigurationUtils.StandardBallHit;
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
	}
    /// <summary>
    /// Gets the ball moving
    /// </summary>
	public void StartMovingBall()
	{
        // a random decides the balls initial direction
        int ballDirection = Random.Range(0, 2);
        ballBody = GetComponent<Rigidbody2D>();
        // creates an angle depending on direction
        float angle = 0;
        if (ballDirection == 0)
        {
            angle = Random.Range(-45 * Mathf.Deg2Rad, 45 * Mathf.Deg2Rad);
        }
        else
        {
            angle = Random.Range(135 * Mathf.Deg2Rad, 225 * Mathf.Deg2Rad);
        }
        // gets the ball moving
        Vector2 moveDirection = new Vector2(
         Mathf.Cos(angle), Mathf.Sin(angle));
        ballBody.AddForce(moveDirection * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
    }
    /// <summary>
    ///  Update is called once per frame
    /// </summary>
    void Update()
	{
        // moves ball after 1 second has passed
        if (ballMoveTimer.Finished && !ballShouldBeMoving)
        {
            ballShouldBeMoving = true; // prevents constantly adding force to the ball
            StartMovingBall();
        }
        // destroys ball and then spawns a new ball
		if (ballDestroyTimer.Finished)
		{
            spawner.SpawnBall();
            Destroy(this.gameObject);
        }
	}
    /// <summary>
    /// Changes balls direction depending on where it hits the paddle
    /// </summary>
    /// <param name="direction"></param>
    public void SetDirection(Vector2 direction)
	{
		ballBody.velocity = ballBody.velocity.magnitude * direction;
	}
    /// <summary>
    /// Checks if ball disappeared outside the screen
    /// </summary>
    /// <param name="y"></param>
    /// <returns></returns>
    bool OutsideScreen(float x)
    {
      
        if (x + halfColliderWidth > ScreenUtils.ScreenRight)
        {
            return true;
        }
        if (x - halfColliderWidth < ScreenUtils.ScreenLeft)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Destroys the ball when it leaves the scene
    /// </summary>
    void OnBecameInvisible()
	{
        // prevents Some objects were not cleaned up when closing the scene. (Did you spawn new GameObjects from OnDestroy?)
        if (!this.gameObject.scene.isLoaded)
        {
            return;
        }
        // spawns a new ball when the ball leaves the screen
        if (!ballDestroyTimer.Finished)
        {
            if (OutsideScreen(this.transform.position.x))
            {
                if (this.transform.position.x > 0)
                {
                    HUD.AddScore(ScreenSide.Left, hits);
                }
                else
                {
                    HUD.AddScore(ScreenSide.Right, hits);
                }
            }
            spawner.SpawnBall();
            Destroy(this.gameObject);
        }

    }
}
