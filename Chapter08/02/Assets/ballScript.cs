using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour {

    public Vector2 curPos;
    public Vector2 lastPos;
    public static Transform characterPos;
    public float speed;

    public bool ballMoving;

    void Start () {

        characterPos = this.transform;
        speed = 2f;
    }
	
	void Update () {
		
        curPos = transform.position;

        if(curPos == lastPos)
        {
            ballMoving = false;
        }

        else
        {
            ballMoving = true;
            characterAI.teamDistance = 10;
        }

        lastPos = curPos;

        Vector2 positionA = this.transform.position;
        Vector2 positionB = characterPos.transform.position;
        this.transform.position = Vector2.Lerp(positionA, positionB, Time.deltaTime * speed);
	}
}
