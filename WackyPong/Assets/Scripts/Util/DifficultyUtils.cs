using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// difficulty utils
/// </summary>
public class DifficultyUtils : MonoBehaviour
{
    static Difficulty difficulty;
    /// <summary>
    /// returns the min spawn delay for the the difficulty
    /// </summary>
    public static float MinSpawn
    {
        get {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMinSpawn;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMinSpawn;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMinSpawn;
                default: 
                    return ConfigurationUtils.EasyMinSpawn;

            }
        }
    }
    /// <summary>
    /// returns the max spawn delay for the the difficulty
    /// </summary>
    public static float MaxSpawn
    {
       get {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyMaxSpawn;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumMaxSpawn;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardMaxSpawn;
                default: 
                    return ConfigurationUtils.EasyMaxSpawn;

            }
        }
    }
    /// <summary>
    /// returns the ball impulse for the the difficulty
    /// </summary>
    public static float BallImpulseForce
    {
       get {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return ConfigurationUtils.EasyBallImpulseForce;
                case Difficulty.Medium:
                    return ConfigurationUtils.MediumBallImpulseForce;
                case Difficulty.Hard:
                    return ConfigurationUtils.HardBallImpulseForce;
                default: 
                    return ConfigurationUtils.EasyBallImpulseForce;

            }
        }
    }
    /// <summary>
    /// add listener
    /// </summary>
    public static void Initialize()
    {
        EventManager.AddGameStartedListener(StartGame);
    }

    /// <summary>
    /// starts the game
    /// </summary>
    public static void StartGame(Difficulty gameDifficulty)
    {
        difficulty = gameDifficulty;
        SceneManager.LoadScene("gameplay");
    }
}
