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
    static List<PickupBall> freezerEffectActivatedInvokers = new List<PickupBall>();
    static List<UnityAction<ScreenSide, float>> freezerEffectActivatedListeners = new List<UnityAction<ScreenSide, float>>();
    static List<PickupBall> speedupEffectActivatedInvokers = new List<PickupBall>();
    static List<UnityAction<float, float>> speedupEffectActivatedListeners = new List<UnityAction<float, float>>();
    static List<DifficultyMenu> gameStartedInvokers = new List<DifficultyMenu>();
    static List<UnityAction<Difficulty>> gameStartedListeners = new List<UnityAction<Difficulty>>();
    static List<MainMenu> selectGameplayTypeInvokers = new List<MainMenu>();
    static List<UnityAction<GameType>> selectGameplayTypeListeners = new List<UnityAction<GameType>>();
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
    /// <summary>
    /// Adds a freezer effect activated invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddFreezerEffectActivatedInvoker(PickupBall invoker)
    {
        freezerEffectActivatedInvokers.Add(invoker);
        foreach (UnityAction<ScreenSide, float> listener in freezerEffectActivatedListeners)
        {
            invoker.AddFreezerEffectActivatedListener(listener);
        }
    }
    /// <summary>
    /// Adds a freezer effect activated listener
    /// </summary>
    /// <param name="handler"></param>
    public static void AddFreezerEffectActivatedListener(UnityAction<ScreenSide, float> listener)
    {
        freezerEffectActivatedListeners.Add(listener);
        foreach (PickupBall pickupBall in freezerEffectActivatedInvokers)
        {
            pickupBall.AddFreezerEffectActivatedListener(listener);
        }
    }
    /// <summary>
    /// removes a freezer invoker
    /// </summary>
    public static void RemoveFreezerEffectActivatedInvoker(PickupBall invoker)
    {
        freezerEffectActivatedInvokers.Remove(invoker);
    }
    /// <summary>
    /// Adds a speedup effect activated invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddSpeedupEffectActivatedInvoker(PickupBall invoker)
    {
        freezerEffectActivatedInvokers.Add(invoker);
        foreach (UnityAction<float, float> listener in speedupEffectActivatedListeners)
        {
            invoker.AddSpeedupEffectActivatedListener(listener);
        }
    }
    /// <summary>
    /// Adds a speedup effect activated listener
    /// </summary>
    /// <param name="handler"></param>
    public static void AddSpeedupEffectActivatedListener(UnityAction<float, float> listener)
    {
        speedupEffectActivatedListeners.Add(listener);
        foreach (PickupBall pickupBall in freezerEffectActivatedInvokers)
        {
            pickupBall.AddSpeedupEffectActivatedListener(listener);
        }
    }
    /// <summary>
    /// removes a speedup invoker
    /// </summary>
    public static void RemoveSpeedUpEffectActivatedInvoker(PickupBall invoker)
    {
        speedupEffectActivatedInvokers.Remove(invoker);
    }
    /// <summary>
    /// removes a speedup listener
    /// </summary>
    public static void RemoveSpeedUpEffectActivatedListener(UnityAction<float, float> listener)
    {
        speedupEffectActivatedListeners.Remove(listener);
    }
    /// <summary>
    /// Adds a game started invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddGameStartedInvoker(DifficultyMenu invoker)
    {
        gameStartedInvokers.Add(invoker);
        foreach (UnityAction<Difficulty> listener in gameStartedListeners)
        {
            invoker.AddGameStartedListener(listener);
        }
    }
    /// <summary>
    /// Adds a game started listener
    /// </summary>
    /// <param name="handler"></param>
    public static void AddGameStartedListener(UnityAction<Difficulty> listener)
    {
        gameStartedListeners.Add(listener);
        foreach (DifficultyMenu difficultyMenu in gameStartedInvokers)
        {
            difficultyMenu.AddGameStartedListener(listener);
        }
    }
    /// <summary>
    /// Adds a select gameplay type invoker
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddSelectGameplayTypeInvoker(MainMenu invoker)
    {
        selectGameplayTypeInvokers.Add(invoker);
        foreach (UnityAction<GameType> listener in selectGameplayTypeListeners)
        {
            invoker.AddSelectGameplayTypeListener(listener);
        }
    }
    /// <summary>
    /// Adds a select gameplay type listener
    /// </summary>
    /// <param name="handler"></param>
    public static void AddSelectGameplayTypeListener(UnityAction<GameType> listener)
    {
        selectGameplayTypeListeners.Add(listener);
        foreach (MainMenu mainMenu in selectGameplayTypeInvokers)
        {
            mainMenu.AddSelectGameplayTypeListener(listener);
        }
    }
}
