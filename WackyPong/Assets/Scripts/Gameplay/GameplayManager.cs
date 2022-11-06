using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gameplay manager
/// </summary>
public class GameplayManager : MonoBehaviour
{
	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		
	}
    /// <summary>
    /// Call Freeze in Paddle
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void Freeze(ScreenSide side, float duration)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Calls Speedup in Ball
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void SpeedUp(float duration)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Ends the game once a winning score is reached
    /// </summary>
    public void EndGame()
    {

    }
}
