using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {

		private Transform target;
		public float range = 15f;
		[SerializeField] GameObject player;

		AudioSource aud;


		void Start () {
			InvokeRepeating ("updateTarget", 0f, 0.5f);

		}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Bullet") {
			Destroy (gameObject);
		
		}

	}

		void updateTarget(){

			float distanceToEnemy = Vector3.Distance (transform.position, player.transform.position);

			if (distanceToEnemy > range) {
				target = null;

			}
			if (distanceToEnemy <= range) {
				target = player.transform;

			}
		}
		void Update () {
			if (target == null )
				return;

			transform.LookAt(target); 
			transform.Translate(Vector3.forward*10*Time.deltaTime);

		}


		void OnDrawGizmosSelected(){
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere (transform.position, range);
		}
	}

