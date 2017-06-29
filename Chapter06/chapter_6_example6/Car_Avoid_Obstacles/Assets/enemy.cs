using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public float speed;
    public int health;
    public float speedTurn;

    public float walkRange;
    public GameObject car;

    public Transform target;
    private int wavepointIndex = 0;

	void Start ()
    {
        target = waypoints.points[0];
        //speed = 3f;
        speedTurn = 3f;
	}
        
	void Update ()
    {

        //transform.LookAt(target);
        Transform targetLook = waypoints.points[wavepointIndex + 1];

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 1f)
        {
            GetNextWaypoint();
        }

       Quaternion targetRotation = Quaternion.LookRotation(dir - transform.position);
       transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime / speedTurn);
	}

    void GetNextWaypoint()
    {
        if(wavepointIndex >= waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
            
        wavepointIndex++;
        target = waypoints.points[wavepointIndex];
    }
}