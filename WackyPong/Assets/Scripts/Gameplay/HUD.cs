using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI leftText;
    [SerializeField]
    TextMeshProUGUI rightText;
    static TMP_Text leftScore;
    static TMP_Text rightScore;
    static TMP_Text score;
    static float leftCount = 0;
    static float leftScoreCount = 0;
    static float rightCount = 0;
    static float rightScoreCount = 0;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        leftScore = leftText.GetComponent<TextMeshProUGUI>();
        rightScore = rightText.GetComponent<TextMeshProUGUI>();
        score = scoreText.GetComponent<TextMeshProUGUI>();

    }
    /// <summary>
    /// Adds a hit depending on paddle
    /// </summary>
    /// <param name="ss"></param>
    /// <param name="hits"></param>
    public static void AddHits(ScreenSide ss, float hits)
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
    public static void AddScore(ScreenSide ss, float hits)
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

}
