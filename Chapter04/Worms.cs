using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Worm : MonoBehaviour {

    public int HP;
    public int Ammunition;

    public static List<GameObject> wormList = new List<GameObject>(); //creates a list with all the worms
    public static int wormCount; //Amount of worms in the game
    public int ID; //It's used to differentiate the worms

    private float proximityValueX;
    private float proximityValueY;
    private float nearValue;
    public float distanceValue; //how far the enemy should be

    private bool canAttack;

    void Awake ()
    {
        wormList.Add(gameObject); //add this worm to the list
        wormCount++; //adds plus 1 to the amount of worms in the game
    }

    void Start ()
    {
        HP = 100;
        distanceValue = 30f;
    }

    void Update ()
    {
        proximityValueX = wormList[1].transform.position.x - this.transform.position.x;
        proximityValueY = wormList[1].transform.position.y - this.transform.position.y;
        nearValue = proximityValueX + proximityValueY;

        if(nearValue <= distanceValue)
        {
            canAttack = true;
        }

        else
        {
            canAttack = false;
        }

        Vector3 raycastRight = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, raycastRight, 10)) 
            print("There is something blocking the Right side!");

        Vector3 raycastLEft = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, raycastRight, -10)) 
            print("There is something blocking the Left side!");
    }
        
}
