using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;        // The player's score.
 //   public Transform canvasWin;
//	public Transform canvasLose;
    public Text text;                      // Reference to the Text component.




    void Awake()
    {
        
    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Score: " + score;
   //     winCondition();

    }

  //  void winCondition()
   // {
     //   if (score >= 45)
    //    {
            //PauseMenuScript.pauseGame = true;

//            canvasWin.gameObject.SetActive(true);
 
     //   }
  //  }


}



