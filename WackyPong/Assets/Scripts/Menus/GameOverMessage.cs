using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// a gamer over message
/// </summary>
public class GameOverMessage : MonoBehaviour
{
    [SerializeField]
    TMP_Text message;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // freezes the game
        Time.timeScale = 0;
    }
    /// <summary>
    /// Displays a message saying which player won when the game is won
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void SetWinner(ScreenSide ss)
    {
        if(ss == ScreenSide.Left){
            message.text = "Player One Won";
        }
        else
        {
            message.text = "Player Two Won";
        }
    }

    /// <summary>
    /// Returns to main menu and unfreezes the game
    /// </summary>
    public void QuitGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(Menu.MainMenu);
    }

}
