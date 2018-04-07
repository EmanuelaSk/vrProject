﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{


    int scoreValue = 15;
    bool score = false;

    void Awake()
    {

       

    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        // Increase the score by the enemy's score value.
        score = true;
    }


    private void Update()
    {
        if (score)
        {
            ScoreManager.score += scoreValue;
            score = false;
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