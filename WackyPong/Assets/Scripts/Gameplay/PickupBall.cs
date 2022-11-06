using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A pickup ball
/// </summary>
public class PickupBall : Ball
{
    private PickupEffect effect;
    private float duration;
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
    void Start()
    {
 
    }

    /// <summary>
    ///  Update is called once per frame
    /// </summary>
    void Update()
    {
        
    }
}
