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
        get { return DifficultyUtils.BallImpulseForce; }
    }
    /// <summary>
    /// Gets the amount of points for a standard ball
    /// </summary>
    public static float StandardBallValue
    {
        get { return data.StandardBallValue; }
    }
    /// <summary>
    /// Gets the amount of points for a bonus ball
    /// </summary>
    public static float BonusBallValue
    {
        get { return data.BonusBallValue; }
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
        get { return DifficultyUtils.MinSpawn; }
    }
    /// <summary>
    /// Gets the max spawn time for a ball
    /// </summary>
    public static float MaxSpawn
    {
        get { return DifficultyUtils.MaxSpawn; }
    }
    #endregion
    /// <summary>
    /// Gets the probability for a standard ball to spawn
    /// </summary>
    public static float StandardBallSpawnRate
    {
        get { return data.StandardBallSpawnRate; }
    }
    /// <summary>
    /// Gets the probability for a bonus ball to spawn
    /// </summary>
    public static float BonusBallSpawnRate
    {
        get { return data.BonusBallSpawnRate; }
    }
    /// <summary>
    /// Gets the probability for a freezer ball pickup to spawn
    /// </summary>
    public static float FreezerBallPickupSpawnRate
    {
        get { return data.FreezerBallPickupSpawnRate; }
    }
    /// <summary>
    /// Gets the probability for a speedup ball pickup to spawn
    /// </summary>
    public static float SpeedupBallPickUpSpawnRate
    {
        get { return data.SpeedupBallPickUpSpawnRate; }
    }
    /// <summary>
    /// Gets the freezer effect duration
    /// </summary>
    public static float FreezerEffectDuration
    {
        get { return data.FreezerEffectDuration; }
    }
    /// <summary>
    /// Gets the duration of speedup
    /// </summary>
    public static float SpeedupEffectDuration
    {
        get { return data.SpeedupEffectDuration; }
    }
    /// <summary>
    /// Gets the speedup factor of speedup
    /// </summary>
    public static float SpeedupEffectFactor
    {
        get { return data.SpeedupEffectFactor; }
    }
    /// <summary>
    /// Gets the easy ball impulse force
    /// </summary>
    public static float EasyBallImpulseForce
    {
        get { return data.EasyBallImpluseForce; }
    }
    /// <summary>
    /// Gets the medium ball impulse force
    /// </summary>
    public static float MediumBallImpulseForce
    {
        get { return data.MediumBallImpluseForce; }
    }
    /// <summary>
    /// Gets the hard ball impulse force
    /// </summary>
    public static float HardBallImpulseForce
    {
        get { return data.HardBallImpluseForce; }
    }
    /// <summary>
    /// Gets the easy min spawn time for a ball
    /// </summary>
    public static float EasyMinSpawn
    {
        get { return data.EasyMinSpawn; }
    }
    /// <summary>
    /// Gets the easy max spawn time for a ball
    /// </summary>
    public static float EasyMaxSpawn
    {
        get { return data.EasyMaxSpawn; }
    }
    /// <summary>
    /// Gets the medium min spawn time for a ball
    /// </summary>
    public static float MediumMinSpawn
    {
        get { return data.MediumMinSpawn; }
    }
    /// <summary>
    /// Gets the medium max spawn time for a ball
    /// </summary>
    public static float MediumMaxSpawn
    {
        get { return data.MediumMaxSpawn; }
    }
    /// <summary>
    /// Gets the hard min spawn time for a ball
    /// </summary>
    public static float HardMinSpawn
    {
        get { return data.HardMinSpawn; }
    }
    /// <summary>
    /// Gets the hard max spawn time for a ball
    /// </summary>
    public static float HardMaxSpawn
    {
        get { return data.HardMaxSpawn; }
    }
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        data = new ConfigurationData();
    }
}
