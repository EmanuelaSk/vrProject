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
    private Vector3 offset = new Vector3(0.0f, 0.5f, 0.0f);

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = sourceCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Waypoint")
                {
                    moveTarget = hit.transform.position - offset;
                    targetObj.transform.position = moveTarget + offset;
                    hasTarget = true;
                    StartMoving();
                }
            }
        }
        Debug.DrawLine(sourceCam.transform.position, moveTarget, Color.red, Time.deltaTime, false);

        if (hasTarget)
        {
            destVect = moveTarget - transform.position;
            distTo = destVect.magnitude;

            destRot = Quaternion.LookRotation(destVect);
            rotLeft = Quaternion.Angle(transform.rotation, destRot);

            transform.Translate(Vector3.forward * GetMoveSpeed() * Time.deltaTime);
            velocity = Mathf.Clamp(velocity + accelLinear, 0.0F, velocityMax);
            accelLinear = Mathf.Clamp(accelLinear + accelLinearInc, 0.0F, accelLinearMax);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, destRot, GetRotSpeed() * Time.deltaTime);
            rotation = Mathf.Clamp((rotation + accelAngular), 0.0F, rotationMax);
            accelAngular = Mathf.Clamp((accelAngular + accelAngularInc), 0.0F, accelAngularMax);

            transform.eulerAngles = new Vector3(0.0F, transform.eulerAngles.y, 0.0F);

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
        distTo = destVect.magnitude;
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