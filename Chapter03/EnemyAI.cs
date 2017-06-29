using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private int Health = 100;
    private bool statePassive;
    private bool stateAggressive;
    private bool stateDefensive;

    private bool triggerL;
    private bool triggerR;
    private bool triggerM;

    public Transform wallPosition;
    public Transform buildingPosition;
    public Transform triggerLPosition;
    private bool cover;
    private float speed;
    private float speedBack;
    private float walk;
    private float walkBack;

    public Transform playerSoldier;
    static string playerPosition;

    private int rndNumber;

    public static bool Beach;
    public static bool River;
    public static bool Forest;

	// Use this for initialization
	void Start () {
	    
        statePassive = true;
	}
	
	// Update is called once per frame
	void Update () {

        if(Beach == true){
            Forest = false;
            River = false;
        }

        if(Forest == true){
            Beach = false;
            River = false;
        }

        if(River == true){
            Forest = false;
            Beach = false;
        }
	    
        if (Forest == true)
        {
            // The AI will remain passive until an interaction with the player occurs
            if (Health == 100 && triggerL == false && triggerR == false && triggerM == false)
            {
                statePassive = true;
                stateAggressive = false;
                stateDefensive = false;
            }

            // The AI will shift to the defensive mode if player comes from the right side or if the AI is below 20 HP
            if (Health <= 100 && triggerR == true || Health <= 20)
            {
                statePassive = false;
                stateAggressive = false;
                stateDefensive = true;
            }

            // The AI will shift to the aggressive mode if player comes from the left side or it's on the middle and AI is above 20HP
            if (Health > 20 && triggerL == true || Health > 20 && triggerM == true)
            {
                statePassive = false;
                stateAggressive = true;
                stateDefensive = false;
            }

            walk = speed * Time.deltaTime;
            walk = speedBack * Time.deltaTime;
        }

        if (Beach == true)
        {
            // The AI will remain passive until an interaction with the player occurs
            if (Health == 100 && triggerL == false && triggerR == false && triggerM == false)
            {
                statePassive = true;
                stateAggressive = false;
                stateDefensive = false;
            }

            // The AI will shift to the defensive mode if player comes from the right side or if the AI is below 20 HP
            if (Health <= 100 && triggerR == true || Health <= 20)
            {
                statePassive = false;
                stateAggressive = false;
                stateDefensive = true;
            }

            // The AI will shift to the aggressive mode if player comes from the left side or it's on the middle and AI is above 20HP
            if (Health > 20 && triggerL == true || Health > 20 && triggerM == true)
            {
                statePassive = false;
                stateAggressive = true;
                stateDefensive = false;
            }

            walk = speed * Time.deltaTime;
            walk = speedBack * Time.deltaTime;
        }

        if (River == true)
        {
            // The AI will remain passive until an interaction with the player occurs
            if (Health == 100 && triggerL == false && triggerR == false && triggerM == false)
            {
                statePassive = true;
                stateAggressive = false;
                stateDefensive = false;
            }

            // The AI will shift to the defensive mode if player comes from the right side or if the AI is below 20 HP
            if (Health <= 100 && triggerR == true || Health <= 20)
            {
                statePassive = false;
                stateAggressive = false;
                stateDefensive = true;
            }

            // The AI will shift to the aggressive mode if player comes from the left side or it's on the middle and AI is above 20HP
            if (Health > 20 && triggerL == true || Health > 20 && triggerM == true)
            {
                statePassive = false;
                stateAggressive = true;
                stateDefensive = false;
            }

            walk = speed * Time.deltaTime;
            walk = speedBack * Time.deltaTime;
        }
    }

    /*void Passive () {

        rndNumber = Random.Range(0,100);

       if(morningTime == true && rndNumber > 13){ // We have 87% of chance
            goGuard();
       }

        if(morningTime == true && rndNumber =< 13 && rndNumber < 3){ // We have 10% of chance
            goDrink();
       }

       if(morningTime == true && rndNumber <= 3){ // We have 3% of chance
            goWalk();
       }
       
       if(afternoonTime == true && rndNumber > 52){ // We have 48% of chance
            goGuard();
       }

       if(afternoonTime == true && rndNumber =< 34 && rndNumber < 2){ // We have 32% of chance
            goDrink();
       }

       if(afternoonTime == true && rndNumber <= 2){ // We have 2% of chance
            goWalk();
       }

       if(nightTime == true && rndNumber > 65){ // We have 35% of chance
            goGuard();
       }

       if(nightTime == true && rndNumber =< 65 && rndNumber < 25){ // We have 40% of chance
            goDrink();
       }

       if(nightTime == true && rndNumber <= 25){ // We have 25% of chance
            goWalk();
       }
    }*/

    void Defensive () {

        if (playerPosition == "triggerR")
        { // Check if player is currently located on the triggerR position
            transform.LookAt(playerSoldier); // Face the direction of the player

            if (cover == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, wallPosition.position, walk);
            }

            if (cover == true)
            {
                coverFire();
            }
        }

        if (playerPosition == "triggerM")
        {
            transform.LookAt(playerSoldier); // Face the direction of the player
            transform.position = Vector3.MoveTowards(transform.position, buildingPosition.position, walkBack);
            backwardsFire();
        }
    }

    void Aggressive () {

        if (playerPosition == "triggerL" || playerPosition == "triggerM")
        {
            transform.LookAt(playerSoldier); // Face the direction of the player
            frontFire();
        }

        else {

            transform.position = Vector3.MoveTowards(transform.position, triggerLPosition.position, walk);
        }

    }
        

    void coverFire () {
        // Here we can write the necessary code that makes the enemy firing while in cover position.
    }

    void backwardsFire () {
        // Here we can write the necessary code that makes the enemy firing while going back.
    }

    void frontFire() {
        
    }
}
