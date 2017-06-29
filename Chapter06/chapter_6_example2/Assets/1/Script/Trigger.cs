using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

    public bool leftSide;
    public bool rightSide;
    public int probabilityTurn;

	void Start () {
        
        if(leftSide == true){
            rightSide = false;
        }

        if(rightSide == true){
            leftSide = false;
        }
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "BlackCube")
        {
            if(leftSide == true && rightSide == false)
            {
                Character.availableLeft = false;
                probabilityTurn = 0;
                Character.probabilityTurnLeft = probabilityTurn;
            }

            if(rightSide == true && leftSide == false)
            {
                Character.availableRight = false;
                probabilityTurn = 0;
                Character.probabilityTurnRight = probabilityTurn;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if(other.gameObject.tag == "BlackCube")
        {
            if(leftSide == true && rightSide == false)
            {
                Character.availableLeft = false;
                probabilityTurn = 0;
                Character.probabilityTurnLeft = probabilityTurn;
            }

            if(rightSide == true && leftSide == false)
            {
                Character.availableRight = false;
                probabilityTurn = 0;
                Character.probabilityTurnRight = probabilityTurn;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if(other.gameObject.tag == "BlackCube")
        {
            if(leftSide == true)
            {
                probabilityTurn = Random.Range(0, 100);
                Character.probabilityTurnLeft = probabilityTurn;
                Character.availableLeft = true;
            }

            if(rightSide == true)
            {
                probabilityTurn = Random.Range(0, 100);
                Character.probabilityTurnRight = probabilityTurn;
                Character.availableRight = true;
            }
        }
    }
}
