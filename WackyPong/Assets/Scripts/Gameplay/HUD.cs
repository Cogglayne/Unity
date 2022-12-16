using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

/// <summary>
/// a hud
/// </summary>
public class HUD : MonoBehaviour
{
    // text fields
    [SerializeField]
    TMP_Text leftScore;
    [SerializeField]
    TMP_Text rightScore;
    [SerializeField]
    TMP_Text score;
    // scores and hist
    float leftCount = 0;
    float leftScoreCount = 0;
    float rightCount = 0;
    float rightScoreCount = 0;
    // events
    PlayerWonEvent playerWonEvent = new PlayerWonEvent();
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // reset scores and hits
        leftScoreCount = 0;
        rightScoreCount = 0;    
        rightCount = 0;
        leftCount = 0;
        
        // event management
        EventManager.AddBallLostListener(AddPoints);
        EventManager.AddHitsAddedListener(AddHits);
        EventManager.AddPlayerWonInvoker(this);
    }
    /// <summary>
    /// Adds a hit depending on paddle
    /// </summary>
    /// <param name="ss"></param>
    /// <param name="hits"></param>
    void AddHits(ScreenSide ss, float hits)
    {
        if (ss == ScreenSide.Left)
        {
            leftCount += hits;
            leftScore.text = leftCount.ToString();
        }
        else
        {
            rightCount += hits;
            rightScore.text = rightCount.ToString();
        }
    }
    /// <summary>
    /// Adds score depending on which paddle hit the ball last
    /// </summary>
    void AddPoints(ScreenSide ss, float hits)
    {
        // add points and change text
        if (ss == ScreenSide.Left)
        {
            leftScoreCount += hits;
            score.text = leftScoreCount.ToString() + " - " + rightScoreCount.ToString();
            if(leftScoreCount >= 5)
            {
                playerWonEvent.Invoke(ss);
            }
        }
        else
        {
            rightScoreCount += hits;
            score.text = leftScoreCount.ToString() + " - " + rightScoreCount.ToString();
            if (rightScoreCount >= 5)
            {
                playerWonEvent.Invoke(ss);
            }
        }
    }

    /// <summary>
    /// adds a player won listener
    /// </summary>
    /// <param name=""></param>
    public void AddPlayerWonListener(UnityAction<ScreenSide> listener)
    {
        playerWonEvent.AddListener(listener);
    }
}
