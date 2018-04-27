using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public GameObject loseCanvas; 
	public GameObject winCanvas; 

    int scoreValue = 15;
    bool score = false;
	int scoreInfo = 0;
    void Awake()
    {

       

    }

    void OnTriggerEnter(Collider other)
    {

		if (other.tag == "Chest") {
			Destroy (other.gameObject);
			// Increase the score by the enemy's score value.
			score = true;
			scoreInfo += 15;
		}

		if (other.tag == "Cop") {
			Time.timeScale = 0;
			loseCanvas.SetActive(true);
		}
    }


    private void Update()
    {
        if (score)
        {
            ScoreManager.score += scoreValue;
            score = false;
        }

		if(scoreInfo == 90){
			Time.timeScale = 0;
			winCanvas.SetActive(true);
    }


}
}

    // Update is called once per frame
    //void Update () {
    //    // Perform the raycast against gameobjects on the shootable layer and if it hits something...
    //    if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
    //    {
    //        // Try and find an EnemyHealth script on the gameobject hit.
    //        GoldPickup goldCollide = goldCollide.collider.GetComponent<>
    //            //plBody.collider.GetComponent<isH>();

    //        // If the EnemyHealth component exist...
    //        if (enemyHealth != null)
    //        {
    //            // ... the enemy should take damage.
    //            enemyHealth.TakeDamage(damagePerShot, shootHit.point);
    //        }

    //        // Set the second position of the line renderer to the point the raycast hit.
    //        gunLine.SetPosition(1, shootHit.point);


    //    }
    //}
