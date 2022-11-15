using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// The event manager
/// </summary>
public static class EventManager
{
    static List<Ball> ballLostInvokers = new List<Ball>();
    static List<UnityAction<ScreenSide, float>> ballLostListeners = new List<UnityAction<ScreenSide, float>>();
    static List<Ball> ballDiedInvokers = new List<Ball>();
    static List<UnityAction> ballDiedListeners = new List<UnityAction>();
    static List<Paddle> hitsAddedInvokers = new List<Paddle>();
    static List<UnityAction<ScreenSide, float>> hitsAddedListeners = new List<UnityAction<ScreenSide, float>>();
    static List<HUD> playerWonInvokers = new List<HUD>();
    static List<UnityAction<ScreenSide>> playerWonListeners = new List<UnityAction<ScreenSide>>();

    /// <summary>
    /// Adds a ball lost invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddBallLostInvoker (Ball invoker)
    {
        ballLostInvokers.Add(invoker);
        foreach (UnityAction<ScreenSide, float> listener in ballLostListeners)
        {
            invoker.AddBallLostListener(listener);  
        }      
    }
    /// <summary>
    /// Adds a ball lost listener
    /// </summary>
    /// <param name="handler"></param>
    public static void AddBallLostListener(UnityAction<ScreenSide, float> listener)
    {
        ballLostListeners.Add(listener);
        foreach (Ball ball in ballLostInvokers)
        {
          ball.AddBallLostListener(listener); 
        }
    }
    /// <summary>
    /// removes a ball lost invoker
    /// </summary>
    public static void RemoveBallLostInvoker(Ball invoker)
    {
        ballLostInvokers.Remove(invoker);
    }
    /// <summary>
    /// Adds a ball died invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Add(invoker);
        foreach (UnityAction listener in ballDiedListeners)
        {
            invoker.AddBallDiedListener(listener);
        }
    }
    /// <summary>
    /// Adds a ball died listener
    /// </summary>
    /// <param name="handler"></param>
    public static void AddBallDiedListener(UnityAction listener)
    {
        ballDiedListeners.Add(listener);
        foreach (Ball ball in ballDiedInvokers)
        {
            ball.AddBallDiedListener(listener);
        }
    }
    /// <summary>
    /// removes a ball lost invoker
    /// </summary>
    public static void RemoveBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Remove(invoker);
    }
    /// <summary>
    /// Adds a hits added invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddHitsAddedInvoker(Paddle invoker)
    {
        hitsAddedInvokers.Add(invoker);
        foreach (UnityAction<ScreenSide, float> listener in hitsAddedListeners)
        {
            invoker.AddHitsAddedListener(listener);
        }
    }
    /// <summary>
    /// Adds a hits added listener
    /// </summary>
    /// <param name="handler"></param>
    public static void AddHitsAddedListener(UnityAction<ScreenSide, float> listener)
    {
        hitsAddedListeners.Add(listener);
        foreach (Paddle paddle in hitsAddedInvokers)
        {
            paddle.AddHitsAddedListener(listener);
        }
    }
    /// <summary>
    /// Adds a play won invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddPlayerWonInvoker(HUD invoker)
    {
        playerWonInvokers.Add(invoker);
        foreach (UnityAction<ScreenSide> listener in playerWonListeners)
        {
            invoker.AddPlayerWonListener(listener);
        }
    }
    /// <summary>
    /// Adds a player won listener
    /// </summary>
    /// <param name="handler"></param>
    public static void AddPlayerWonListener(UnityAction<ScreenSide> listener)
    {
        playerWonListeners.Add(listener);
        foreach (HUD hud in playerWonInvokers)
        {
            hud.AddPlayerWonListener(listener);
        }
    }
}
