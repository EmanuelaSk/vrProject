using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Camera sourceCam;
	public GameObject targetObj;

	public float slowDistPerc; // Percentage of distance away from target location to toggle slow down.
	private float slowDist;
	public float stopDist;
	public float slowRotPerc; // Percentage of rotation away from target rotation to toggle slow down.
	private float slowRot;
	private float rotLeft; // Rotation remaining to destination rotation.

	private float velocity = 0.0F; // Linear velocity.
	private float rotation = 0.0F; // Angular velocity.
	public float velocityMax;
	public float rotationMax;
	private float accelLinear;
	private float accelAngular;
	public float accelLinearInc;
	public float accelAngularInc;
	public float accelLinearMax;
	public float accelAngularMax;

	private bool hasTarget = false;

	private Vector3 moveTarget;
	private Vector3 destVect;
	private Quaternion destRot;
	private float distTo;

	public bool isMoving = false;
	public GameObject[] waypointArray;
	private int wpIndex = 0;
	private Vector3 offset = new Vector3(0.0f, 0.5f, 0.0f);
	public bool NorthPoint = false, EastPoint = false, SouthPoint = false, WestPoint = false;
	private string wpNorthS, wpEastS, wpSouthS, wpWestS;
	private int wpNorth, wpEast, wpSouth, wpWest;
	public float rayDistance = 8;

	// Use this for initialization
	void Start()
	{
		waypointArray = GameObject.FindGameObjectsWithTag("Waypoint");
	}

	// Update is called once per frame
	void Update()
	{
		if (!isMoving)
		{
			RaycastHit hit;
			//RaycastHit hitNorth;
			//RaycastHit hitEast;
			//RaycastHit hitSouth;
			//RaycastHit hitWest;

			Ray NorthRay = new Ray(transform.position + offset, Vector3.forward);
			Ray EastRay = new Ray(transform.position + offset, Vector3.right);
			Ray SouthRay = new Ray(transform.position + offset, Vector3.back);
			Ray WestRay = new Ray(transform.position + offset, Vector3.left);

			Debug.DrawRay(transform.position + offset, Vector3.forward * rayDistance);
			Debug.DrawRay(transform.position + offset, Vector3.right * rayDistance);
			Debug.DrawRay(transform.position + offset, Vector3.back * rayDistance);
			Debug.DrawRay(transform.position + offset, Vector3.left * rayDistance);

			if (Physics.Raycast(NorthRay, out hit, rayDistance))
			{
				//Debug.Log("Entered North");
				if (hit.collider.tag == "Waypoint")
				{
					//Debug.Log("Entered North");
					Debug.Log(hit.collider.gameObject.name);
					NorthPoint = true;
					wpNorthS = hit.collider.gameObject.name;
					int.TryParse(wpNorthS, out wpNorth);
				}
				else
					NorthPoint = false;
			}
			if (Physics.Raycast(EastRay, out hit, rayDistance))
			{
				//Debug.Log("Entered East");
				if (hit.collider.tag == "Waypoint")
				{
					//Debug.Log("Entered East");
					Debug.Log(hit.collider.gameObject.name);
					EastPoint = true;
					wpEastS = hit.collider.gameObject.name;
					int.TryParse(wpEastS, out wpEast);
				}
				else
					EastPoint = false;
			}
			if (Physics.Raycast(SouthRay, out hit, rayDistance))
			{
				//Debug.Log("Entered South");
				if (hit.collider.tag == "Waypoint")
				{
					//Debug.Log("Entered South");
					Debug.Log(hit.collider.gameObject.name);
					SouthPoint = true;
					wpSouthS = hit.collider.gameObject.name;
					int.TryParse(wpSouthS, out wpSouth);
				}
				else
					SouthPoint = false;
			}
			if (Physics.Raycast(WestRay, out hit, rayDistance))
			{
				//Debug.Log("Entered West");
				if (hit.collider.tag == "Waypoint")
				{
					//Debug.Log("Entered West");
					Debug.Log(hit.collider.gameObject.name);
					WestPoint = true;
					wpWestS = hit.collider.gameObject.name;
					int.TryParse(wpWestS, out wpWest);
				}
				else
					WestPoint = false;
			}

			if ((Input.GetKeyDown(KeyCode.W)) && (NorthPoint = true))
			{
				NorthPoint = false;
				EastPoint = false;
				SouthPoint = false;
				WestPoint = false;
				Debug.Log("North");
				//horn.Play();
				Debug.Log(wpNorth);
				isMoving = true;
				wpIndex = wpNorth;
			}
			else if ((Input.GetKeyDown(KeyCode.D)) && (EastPoint = true))
			{
				NorthPoint = false;
				EastPoint = false;
				SouthPoint = false;
				WestPoint = false;
				Debug.Log("East");
				//horn.Play();
				Debug.Log(wpEast);
				isMoving = true;
				wpIndex = wpEast;
			}
			else if ((Input.GetKeyDown(KeyCode.S)) && (SouthPoint = true))
			{
				NorthPoint = false;
				EastPoint = false;
				SouthPoint = false;
				WestPoint = false;
				Debug.Log("South");
				//horn.Play();
				Debug.Log(wpSouth);
				isMoving = true;
				wpIndex = wpSouth;
			}
			else if ((Input.GetKeyDown(KeyCode.A)) && (WestPoint = true))
			{
				NorthPoint = false;
				EastPoint = false;
				SouthPoint = false;
				WestPoint = false;
				Debug.Log("West");
				//horn.Play();
				Debug.Log(wpWest);
				isMoving = true;
				wpIndex = wpWest;
			}
		}


		//if (Input.GetMouseButtonDown(0))
		//{
		//Ray ray = sourceCam.ScreenPointToRay(Input.mousePosition);
		//RaycastHit hit;
		if (isMoving)
		{
			moveTarget = waypointArray[wpIndex].transform.position;
			targetObj.transform.position = moveTarget + offset;
			hasTarget = true;
			StartMoving();
		}
		//}
		//Debug.DrawLine(sourceCam.transform.position, moveTarget, Color.red, Time.deltaTime, false);

		if (hasTarget)
		{
			// Set the destination vector and rotation.
			destVect = moveTarget - transform.position;
			distTo = destVect.magnitude; // Vector3.Distance(transform.position, moveTarget) does the same thing.

			destRot = Quaternion.LookRotation(destVect);
			rotLeft = Quaternion.Angle(transform.rotation, destRot);

			transform.Translate(Vector3.forward * GetMoveSpeed() * Time.deltaTime);
			velocity = Mathf.Clamp(velocity + accelLinear, 0.0F, velocityMax);
			accelLinear = Mathf.Clamp(accelLinear + accelLinearInc, 0.0F, accelLinearMax);

			transform.rotation = Quaternion.RotateTowards(transform.rotation, destRot, GetRotSpeed() * Time.deltaTime);
			rotation = Mathf.Clamp((rotation + accelAngular), 0.0F, rotationMax);
			accelAngular = Mathf.Clamp((accelAngular + accelAngularInc), 0.0F, accelAngularMax);

			transform.eulerAngles = new Vector3(0.0F, transform.eulerAngles.y, 0.0F); // Ensure no rotation on X-Z axes.

			if (distTo < stopDist)
			{
				hasTarget = false;
				isMoving = false;
				velocity = 0.0F;
			}
		}
	}

	void StartMoving()
	{
		accelLinear = 0.0F;
		accelAngular = 0.0F;
		rotation = 0.0F;

		destVect = moveTarget - transform.position;
		distTo = destVect.magnitude; // Vector3.Distance(transform.position, moveTarget) does the same thing.
		slowDist = distTo * slowDistPerc;

		destRot = Quaternion.LookRotation(destVect);
		rotLeft = Quaternion.Angle(transform.rotation, destRot);
		slowRot = rotLeft * slowRotPerc;
	}

	float GetMoveSpeed()
	{
		return (distTo >= slowDist ? velocity : Mathf.Lerp(0.0F, velocity, distTo / slowDist));
	}

	float GetRotSpeed()
	{
		return (rotLeft >= slowRot ? rotation : Mathf.Lerp(0.0F, rotation, rotLeft / slowRot));
	}
}