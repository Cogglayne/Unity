using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";
    Dictionary<ConfigurationDataValueName, float> values = new Dictionary<ConfigurationDataValueName, float>();
    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return values[ConfigurationDataValueName.PaddleMoveUnitsPerSecond]; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return values[ConfigurationDataValueName.BallImpulseForce]; }    
    }
    /// <summary>
    /// Gets the amount of points for a standard ball
    /// </summary>
    public float StandardBallValue
    {
        get { return values[ConfigurationDataValueName.StandardBallValue]; }
    }
    /// <summary>
    /// Gets the amount of points for a bonus ball
    /// </summary>
    public float BonusBallValue
    {
        get { return values[ConfigurationDataValueName.BonusBallValue]; }
    }
    /// <summary>
    /// Gets the amount of time a ball should live for
    /// </summary>
    public float BallLifeTime
    {
        get { return values[ConfigurationDataValueName.BallLifetime]; }
    }
    /// <summary>
    /// Gets the min spawn time for a ball
    /// </summary>
    public float MinSpawn
    {
        get { return values[ConfigurationDataValueName.MinSpawn]; }
    }
    /// <summary>
    /// Gets the max spawn time for a ball
    /// </summary>
    public float MaxSpawn
    {
        get { return values[ConfigurationDataValueName.MaxSpawn]; }
    }
    /// <summary>
    /// Gets the probability for a standard ball to spawn
    /// </summary>
    public float StandardBallSpawnRate
    {
        get { return values[ConfigurationDataValueName.StandardBallSpawnRate]; }
    }
    /// <summary>
    /// Gets the probability for a bonus ball to spawn
    /// </summary>
    public float BonusBallSpawnRate
    {
        get { return values[ConfigurationDataValueName.BonusBallSpawnRate]; }
    }
    /// <summary>
    /// Gets the probability for a freezer ball pickup to spawn
    /// </summary>
    public float FreezerBallPickupSpawnRate
    {
        get { return values[ConfigurationDataValueName.FreezerBallPickupSpawnRate]; }
    }
    /// <summary>
    /// Gets the probability for a speedup ball pickup to spawn
    /// </summary>
    public float SpeedupBallPickUpSpawnRate
    {
        get { return values[ConfigurationDataValueName.SpeedupBallPickupSpawnRate]; }
    }
    /// <summary>
    /// Gets the duration of freezer
    /// </summary>
    public float FreezerEffectDuration
    {
        get { return values [ConfigurationDataValueName.FreezerEffectDuration]; }
    }
    /// <summary>
    /// Gets the duration of speedup
    /// </summary>
    public float SpeedupEffectDuration
    {
        get { return values[ConfigurationDataValueName.SpeedupEffectDuration]; }
    }
    /// <summary>
    /// Gets the speedup factor of speedup
    /// </summary>
    public float SpeedupEffectFactor
    {
        get { return values[ConfigurationDataValueName.SpeedupEffectFactor]; }
    }
    /// <summary>
    /// Gets the easy impulse force
    /// </summary>
    public float EasyBallImpluseForce
    {
        get { return values[ConfigurationDataValueName.EasyBallImpulseForce]; }
    }
    /// <summary>
    /// Gets the medum impulse force
    /// </summary>
    public float MediumBallImpluseForce
    {
        get { return values[ConfigurationDataValueName.MediumBallImpulseForce]; }
    }
    /// <summary>
    /// Gets the hard impulse force
    /// </summary>
    public float HardBallImpluseForce
    {
        get { return values[ConfigurationDataValueName.HardBallImpulseForce]; }
    }
    /// <summary>
    /// Gets the easy min spawn rate
    /// </summary>
    public float EasyMinSpawn
    {
        get { return values[ConfigurationDataValueName.EasyMinSpawn]; }
    }
    /// <summary>
    /// Gets the easy max spawn rate
    /// </summary>
    public float EasyMaxSpawn
    {
        get { return values[ConfigurationDataValueName.EasyMaxSpawn]; }
    }
    /// <summary>
    /// Gets the medium min spawn rate
    /// </summary>
    public float MediumMinSpawn
    {
        get { return values[ConfigurationDataValueName.MediumMinSpawn]; }
    }
    /// <summary>
    /// Gets the medium max spawn rate
    /// </summary>
    public float MediumMaxSpawn
    {
        get { return values[ConfigurationDataValueName.MediumMaxSpawn]; }
    }
    /// <summary>
    /// Gets the hard min spawn rate
    /// </summary>
    public float HardMinSpawn
    {
        get { return values[ConfigurationDataValueName.HardMinSpawn]; }
    }
    /// <summary>
    /// Gets the hard max spawn rate
    /// </summary>
    public float HardMaxSpawn
    {
        get { return values[ConfigurationDataValueName.HardMaxSpawn]; }
    }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string currentLine = sr.ReadLine();
            while (currentLine != null)
            {
                string[] tokens = currentLine.Split(",");
                ConfigurationDataValueName valueName = (ConfigurationDataValueName)Enum.Parse(typeof(ConfigurationDataValueName), tokens[0]);
                values.Add(valueName, float.Parse(tokens[1]));
                currentLine = sr.ReadLine();
            }
        }
        catch(Exception ex)
        {
            SetDefaultValues();
        }
        finally
        {
            if (sr != null)
            {
                sr.Close();
            }
        }
    }
    /// <summary>
    /// sets default values in case of error
    /// </summary>
    void SetDefaultValues()
    {
        values.Clear();
        values.Add(ConfigurationDataValueName.PaddleMoveUnitsPerSecond, 10);
        values.Add(ConfigurationDataValueName.BallImpulseForce, 5);
        values.Add(ConfigurationDataValueName.StandardBallValue, 1);
        values.Add(ConfigurationDataValueName.BonusBallValue, 2);
        values.Add(ConfigurationDataValueName.BallLifetime, 15);
        values.Add(ConfigurationDataValueName.MinSpawn, 5);
        values.Add(ConfigurationDataValueName.MaxSpawn, 10);
        values.Add(ConfigurationDataValueName.StandardBallSpawnRate, 60);
        values.Add(ConfigurationDataValueName.BonusBallSpawnRate, 20);
        values.Add(ConfigurationDataValueName.FreezerBallPickupSpawnRate, 10);
        values.Add(ConfigurationDataValueName.SpeedupBallPickupSpawnRate, 10);
        values.Add(ConfigurationDataValueName.FreezerEffectDuration, 2);
        values.Add(ConfigurationDataValueName.SpeedupEffectDuration, 2);
        values.Add(ConfigurationDataValueName.SpeedupEffectFactor, 2);
        values.Add(ConfigurationDataValueName.EasyBallImpulseForce, 5);
        values.Add(ConfigurationDataValueName.MediumBallImpulseForce, 7);
        values.Add(ConfigurationDataValueName.HardBallImpulseForce, 9);
        values.Add(ConfigurationDataValueName.EasyMinSpawn, 6);
        values.Add(ConfigurationDataValueName.EasyMaxSpawn, 10);
        values.Add(ConfigurationDataValueName.MediumMinSpawn, 4);
        values.Add(ConfigurationDataValueName.MediumMaxSpawn, 8);
        values.Add(ConfigurationDataValueName.HardMinSpawn, 2);
        values.Add(ConfigurationDataValueName.HardMaxSpawn, 6);
    }
    #endregion
}
