using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// A main menu
/// </summary>
public class MainMenu : MonoBehaviour
{

    /// <summary>
    /// Displays the help menu
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void ShowHelpMenu()
    {
        MenuManager.GoToMenu(Menu.HelpMenu);
    }
    /// <summary>
    /// Starts a two player game
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void StartTwoPlayerGame()
    {
        SceneManager.LoadScene("gameplay");
    }
    /// <summary>
    /// Displays the difficulty menu
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void ShowDifficultyMenu()
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// Exits the game
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void ExitGame()
    {
        Application.Quit();
    }
}
