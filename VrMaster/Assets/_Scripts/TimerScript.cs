using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerScript : MonoBehaviour {

	public Text counterText;
	public float timeStamp;
	public float setTime = 180;
	public bool usingTimer = false;
	public Transform canvasLose;
	//public static bool endGame;

	// Use this for initialization
	void Start () {
		//endGame = false;
		SetTimer (setTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (usingTimer)
			SetUIText ();
	}

	public void SetTimer(float time) {
		if (usingTimer)
			return;

		timeStamp = Time.time + time;
		usingTimer = true;
	}

	public void SetUIText() {
		float timeLeft = timeStamp - Time.time;
		if (timeLeft <= 0) {
			FinishedCount ();
			return;
		}
		float hours;
		float minutes;
		float seconds;
		float miliseconds;
		GetTimeValues (timeLeft, out hours, out minutes, out seconds, out miliseconds);

		if (hours > 0)
			counterText.text = string.Format ("{0}:{1}", hours, minutes);
		else if (minutes > 0)
			counterText.text = string.Format ("{0}:{1}", minutes, seconds);
		else if (seconds > 0)
			counterText.text = string.Format ("{0}:{1}", seconds, miliseconds);
		
	}

	public void GetTimeValues(float time, out float hours, out float minutes, out float seconds, out float miliseconds) {
		hours = (int)(time / 3600f);
		minutes = (int)((time - hours * 3600f) / 60f);
		seconds = (int)((time - hours * 3600f - minutes * 60f));
		miliseconds = (int)((time - hours * 3600f - minutes * 60f - seconds) * 100f);
	}

	public void FinishedCount() {
		Debug.Log("Timer End");
		counterText.text = "00:00";
		PauseMenuScript.pauseGame = true;
		usingTimer = false;

		//Time.timeScale = 0;

		canvasLose.gameObject.SetActive (true);
	}
}
