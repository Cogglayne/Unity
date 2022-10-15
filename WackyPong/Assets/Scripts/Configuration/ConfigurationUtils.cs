using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData data;
    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return data.PaddleMoveUnitsPerSecond; }
    }
    /// <summary>
    /// Gets the balls impulse force
    /// </summary>
    public static float BallImpulseForce
    {
        get { return data.BallImpulseForce; }
    }
    /// <summary>
    /// Gets the amount of points for a standard ball
    /// </summary>
    public static float StandardBallHit
    {
        get { return data.StandardBallHits; }
    }
    /// <summary>
    /// Gets the amount of points for a bonus ball
    /// </summary>
    public static float BonusBallHits
    {
        get { return data.BonusBallHits; }
    }
    /// <summary>
    /// Gets how long the ball should live for
    /// </summary>
    public static float BallLifeTime
    {
        get { return data.BallLifeTime; }
    }
    /// <summary>
    /// Gets the min spawn time for a ball
    /// </summary>
    public static float MinSpawn
    {
        get { return data.MinSpawn; }
    }
    /// <summary>
    /// Gets the max spawn time for a ball
    /// </summary>
    public static float MaxSpawn
    {
        get { return data.MaxSpawn; }
    }
    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        data = new ConfigurationData();
    }
}
