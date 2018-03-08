using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour {
	public Transform settingTab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Resume() {
		if (settingTab.gameObject.activeInHierarchy == false) {
			settingTab.gameObject.SetActive (true);
	}
		else{
			settingTab.gameObject.SetActive (false);
	}
   }

}
