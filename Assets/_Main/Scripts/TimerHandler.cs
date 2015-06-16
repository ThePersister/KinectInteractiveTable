using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerHandler : Singleton<TimerHandler> {

	public TextMesh Timer;
	private float scaleTimerCurrent = 0;
	private float scaleTimerMaximum = 60f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Timer.text = scaleTimerCurrent.ToString();
		scaleTimerCurrent += Time.deltaTime;
		scaleTimerCurrent = Mathf.Round(scaleTimerCurrent * 100f) / 100f;
		if (scaleTimerCurrent >= scaleTimerMaximum)
		{
			Debug.Log("Done");
			scaleTimerCurrent = 0f;
		}
	}
}
