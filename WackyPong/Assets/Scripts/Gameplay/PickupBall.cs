using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// A pickup ball
/// </summary>
public class PickupBall : Ball
{
    // Effect
    PickupEffect effect;
    // timer duration
    float duration;
    // Events
    FreezerEffectActivatedEvent freezerEffectActivatedEvent = new FreezerEffectActivatedEvent();
    SpeedupEffectActivatedEvent speedupEffectActivatedEvent = new SpeedupEffectActivatedEvent();
    /// <summary>
    /// Gets the type of effect the pickup ball has for the paddle to use
    /// </summary>
    public PickupEffect Effect
    {
        get { return effect; }
    }
    /// <summary>
    /// Gets the pickupball's duration for the paddle to use
    /// </summary>
    public float Duration
    {
        get { return duration; }
    }
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public override void Start()
    {
        // calls parent start
        base.Start();
        // instantiates an event based on pickup type
        if (ballType.Equals(BallType.FreezerPickupBall))
        {
            duration = ConfigurationUtils.FreezerEffectDuration;
            EventManager.AddFreezerEffectActivatedInvoker(this);
        }
        if (ballType.Equals(BallType.SpeedupPickupBall))
        {
            duration = ConfigurationUtils.SpeedupEffectDuration;
            EventManager.AddSpeedupEffectActivatedInvoker(this);
        }
    }
    /// <summary>
    /// adds a freezer effect activated listener
    /// </summary>
    public void AddFreezerEffectActivatedListener(UnityAction<ScreenSide, float> listener)
    {
        freezerEffectActivatedEvent.AddListener(listener);
    }
    /// <summary>
    /// adds a speedup effect activated listener
    /// </summary>
    public void AddSpeedupEffectActivatedListener(UnityAction<float, float> listener)
    {
        speedupEffectActivatedEvent.AddListener(listener);
    }
    /// <summary>
    /// Collision detection for events
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        // if the collision is with a paddle either a speed up or freezer event is invoked depending on pickup type
        if(coll.gameObject.tag == "LeftPaddle" || coll.gameObject.tag == "RightPaddle")
        {
            if (ballType.Equals(BallType.FreezerPickupBall))
            {
                if (coll.gameObject.tag == "LeftPaddle")
                {
                    freezerEffectActivatedEvent.Invoke(ScreenSide.Right, duration);
                }
                else if (coll.gameObject.tag == "RightPaddle")
                {
                    freezerEffectActivatedEvent.Invoke(ScreenSide.Left, duration);
                }
                // destroys self and calls for a new ball to be spawned
                ballDiedEvent.Invoke();
                EventManager.RemoveFreezerEffectActivatedInvoker(this);
                Destroy(this.gameObject);
            }
            if (ballType.Equals(BallType.SpeedupPickupBall))
            {
                speedupEffectActivatedEvent.Invoke(ConfigurationUtils.SpeedupEffectFactor, duration);
                // destroys self and calls for a new ball to be spawned
                ballDiedEvent.Invoke();
                EventManager.RemoveSpeedUpEffectActivatedInvoker(this);
                Destroy(this.gameObject);
            }
        }
    }
}
