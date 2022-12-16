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
    // components
	Rigidbody2D ballBody;
    // ball value
	float value = 0;
    // timers
	Timer ballDestroyTimer;
    Timer ballMoveTimer;
    Timer speedupTimer;
    float halfColliderWidth;
    // events
    BallLostEvent ballLostEvent = new BallLostEvent();
    protected BallDiedEvent ballDiedEvent = new BallDiedEvent();
    // balltype
    [SerializeField]
    protected BallType ballType;
    /// <summary>
    /// Returns number of hits
    /// </summary>
    public float Value
    {
        get { return value; }
    }
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public virtual void Start()
	{
        // rigid body for the ball
        ballBody = GetComponent<Rigidbody2D>();
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
        // speedup timer
        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedListener(SlowDown);
        // sets the value of the ball depending on the ball type
        switch (ballType)
        {
            case BallType.StandardBall:
                value = ConfigurationUtils.StandardBallValue;
                break;
            case BallType.BonusBall:
                value = ConfigurationUtils.BonusBallValue;
                break;
            case BallType.FreezerPickupBall:
                value = 0;
                break;
            case BallType.SpeedupPickupBall:
                value = 0;
                break;
        }
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
        // event management
        EventManager.AddBallLostInvoker(this);
        EventManager.AddBallDiedInvoker(this);
        EventManager.AddSpeedupEffectActivatedListener(Speedup);
	}
    /// <summary>
    /// Gets the ball moving
    /// </summary>
	public void StartMovingBall()
	{
        // a random decides the balls initial direction
        int ballDirection = Random.Range(0, 2);
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
        // applies speedup to a balls initial movement if speedup is active
        if (EffectUtils.IsActive)
        {
            moveDirection *= EffectUtils.SpeedupFactor;
            speedupTimer.Duration = EffectUtils.RemainingTime;
            speedupTimer.Run();
        }    
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
        AudioManager.Play(AudioClipName.LoseBall);
        // spawns a new ball when the ball leaves the screen
        if (!ballDestroyTimer.Finished)
        {
            if (OutsideScreen(this.transform.position.x))
            {
                if (this.transform.position.x > 0)
                {
                    ballLostEvent.Invoke(ScreenSide.Left, value);
                }
                else
                {
                    ballLostEvent.Invoke(ScreenSide.Right, value);
                }
            }
            DestroyBall();
        }

    }
    /// <summary>
    /// Speeds up balls in play
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void Speedup(float speedupFactor, float duration)
    {
        if (!speedupTimer.Running)
        {
            ballBody.velocity *= speedupFactor;
            speedupTimer.Duration = duration;
            speedupTimer.Run();
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }
    /// <summary>
    /// slows down the ball after speedup expires
    /// </summary>
    public void SlowDown()
    {
        ballBody.velocity *= 1 / ConfigurationUtils.SpeedupEffectFactor;
        speedupTimer.Stop();
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
        EventManager.RemoveSpeedUpEffectActivatedListener(Speedup);
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
    /// <summary>
    /// detects collisions with other balls
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            AudioManager.Play(AudioClipName.Hit);
        }
    }
}
