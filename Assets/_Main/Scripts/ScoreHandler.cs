using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreHandler : Singleton<ScoreHandler> {

    public Text lblScore;
    private float currentScore = 0;

    public void IncrementScore(float add)
    {
        currentScore += add;
        UpdateText();
    }

    private void UpdateText()
    {
        lblScore.text = "Score: " + currentScore;
    }
}
