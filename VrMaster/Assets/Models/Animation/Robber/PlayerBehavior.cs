using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	public enum AnimState{
		IDLE,
		WALK
	}
	//reference animator in player
	public Animator	PlAnimator;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0) {
			this.PlAnimator.SetInteger ("AnimState", (int)AnimState.WALK);
		} else {
			this.PlAnimator.SetInteger ("AnimState", (int)AnimState.IDLE);
		}
	}
}
