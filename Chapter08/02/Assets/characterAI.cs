using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAI : MonoBehaviour {

    public float speed;
    public Transform ball;
    public bool hasBall;
    public float ballDistance;
    public static float teamDistance;
    public bool nearTheBall;
    public List<Transform> teamCharacters;
    public int randomChoice;

    public float teamdist;


	void Start () {
		
        speed = 1f;

        teamDistance = 10;
	}
	
	void Update () {

        teamdist = teamDistance;
		
        if(hasBall == false && nearTheBall == true)
        {
            Vector3 positionA = this.transform.position;
            Vector3 positionB = ball.transform.position;
            this.transform.position = Vector3.Lerp(positionA, positionB, Time.deltaTime * speed);
        }

        if(ballDistance < 0.1)
        {
            hasBall = true;
        }

        if(hasBall == true)
        {
            passBall();
            hasBall = false;
        }

        ballDistance =Vector3.Distance(transform.position,ball.position);

        if(teamDistance > ballDistance)
        {
            teamDistance = ballDistance;
        }

        if(teamDistance == ballDistance)
        {
            nearTheBall = true;
        }

        if(teamDistance < ballDistance)
        {
            nearTheBall = false;    
        }

	}

    void passBall ()
    {
        randomChoice = Random.Range(0, 9);
        ballScript.characterPos = teamCharacters[randomChoice];
    }
}
