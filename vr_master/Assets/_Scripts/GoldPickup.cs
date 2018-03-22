//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GoldPickup : MonoBehaviour {

//    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
//    public int currentHealth;                   // The current health the enemy has.
//    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.
//  //  public AudioClip pickupClip;                 // The sound to play when the enemy dies.
//    BoxCollider boxCollider;            // Reference to the capsule collider.
//    bool isDead;
//    bool isHit = false;// Whether the enemy is dead.
   

//    void Awake()
//    {
       
//        boxCollider = GetComponent<BoxCollider>();

//        // Setting the current health when the enemy first spawns.
//        currentHealth = startingHealth;
//    }

//    void Update()
//    {
//        playerCollides();
//    }


//    public void playerCollides()
//    {
//        if (isHit)
//        {
//            // If the enemy is dead...
//            if (isDead)
//                // ... no need to take damage so exit the function.
//                return;


//            // Reduce the current health by the amount of damage sustained.
//            currentHealth = 0;


//            // If the current health is less than or equal to zero...
//            if (currentHealth <= 0)
//            {
//                // ... the enemy is dead.
//                Death();
//            }
//        }
//    }


//    void Death()
//    {
//        // The enemy is dead.
//        isDead = true;

//        // Turn the collider into a trigger so shots can pass through it.
//        boxCollider.isTrigger = true;

//        // After 1 second destory the enemy.
//        Destroy(gameObject, 1f);

//        // Increase the score by the enemy's score value.
//         ScoreManager.score += scoreValue;
//        isHit = false;
//    }


//}