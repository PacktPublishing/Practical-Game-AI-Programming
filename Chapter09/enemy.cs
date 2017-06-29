using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public float speed;
    public int health;
    public float speedTurn;
    private Transform target;
    private int wavepointIndex = 0;
    public bool Found;

    public bool facingFront;
    public bool facingBack;

    public int dangerMeter;

	void Start ()
    {
        target = waypoints.points[0];
        speed = 40f;
        speedTurn = 0.2f;
	}
        
	void Update ()
    {
        if (Found == false)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                GetNextWaypoint();
            }

            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, speedTurn, 0.0F);

            transform.rotation = Quaternion.LookRotation(newDir);
        }

        if (Found == true)
        {
            transform.LookAt(target);
        }

        if(facingFront == true)
        {
            
        }

        if(facingBack == true)
        {
            
        }
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

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Found = true;
            target = other.gameObject.transform;
        }

        if(other.gameObject.name == "frontSide")
        {
            facingFront = true;
            facingBack = false;
        }

        if(other.gameObject.name == "backSide")
        {
            facingFront = false;
            facingBack = true;
        }
    }


}
