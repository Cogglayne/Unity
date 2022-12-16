using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A paddle
/// </summary>
public abstract class Paddle : MonoBehaviour
{
	// components
	protected Rigidbody2D paddleBody;
    protected Vector2 paddleVector;
	// Screenside
	protected ScreenSide ss;
	// floats
	float halfColliderHeight;
	const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;
	// events
	HitsAddedEvent hitsAddedEvent = new HitsAddedEvent();
	// timers
	Timer freezeTimer;
	// bools
	bool isFrozen;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public virtual void Start()
	{
		if(tag == "LeftPaddle")
		{
			ss = ScreenSide.Left;
		}else if (tag == "RightPaddle")
		{
			ss = ScreenSide.Right;
		}
		// gets the components
		paddleBody = GetComponent<Rigidbody2D>();
		halfColliderHeight = GetComponent<BoxCollider2D>().size.y / 2;

		// event management
		EventManager.AddHitsAddedInvoker(this);
		EventManager.AddFreezerEffectActivatedListener(Freeze);

		// freze timer
		freezeTimer = gameObject.AddComponent<Timer>();
		freezeTimer.AddTimerFinishedListener(UnFreeze);
    }
	/// <summary>
	/// Controls the movement for the right and left paddle
	/// </summary>
	void FixedUpdate()
	{
        if (!isFrozen)
        {
			UpdatePaddle();
        }
    }
    /// <summary>
    /// Keeps the paddles inside the screen
    /// </summary>
    /// <param name="y"></param>
    /// <returns></returns>
    protected float CalculateClampedY(float y)
    {
        // checks if half the paddles collider is out of the screen 
        // returns a new y if the original y was outside the screen, returns the original y otherwise
        if (y + halfColliderHeight > ScreenUtils.ScreenTop)
        {
            y = ScreenUtils.ScreenTop - halfColliderHeight;
        }
        if (y - halfColliderHeight < ScreenUtils.ScreenBottom)
        {
            y = ScreenUtils.ScreenBottom + halfColliderHeight;
        }
        return y;
    }

    /// <summary>
    /// Check to see if the ball is hitting the front of the paddle
    /// </summary>
    /// <param name="coll"></param>
    /// <param name="ss"></param>
    /// <returns></returns>
    bool CheckFront(Collision2D coll)
    {
        ContactPoint2D contact0 = coll.GetContact(0);
        ContactPoint2D contact1 = coll.GetContact(1);
        return Mathf.Abs(contact0.point.x - contact1.point.x) < .05f;
    }
	/// <summary>
	/// Detects collision with a ball to aim the ball
	/// </summary>
	/// <param name="coll">collision info</param>
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("Ball") && CheckFront(coll))
		{
			AudioManager.Play(AudioClipName.Hit);
			hitsAddedEvent.Invoke(this.ss, coll.gameObject.GetComponent<Ball>().Value);
			// calculate new ball direction
			float ballOffsetFromPaddleCenter =
				coll.transform.position.y - transform.position.y;
			float normalizedBallOffset = ballOffsetFromPaddleCenter /
				halfColliderHeight;
			float angleOffset = normalizedBallOffset * BounceAngleHalfRange;

			// angle modification is based on screen side
			float angle;
			if (ss == ScreenSide.Left)
			{
				angle = angleOffset;
			}
			else
			{
				angle = (float)(Mathf.PI - angleOffset);
			}
			Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

			// tell ball to set direction to new direction
			Ball ballScript = coll.gameObject.GetComponent<Ball>();
			ballScript.SetDirection(direction);
        }
	}
	/// <summary>
	/// Freezes opponents paddle
	/// </summary>
	/// <exception cref="System.NotImplementedException"></exception>
	public void Freeze(ScreenSide side, float duration)
	{
        if (ss == side)
        {
            isFrozen = true;
            if (!freezeTimer.Running)
            {
                AudioManager.Play(AudioClipName.Freezer);
                freezeTimer.Duration = duration;
                freezeTimer.Run();
            }
            else
            {
                freezeTimer.AddTime(duration);
            }
        }

	}
	/// <summary>
	/// Unfreeze the paddle
	/// </summary>
	void UnFreeze()
	{
        AudioManager.Play(AudioClipName.FreezerDeactivated);
        isFrozen = false;
		freezeTimer.Stop();
	}
    /// <summary>
    /// adds a listener
    /// </summary>
    public void AddHitsAddedListener(UnityAction<ScreenSide, float> listener)
    {
        hitsAddedEvent.AddListener(listener);
    }
	/// <summary>
	/// moves paddle location if needed
	/// </summary>
	protected abstract void UpdatePaddle();
	/// <summary>
	/// called in update paddle to move the paddle
	/// </summary>
	protected abstract void PaddleMove(float input);
}
