using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public float Speed;
    public float facingLeft;
    public float facingRight;
    public float facingBack;
    public static bool availableLeft;
    public static bool availableRight;

    public static int probabilityTurnLeft;
    public static int probabilityTurnRight;
    public int probabilitySides;

    public bool forwardBlocked;

    public bool aLeft;
    public bool aRight;

	void Start ()
    {
	    
        availableLeft = true;
        availableRight = true;
        probabilityTurnLeft = 0;
        probabilityTurnRight = 0;
	}
	
	void Update ()
    {
        aLeft = availableLeft;
        aRight = availableRight;
	    
        transform.Translate(Vector2.up * Time.deltaTime * Speed);

        if(facingLeft > 270)
        {
            facingLeft = 0;
        }

        if(facingRight < -270)
        {
            facingRight = 0;
        }

        if (forwardBlocked == false)
        {
            if (availableLeft == true && availableRight == false)
            {
                if (probabilityTurnLeft > 40)
                {
                    turnLeft();
                }
            }

            if (availableLeft == false && availableRight == true)
            {
                if (probabilityTurnRight > 40)
                {
                    turnRight();
                }
            }

            if (availableLeft == true && availableRight == true)
            {
                if(probabilityTurnLeft > 50 && probabilityTurnLeft > probabilityTurnRight)
                {
                    turnLeft();
                }

                if(probabilityTurnRight > 50 && probabilityTurnRight > probabilityTurnLeft)
                {
                    turnRight(); 
                }
            }
        }
            
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "BlackCube")
        {
            forwardBlocked = true;

            if(availableLeft == true && availableRight == false)
            {
                turnLeft();
            }

            if(availableRight == true && availableLeft == false)
            {
                turnRight();
            }

            if(availableRight == true && availableLeft == true)
            {
                probabilitySides = Random.Range(0, 1);
                if(probabilitySides == 0)
                {
                    turnLeft();
                }

                if(probabilitySides == 1)
                {
                    turnRight();
                }

            }

            if(availableRight == false && availableLeft == false)
            {
                turnBack();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        forwardBlocked = false;
    }
        

    void  turnLeft ()
    {
        probabilityTurnLeft = 0;
        facingLeft = transform.rotation.eulerAngles.z + 90;
        transform.localRotation = Quaternion.Euler(0, 0, facingLeft);
    }

    void turnRight ()
    {
        probabilityTurnRight = 0;
        facingRight = transform.rotation.eulerAngles.z - 90;
        transform.localRotation = Quaternion.Euler(0, 0, facingRight);
    }

    void turnBack ()
    {
        facingBack = transform.rotation.eulerAngles.z + 180;
        transform.localRotation = Quaternion.Euler(0, 0, facingBack);
    }
        
}
