using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// game type utils
/// </summary>
public static class GameTypeUtils 
{
    static GameType gameType;
    /// <summary>
    /// gets the gameplay type
    /// </summary>
    public static GameType GameType
    {
        get { return gameType; }
    }
    /// <summary>
    /// add listener
    /// </summary>
    public static void Initialize()
    {
        EventManager.AddSelectGameplayTypeListener(StartGame);
    }
    /// <summary>
    /// starts the game
    /// </summary>
    public static void StartGame(GameType oneOrTwoPlayer)
    {
        gameType = oneOrTwoPlayer;
    }
}
