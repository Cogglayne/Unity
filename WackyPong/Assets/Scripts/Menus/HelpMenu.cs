using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// A help menu
/// </summary>
public class HelpMenu : MonoBehaviour
{
    /// <summary>
    /// Displays the main menu
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void ShowMainMenu()
    {
        MenuManager.GoToMenu(Menu.MainMenu);
    }
}
