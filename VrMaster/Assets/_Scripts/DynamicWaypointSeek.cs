using UnityEngine;
using System.Collections;

public class DynamicWaypointSeek : MonoBehaviour {
    //public Camera sourceCam;
    // public GameObject targetObj;

		
	public float slowDistPerc; // Percentage of distance away from target location to toggle slow down.
	private float slowDist;
	public float stopDist;    // Distance to switch to the next waypoint
	public float slowRotPerc; // Percentage of rotation away from target rotation to toggle slow down.
	private float slowRot;
	private float rotLeft; // Rotation remaining to waypoint 
	
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
	
	private Vector3 moveTarget;     // Temporary variable to keep the position to go to
	private Vector3 destVect;       // vector from the DynamicWaypointSeek toward the position to go
    private float distTo;           // The magnitude of destVect
    private Quaternion destRot;     // The rotation angle of of destVect 


    private int wpIndex = 0;   //0,1,2,3,4
	public GameObject[] waypoints;



    bool move;
	
	void Start () {

        moveTarget = waypoints[ wpIndex ].transform.position;   //The position of the waypoint assigned to moveTarget
		hasTarget = true;
		StartMoving();
	}
	
	void Update () {
     

		if ( hasTarget ) {
			// "Set the destination vector and rotation"
			destVect = moveTarget - transform.position;    // vector from the DynamicWaypointSeek toward the position to go 

            distTo = destVect.magnitude;                   // The magnitude of destVect
            destRot = Quaternion.LookRotation( destVect );  // Amount of angle rotation of destVect with respect to horizon

            //*** Main Movement ***
            transform.Translate( Vector3.forward * GetMoveSpeed() * Time.deltaTime ); //Vector3(0, 0, 1)*speed*delta_T
            transform.rotation = Quaternion.RotateTowards(transform.rotation, destRot, GetRotSpeed() * Time.deltaTime);  //The "1st input" is rotated towards "2nd input" by an angular step of "3rd input"

            velocity = Mathf.Clamp(velocity + accelLinear, 0.0F, velocityMax);
			accelLinear = Mathf.Clamp(accelLinear + accelLinearInc, 0.0F, accelLinearMax);
					

			rotation = Mathf.Clamp((rotation + accelAngular), 0.0F, rotationMax);
			accelAngular = Mathf.Clamp((accelAngular + accelAngularInc), 0.0F, accelAngularMax);
									
			//transform.eulerAngles = new Vector3( 0.0F, transform.eulerAngles.y, 0.0F ); // Ensure no rotation on X-Z axes.
			
			if (distTo < stopDist && wpIndex == waypoints.Length-1) {  // All waypoints met ; waypoints.Length-1 = 4
                hasTarget = false;       // All waypoints are met and there is no more waypoint
                velocity = 0.0F;
			}
			else if (distTo < stopDist && wpIndex != waypoints.Length-1) {       // There is still waypoint to meet and it goes to the next waypoint
				wpIndex++;
				if ( wpIndex == waypoints.Length)  //waypoints.Length=5
                    wpIndex = 0;
				moveTarget = waypoints[ wpIndex ].transform.position;   //The position of the waypoint assigned to moveTarget
                StartMoving();
			}	
		}
	}
	
	void StartMoving()
	{
      
		accelLinear = 0.0F;
		accelAngular = 0.0F;
		rotation = 0.0F;
		
		destVect = moveTarget - transform.position;     // vector from the DynamicWaypointSeek toward the position to go
        distTo = destVect.magnitude;     // The magnitude of destVect
        slowDist = distTo * slowDistPerc;
		
		destRot = Quaternion.LookRotation( destVect );  // Amount of angle rotation of destVect with respect to horizon
        rotLeft = Quaternion.Angle(transform.rotation, destRot);    // Returns the angle difference between the direction of DynamicWaypointSeek and angle of destVect
        slowRot = rotLeft * slowRotPerc;
	}
	
	float GetMoveSpeed()
	{
		return ((distTo >= slowDist)?velocity:Mathf.Lerp(0.0F, velocity, distTo/slowDist)); //Linearly interpolates between a and b by t.The parameter t is clamped to the range[0, 1].
    }
	
	float GetRotSpeed()
	{
		return ((rotLeft >= slowRot)?rotation:Mathf.Lerp(0.0F, rotation, rotLeft/slowRot));
	}

    }

