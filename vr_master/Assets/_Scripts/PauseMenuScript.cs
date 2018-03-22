using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {

	public Transform canvas;
	public Transform canvasWin;
	public static bool pauseGame;
	public static bool paused;
	protected float delay;

	AudioSource[] sounds;
	AudioSource music;

	void Start  () {
		delay = 1;
		pauseGame = false;
		Time.timeScale = 1;
		sounds = this.GetComponents<AudioSource> ();
		music = sounds [0];
	}

	// Update is called once per frame
	void Update () {
		if((Input.GetKeyDown(KeyCode.Escape)) && (pauseGame == false)){
			if (canvas.gameObject.activeInHierarchy == false) {
				canvas.gameObject.SetActive (true);
				Time.timeScale = 0;
				music.Pause ();
				paused = true;
			} 
			else {
				canvas.gameObject.SetActive (false);
				Time.timeScale = 1;
				music.UnPause ();
				paused = false;
			}
		}
		if (pauseGame)
			music.Pause ();
		else
			music.UnPause ();
	}

	public void Resume()
	{
		canvas.gameObject.SetActive (false);
		Time.timeScale = 1;
		music.UnPause ();
		pauseGame = false;
	}

	public void Replay()
	{
		SceneManager.LoadScene ("Map");
	}

	public void Quit()
	{
		SceneManager.LoadScene ("Menu");
	}
}
