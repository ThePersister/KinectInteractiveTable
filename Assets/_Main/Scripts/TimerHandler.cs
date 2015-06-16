using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerHandler : Singleton<TimerHandler> {

	public TextMesh Timer;
	private float scaleTimerCurrent = 0;
	private float scaleTimerMaximum = 60f;
    private bool isIngame = false;
	
	void Update () {
        if (isIngame)
        {
            Timer.text = scaleTimerCurrent.ToString();
            scaleTimerCurrent -= Time.deltaTime;
            scaleTimerCurrent = Mathf.Round(scaleTimerCurrent * 100f) / 100f;
            if (scaleTimerCurrent <= 0f)
            {
                Debug.Log("Done");
                isIngame = false;
                GameManager.Instance.Stop();
                scaleTimerCurrent = 0f;
                Timer.text = "0.00";
            }
        }
	}

    public void SetPlay()
    {
        scaleTimerCurrent = scaleTimerMaximum;
        isIngame = true;
    }
}
