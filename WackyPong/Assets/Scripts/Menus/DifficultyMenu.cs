using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// A difficulty menu
/// </summary>
public class DifficultyMenu : MonoBehaviour
{
    GameStartedEvent gameStartedEvent = new GameStartedEvent();
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        EventManager.AddGameStartedInvoker(this);  
    }
    /// <summary>
    /// Starts a single player game on easy difficulty
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void StartEasyGame()
    {
        AudioManager.Play(AudioClipName.Click);
        gameStartedEvent.Invoke(Difficulty.Easy);
    }
    /// <summary>
    /// Starts a single player game on medium difficulty
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void StartMediumGame()
    {
        AudioManager.Play(AudioClipName.Click);
        gameStartedEvent.Invoke(Difficulty.Medium);
    }
    /// <summary>
    /// Starts a single player game on hard difficulty
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public void StartHardGame()
    {
        AudioManager.Play(AudioClipName.Click);
        gameStartedEvent.Invoke(Difficulty.Hard);
    }
    /// <summary>
    /// adds a game started listener
    /// </summary>
    public void AddGameStartedListener(UnityAction<Difficulty> listener)
    {
        gameStartedEvent.AddListener(listener);
    }
}
