using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerUIScript : MonoBehaviour {

	public static int Score;

	Text scoreText;


	void Awake (){
		scoreText = GetComponent <Text> ();
		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + Score;
	}
}
