using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// effect utils
/// </summary>
public static class EffectUtils 
{
    /// <summary>
    /// gets the remaining time on the timer
    /// </summary>
    public static float RemainingTime
    {
        get { return Camera.main.GetComponent<SpeedupEffectMonitor>().RemainingTime; }
    }
    /// <summary>
    /// gets whether speedup is active
    /// </summary>
    public static bool IsActive
    {
        get { return Camera.main.GetComponent<SpeedupEffectMonitor>().IsActive; }
    }
    /// <summary>
    /// gets the speedup factor
    /// </summary>
    public static float SpeedupFactor
    {
        get { return Camera.main.GetComponent<SpeedupEffectMonitor>().SpeedupFactor; }
    }
}
