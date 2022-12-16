using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// A menu manager
/// </summary>
public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Goes to a menu depending on menu enum
    /// </summary>
    /// <param name="menu"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    public static void GoToMenu(Menu name)
    {
        switch (name)
        {
            case Menu.DifficultyMenu:
                SceneManager.LoadScene("difficulty");
                break;
            case Menu.PauseMenu:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case Menu.MainMenu:
                SceneManager.LoadScene("mainmenu");
                break;
            case Menu.HelpMenu:
                SceneManager.LoadScene("helpmenu");
                break;
        }
    }
}
