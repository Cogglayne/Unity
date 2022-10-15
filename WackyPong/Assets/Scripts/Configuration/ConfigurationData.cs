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

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 5;
    static float standardBallHits = 1;
    static float bonusBallHits = 2;
    static float ballLifetime = 10;
    static float minSpawn = 5;
    static float maxSpawn = 10;
    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }
    /// <summary>
    /// Gets the amount of points for a standard ball
    /// </summary>
    public float StandardBallHits
    {
        get { return standardBallHits; }
    }
    /// <summary>
    /// Gets the amount of points for a bonus ball
    /// </summary>
    public float BonusBallHits
    {
        get { return bonusBallHits; }
    }
    /// <summary>
    /// Gets the amount of time a ball should live for
    /// </summary>
    public float BallLifeTime
    {
        get { return ballLifetime; }
    }
    /// <summary>
    /// Gets the min spawn time for a ball
    /// </summary>
    public float MinSpawn
    {
        get { return minSpawn; }
    }
    /// <summary>
    /// Gets the max spawn time for a ball
    /// </summary>
    public float MaxSpawn
    {
        get { return maxSpawn; }
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
            string name = sr.ReadLine();
            string input = sr.ReadLine();
            setValues(input);
        }
        catch(Exception ex)
        {

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
    /// Sets the values usign data from a csv
    /// </summary>
    /// <param name="csvValues"></param>
    static void setValues(string csvValues)
    {
        string[] values = csvValues.Split(",");
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        standardBallHits = float.Parse(values[2]);
        bonusBallHits = float.Parse(values[3]);
        ballLifetime = float.Parse(values[4]);
        minSpawn = float.Parse(values[5]);
        maxSpawn = float.Parse(values[6]);
    }
    #endregion
}
