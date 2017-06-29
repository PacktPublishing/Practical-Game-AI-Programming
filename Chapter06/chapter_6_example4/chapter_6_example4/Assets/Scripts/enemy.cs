using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public static bool raceStarted = false;
        
    public float aiSpeed = 10.0f;
    public float aiTurnSpeed = 2.0f;
    public float resetAISpeed = 0.0f;
    public float resetAITurnSpeed = 0.0f;
        
    public GameObject waypointController;
    public List<Transform> waypoints;
    public int currentWaypoint = 0;
    public float currentSpeed;
    public Vector3 currentWaypointPosition;

    public static bool isBlocked;
    public static bool isBlockedFront;
    public static bool isBlockedRight;
    public static bool isBlockedLeft;
        
    void Start () 
    {
             GetWaypoints();
             resetAISpeed = aiSpeed;
             resetAITurnSpeed = aiTurnSpeed;
    }
        
    void Update () 
    {
        if(raceStarted && isBlocked == false)
        {
            MoveTowardWaypoints();    
        }

        if(raceStarted && isBlockedFront == true && isBlockedLeft == false && isBlockedRight == false)
        {
            TurnRight();
        }

        if(raceStarted && isBlockedFront == false && isBlockedLeft == true && isBlockedRight == false)
        {
            TurnRight();
        }

        if(raceStarted && isBlockedFront == false && isBlockedLeft == false && isBlockedRight == true)
        {
            TurnLeft();
        }
    }
        
    void GetWaypoints()
     {
             Transform[] potentialWaypoints = waypointController.GetComponentsInChildren<Transform>();
                
             waypoints = new List<Transform>();
                
             foreach(Transform potentialWaypoint in potentialWaypoints)
                 {
                     if(potentialWaypoint != waypointController.transform)
                         {
                             waypoints.Add(potentialWaypoint);    
                         }
                 }
    }
        
    void MoveTowardWaypoints()
    {
             float currentWaypointX = waypoints[currentWaypoint].position.x;
             float currentWaypointY = transform.position.y;
             float currentWaypointZ = waypoints[currentWaypoint].position.z;
                
                Vector3 relativeWaypointPosition = transform.InverseTransformPoint (new Vector3(currentWaypointX, currentWaypointY, currentWaypointZ));
                currentWaypointPosition = new Vector3(currentWaypointX, currentWaypointY, currentWaypointZ);
                
                Quaternion toRotation = Quaternion.LookRotation(currentWaypointPosition - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, aiTurnSpeed);
                
                GetComponent<Rigidbody>().AddRelativeForce(0, 0, aiSpeed);
                
                if(relativeWaypointPosition.sqrMagnitude < 15.0f)
                    {
                        currentWaypoint++;
                        
                        if(currentWaypoint >= waypoints.Count)
                            {
                                currentWaypoint = 0;    
                            }
                    }
                
                currentSpeed = Mathf.Abs(transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z);
                
             float maxAngularDrag = 2.5f;
             float currentAngularDrag = 1.0f;
             float aDragLerpTime = currentSpeed * 0.1f;
                
             float maxDrag = 1.0f;
             float currentDrag = 3.5f;
             float dragLerpTime = currentSpeed * 0.1f;
                
             float myAngularDrag    = Mathf.Lerp(currentAngularDrag, maxAngularDrag, aDragLerpTime);
             float myDrag = Mathf.Lerp(currentDrag, maxDrag, dragLerpTime);
                
                GetComponent<Rigidbody>().angularDrag = myAngularDrag;
                GetComponent<Rigidbody>().drag = myDrag;
    }

    void TurnLeft()
    {
        //turning left function here
    }

    void TurnRight()
    {
        //turning right function here
    }

}