using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
/// <summary>
/// A main menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    SelectGameplayTypeEvent selectGameplayTypeEvent = new SelectGameplayTypeEvent();
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        EventManager.AddSelectGameplayTypeInvoker(this);
    }
    /// <summary>
    /// Displays the help menu
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void ShowHelpMenu()
    {
        AudioManager.Play(AudioClipName.Click);
        MenuManager.GoToMenu(Menu.HelpMenu);
    }
    /// <summary>
    /// Starts a two player game
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void StartTwoPlayerDifficultyMenuGame()
    {
        AudioManager.Play(AudioClipName.Click);
        selectGameplayTypeEvent.Invoke(GameType.TwoPlayer);
        MenuManager.GoToMenu(Menu.DifficultyMenu);
    }
    /// <summary>
    /// Displays the difficulty menu for 
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void ShowOnePlayerDifficultyMenu()
    {
        AudioManager.Play(AudioClipName.Click);
        selectGameplayTypeEvent.Invoke(GameType.SinglePlayer);
        MenuManager.GoToMenu(Menu.DifficultyMenu);
    }
    /// <summary>
    /// Exits the game
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void ExitGame()
    {
        AudioManager.Play(AudioClipName.Click);
        Application.Quit();
    }
    /// <summary>
    /// adds a select gameplay type listener
    /// </summary>
    /// <param name="listener"></param>
    public void AddSelectGameplayTypeListener(UnityAction<GameType> listener)
    {
        selectGameplayTypeEvent.AddListener(listener);
    }
}
