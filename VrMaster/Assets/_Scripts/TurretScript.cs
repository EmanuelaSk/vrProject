using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
    public GameObject spawnPoint;
	public float rangeToPlayer;
	public Rigidbody bullet;
	public GameObject player; // Tag for DynamicWaypointSeek
    private bool firing = false;  //Firing status
	private float fireTime;     // Fire Time
	private float coolDown = 1.5F;  // Time to cool down fire
	
	void Start () {
		//player = GameObject.FindWithTag("Player");
	}
    void Update()
    {
        if (PlayerInRange())
        {     // PlayerInRange is bool function defined at the end
              // transform.LookAt(player.transform.position); //Rotates the transform (weapon) so the forward vector points at /target (Player)/'s current position

            if (firing == false)
            {
                firing = true;
                fireTime = Time.time; //keep the current time
                Quaternion leadRot = Quaternion.LookRotation(player.transform.position); //Calculate the angular direction of "Player";   
                bullet = Instantiate(bullet, transform.position, leadRot) as Rigidbody;  // existing object to be copied, Position of Copy, Orientation of Copy
            }
            if (firing && fireTime + coolDown <= Time.time) // prvious time stored in fireTime + cool down time is less --> means the firing must be turn off
                firing = false;
        }
                }

    bool PlayerInRange() {
		return ( Vector3.Distance(player.transform.position, transform.position) <= rangeToPlayer ); //Vector3.Distance(a,b) is the same as (a-b).magnitude.
    }
}
