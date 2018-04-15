using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootingScript : MonoBehaviour {


    public float velocity = 200.0F;
	public float cooldown = 0.5F;
	public float fireTime;
	public GameObject bulletSpawn;
	public Rigidbody bullet;
	public Text Ammo;
	private int ammoCount = 7;
	private bool shotFired = false;
	public Clip clips;


	//public Rigidbody rb = bullet.Get Component<Rigidbody>();

	// Use this for initialization
	void Start () {

    }

// Update is called once per frame
    void Update ()
    {
		Ammo.text = "Ammo " + ammoCount;
	  //  bool hasAmmo = false;
		if (ammoCount != 0) {
			
			if (Input.GetButtonDown ("Fire1") && !shotFired) {
				Fire ();
				ammoCount = ammoCount - 1;
			}
			if (shotFired && fireTime + cooldown <= Time.time) {
				shotFired = false;
			}
		}

		if (ammoCount == 0) {
			shotFired = true;
			fireTime = 5000000;
		}
		if(Input.GetKeyDown(KeyCode.R)/* && hasAmmo == true*/){
			fireTime = Time.time;
		}

	}

    void Fire()
    {
		Rigidbody bulletInstance = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation) as Rigidbody;
		bulletInstance.AddForce(transform.forward * velocity);
		Destroy(bulletInstance.gameObject, 1.0F);
		fireTime = Time.time;
		shotFired = true;
    }
}
