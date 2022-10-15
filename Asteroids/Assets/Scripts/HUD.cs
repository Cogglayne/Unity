using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// A hud
/// </summary>
public class HUD : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    float elapsedSeconds = 0;
    bool timerIsRunning = true;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        textMeshProUGUI.text = "0"; 
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (timerIsRunning)
        {
            // updates and displays timer
            elapsedSeconds += Time.deltaTime;
            textMeshProUGUI.text = ((int)elapsedSeconds).ToString();
        }
    }
    /// <summary>
    /// Stops timer when ship is destroyed
    /// </summary>
    public void StopGameTimer()
    {
        timerIsRunning = false;
    }
}
