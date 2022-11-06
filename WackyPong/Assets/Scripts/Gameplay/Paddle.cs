using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A paddle
/// </summary>
public class Paddle : MonoBehaviour
{
	Rigidbody2D paddleBody;
	[SerializeField]
	ScreenSide ss;
	Vector2 paddleVector;
	float halfColliderHeight;
	const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;
	HitsAddedEvent hitsAddedEvent = new HitsAddedEvent();
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
	{
		paddleBody = GetComponent<Rigidbody2D>();
		halfColliderHeight = GetComponent<BoxCollider2D>().size.y / 2;
		EventManager.AddHitsAddedInvoker(this);
    }
	/// <summary>
	/// Controls the movement for the right and left paddle
	/// </summary>
	void FixedUpdate()
	{
        // paddle movement keys depend on which side of the screen the paddle is at
        float leftAxisInput = Input.GetAxis("LeftPaddle");
		if (leftAxisInput != 0 && ss == ScreenSide.Left)
		{
            paddleVector = paddleBody.position;
            paddleVector.y += leftAxisInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            paddleVector.y = CalculateClampedY(paddleVector.y);
            paddleBody.MovePosition(paddleVector);
        }
		float rightAxisInput = Input.GetAxis("RightPaddle");
		if (rightAxisInput != 0 && ss == ScreenSide.Right)
		{
            paddleVector = paddleBody.position;
            paddleVector.y += rightAxisInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            paddleVector.y = CalculateClampedY(paddleVector.y);
            paddleBody.MovePosition(paddleVector);
        }
	}
    /// <summary>
    /// Keeps the paddles inside the screen
    /// </summary>
    /// <param name="y"></param>
    /// <returns></returns>
    float CalculateClampedY(float y)
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
			hitsAddedEvent.Invoke(this.ss, coll.gameObject.GetComponent<Ball>().Hits);
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
	public void Freeze(float duration)
	{
		throw new System.NotImplementedException();
	}
    /// <summary>
    /// adds a listener
    /// </summary>
    public void AddHitsAddedListener(UnityAction<ScreenSide, float> listener)
    {
        hitsAddedEvent.AddListener(listener);
    }
}
