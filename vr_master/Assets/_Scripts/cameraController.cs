using System.Collections;
//using static System.Collections.Generic.List<UnityEngine.Camera>;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {


    public List<Camera> theCams;
    int currCamIndex;



	// Use this for initialization
	void Start () {
        //currCamIndex = 0;

        //turn all cams off except for current at inddex 0
        for (int i =1; i<theCams.Capacity; i++)
        {
            theCams[i].gameObject.SetActive(false);
        }
        if (theCams.Capacity > 0)
        {
            theCams[0].gameObject.SetActive(true);
          //  Debug.Log("cam: " + theCams[0].name + "  is now enabled");
        }
      

    }
	


	// Update is called once per frame
	void Update () {

        //if cam is pressed
        //want to switch to on raycast select

        if (Input.GetKeyDown(KeyCode.A))
        { 
            currCamIndex = currCamIndex + 1;
            Debug.Log("switching cam's"); 
            }
        else if (Input.GetKeyUp(KeyCode.A)){ 
                currCamIndex = currCamIndex;
            
        }
        if (currCamIndex < theCams.Capacity)
        {
         
            theCams[currCamIndex - 1].gameObject.SetActive(false);
            theCams[currCamIndex].gameObject.SetActive(true);
          //  Debug.Log("Camera with name: " + theCams[currCamIndex].name + ", is now enabled");
        }
        else
        {
            theCams[currCamIndex - 1].gameObject.SetActive(false);
            currCamIndex = 0;
            theCams[currCamIndex].gameObject.SetActive(true);
          //  Debug.Log("Camera with name: " + theCams[currCamIndex].name + ", is now enabled");
        }


    }
}
