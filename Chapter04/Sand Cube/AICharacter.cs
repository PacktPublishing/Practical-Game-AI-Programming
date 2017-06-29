using UnityEngine;
using System.Collections;

public class AICharacter : MonoBehaviour {

    public GameObject playerMesh;
    public Transform playerMark;
    public Transform cubeMark;
    public Transform cubeMesh;
    public Transform currentPlayerPosition;
    public Transform currentCubePosition;

    public float proximityValueX;
    public float proximityValueY;
    public float nearValue;

    public float cubeProximityX;
    public float cubeProximityY;
    public float nearCube;

    public float cubeMarkProximityX;
    public float cubeMarkProximityZ;

    private bool playerOnMark;
    private bool cubeIsNear;

    public float speed;
    public bool Finding;


	void Start () {
	    
        Vector3 playerMark = new Vector3(81.2f, 32.6f, -31.3f);
        Vector3 cubeMark = new Vector3(81.9f, -8.3f, -2.94f);
        nearValue = 0.5f;
        nearCube = 0.5f;
        speed = 1.3f;
	}
	
	void Update () {

        // Calculates the current position of the player
        currentPlayerPosition.transform.position = playerMesh.transform.position;

        // Calculates the distance between the player and the player mark of the X axis
        proximityValueX = playerMark.transform.position.x - currentPlayerPosition.transform.position.x; 

        // Calculates the distance between the player and the player mark of the Y axis
        proximityValueY = playerMark.transform.position.y - currentPlayerPosition.transform.position.y;

        // Calculates if the player is near of his mark position
        if((proximityValueX + proximityValueY) < nearValue)
        {
            playerOnMark = true;
        }

        cubeProximityX = currentCubePosition.transform.position.x - this.transform.position.x;
        cubeProximityY = currentCubePosition.transform.position.y - this.transform.position.y;

        if((cubeProximityX + cubeProximityY) < nearCube)
        {
            cubeIsNear = true;
        }

        else
        {
            cubeIsNear = false;
        }

        if(playerOnMark == true && cubeIsNear == false && Finding == false)
        {
            PositionChanging();
        }

        if(playerOnMark == true && cubeIsNear == true)
        {
            Finding = false;
        }

        cubeMarkProximityX = cubeMark.transform.position.x - currentCubePosition.transform.position.x;
        cubeMarkProximityZ = cubeMark.transform.position.z - currentCubePosition.transform.position.z;

        if(cubeMarkProximityX > cubeMarkProximityZ)
        {
            PushX();
        }

        if(cubeMarkProximityX < cubeMarkProximityZ)
        {
            PushZ();
        }

	}

    void PositionChanging () {

        Finding = true;
        Vector3 positionA = this.transform.position;
        Vector3 positionB = cubeMesh.transform.position;
        this.transform.position = Vector3.Lerp(positionA, positionB, Time.deltaTime * speed);
    }

    void PushX ()
    {
        
    }

    void PushZ ()
    {

    }
}
