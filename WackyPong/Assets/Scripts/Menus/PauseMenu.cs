using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A pause menu
/// </summary>
public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        Time.timeScale = 0;
    }
    /// <summary>
    /// Quits the game
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void QuitGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(Menu.MainMenu);
    }
    /// <summary>
    /// Resynes the game
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
