using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if(GameTypeUtils.GameType == GameType.SinglePlayer)
        {
            GameObject.FindWithTag("RightPaddle").AddComponent<ComputerPaddle>();
        }
        else if (GameTypeUtils.GameType == GameType.TwoPlayer)
        {
            GameObject.FindWithTag("RightPaddle").AddComponent<HumanPaddle>();
        }
        EventManager.AddPlayerWonListener(EndGame);
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(Menu.PauseMenu);
        }
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
    public void EndGame(ScreenSide ss)
    {
    Object message = Object.Instantiate(Resources.Load("GameOverMessage"));
    GameOverMessage gameOverMessage = message.GetComponent<GameOverMessage>();
    gameOverMessage.SetWinner(ss);
    }
}
