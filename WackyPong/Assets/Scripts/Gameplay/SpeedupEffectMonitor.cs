using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// monitors speedup
/// </summary>
public class SpeedupEffectMonitor : MonoBehaviour
{
    Timer speedupTimer;
    bool isActive;
    float speedupFactor;
    /// <summary>
    /// gets the remaining time on the timer
    /// </summary>
    public float RemainingTime
    {
        get { return speedupTimer.RemainingTime; }
    }
    /// <summary>
    /// gets whether speedup is active
    /// </summary>
    public bool IsActive
    {
        get { return isActive; }
    }
    /// <summary>
    /// gets the speedup factor
    /// </summary>
    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedListener(SpeedupEffectFinished);
        EventManager.AddSpeedupEffectActivatedListener(Speedup);
    }
    /// <summary>
    /// listen for speedup event
    /// </summary>
    void Speedup(float speedupFactor, float duration)
    {
        if (!speedupTimer.Running)
        {
            AudioManager.Play(AudioClipName.Speedup);
            this.speedupFactor = speedupFactor;
            isActive = true;
            speedupTimer.Duration = duration;
            speedupTimer.Run();
        }
        else
        {
            speedupTimer.AddTime(duration);
        }
    }
    /// <summary>
    /// stops speedup effect
    /// </summary>
    void SpeedupEffectFinished()
    {
        AudioManager.Play(AudioClipName.SpeedupDeactivated);
        isActive = false;
        speedupTimer.Stop();
    }
}
