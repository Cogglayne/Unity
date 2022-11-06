using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
	Rigidbody2D ballBody;
	static float hits = 0;
	Timer ballDestroyTimer;
    Timer ballMoveTimer;
    float halfColliderWidth;
    BallLostEvent ballLostEvent = new BallLostEvent();
    BallDiedEvent ballDiedEvent = new BallDiedEvent();
    /// <summary>
    /// Returns number of hits
    /// </summary>
    public float Hits
    {
        get { return hits; }
    }
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
	{
        // timer for ball life time
        ballDestroyTimer = gameObject.AddComponent<Timer>();
        ballDestroyTimer.AddTimerFinishedListener(HandleDeathTimerFinished);
        ballDestroyTimer.Duration = ConfigurationUtils.BallLifeTime;
		ballDestroyTimer.Run();
        // timer for movement delay
        ballMoveTimer = gameObject.AddComponent<Timer>();
        ballMoveTimer.Duration = 1;
        ballMoveTimer.AddTimerFinishedListener(HandleMoveTimerFinished);
        ballMoveTimer.Run();
        hits = ConfigurationUtils.StandardBallHit;
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
        EventManager.AddBallLostInvoker(this);
        EventManager.AddBallDiedInvoker(this);
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
      
        if (x - halfColliderWidth > ScreenUtils.ScreenRight)
        {
            return true;
        }
        if (x + halfColliderWidth < ScreenUtils.ScreenLeft)
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
                    ballLostEvent.Invoke(ScreenSide.Left, hits);
                }
                else
                {
                    ballLostEvent.Invoke(ScreenSide.Right, hits);
                }
            }
            DestroyBall();
        }

    }
    /// <summary>
    /// Speeds up balls in play
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void SpeedUp(float speedupFactor, float duration)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// adds a ball lost listener
    /// </summary>
    public void AddBallLostListener(UnityAction<ScreenSide, float> listener)
    {
        ballLostEvent.AddListener(listener);
    }
    /// <summary>
    /// adds a ball died listener
    /// </summary>
    public void AddBallDiedListener(UnityAction listener)
    {
        ballDiedEvent.AddListener(listener);
    }

    /// <summary>
    /// stops the timer and starts the ball
    /// </summary>
    void HandleMoveTimerFinished()
    {
        StartMovingBall();
    }
    /// <summary>
    /// destroys a ball
    /// </summary>
    void DestroyBall()
    {
        EventManager.RemoveBallDiedInvoker(this);
        EventManager.RemoveBallLostInvoker(this);
        Destroy(this.gameObject);
    }
    /// <summary>
    /// destroys the ball when the timer finishes
    /// </summary>
    void HandleDeathTimerFinished()
    {
        ballDiedEvent.Invoke();
        DestroyBall();
    }
}
