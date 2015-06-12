using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreHandler : Singleton<ScoreHandler> {

    //public Text lblScore;
    public TextMesh Score;
    private float currentScore = 0;
    private float scaleTimerCur;
    private float scaleTimerMax = 3f;

    private Vector3 baseScale;
    private float amplifier = 1.4f;
    private bool isScalingDown;

    void Start()
    {
        baseScale = Score.transform.localScale; 
    }

    public void IncrementScore(float add)
    {
        currentScore += add;
        UpdateText();
    }

    private void UpdateText()
    {
        Score.text = currentScore.ToString();
        scaleTimerCur = 0f;

        if (!isScalingDown)
        {
            isScalingDown = true;
            StartCoroutine(ScaleDown());
        }
    }

    private IEnumerator ScaleDown()
    {
        // Wait and increment.
        yield return new WaitForSeconds(0.001f);
        scaleTimerCur += Time.deltaTime;

        // Adjust font size
        Score.transform.localScale = Vector3.Lerp(baseScale * amplifier, baseScale, scaleTimerCur / scaleTimerMax);

        // If scaled down completely, abort enumerator, else, keep running.
        if (scaleTimerCur >= scaleTimerMax)
        {
            isScalingDown = false;
        }
        else
        {
            StartCoroutine(ScaleDown());
        }
    }
}
