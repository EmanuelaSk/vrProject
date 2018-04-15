using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class treasureCollision : MonoBehaviour
{

	public Text hudScore;
    int scoreValue = 15;
    bool scoreInc = false;

    void Awake()
    {

       

    }

    
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == ("Player")){
			scoreInc = true;
			Destroy(this.gameObject);
		}
	}

     void Update()
    {
        if (scoreInc)
        {
			hudScore.text = "Score: " + scoreValue;
            scoreInc = false;
			Debug.Log ("works");
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
