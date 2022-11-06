using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// a hud
/// </summary>
public class HUD : MonoBehaviour
{
    [SerializeField]
    TMP_Text leftScore;
    [SerializeField]
    TMP_Text rightScore;
    [SerializeField]
    TMP_Text score;
    float leftCount = 0;
    float leftScoreCount = 0;
    float rightCount = 0;
    float rightScoreCount = 0;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        EventManager.AddBallLostListener(AddPoints);
        EventManager.AddHitsAddedListener(AddHits);
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
        }
        else
        {
            rightScoreCount += hits;
            score.text = leftScoreCount.ToString() + " - " + rightScoreCount.ToString();
        }
    }

    /// <summary>
    /// Checks if a player has a winning score
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public bool CheckScore()
    {
        throw new System.NotImplementedException();
    }
}
