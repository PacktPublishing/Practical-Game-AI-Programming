using UnityEngine;
using System.Collections;

public class CharacterAI : MonoBehaviour {

    public Animator characterAnimator;
    public int Health;
    public int Stamina;
    public float movementSpeed;
    public float rotationSpeed;
    public float maxSpeed;
    public float jumpHeight;
    public float jumpSpeed;

    private float currentSpeed;
    private bool Dead;
    private bool steppingGrass;
    private int attackRandomNumber;

	void Start () {
	
	}

	void Update () {

        // Sets the movement speed of the animator, to change from idle to walk and walk to run
        characterAnimator.SetFloat("currentSpeed",currentSpeed);

        // Sets the stepping grass boolean to the animator value
        characterAnimator.SetBool("steppingGrass",steppingGrass);

        // Sets the attackrandomnumber to the animator value
        characterAnimator.SetInteger("attackRandomNumber",attackRandomNumber);
	
        // USING XBOX CONTROLLER
        transform.Rotate(0,Time.deltaTime * (rotationSpeed * Input.GetAxis ("xboxlefth")), 0);

        if(Input.GetAxis ("xboxleft") > 0){
            transform.position += transform.forward * Time.deltaTime * currentSpeed;
            currentSpeed = Time.deltaTime * (Input.GetAxis ("xboxleft") * movementSpeed);
        }

        else{
            transform.position += transform.forward * Time.deltaTime * currentSpeed;
            currentSpeed = Time.deltaTime * (Input.GetAxis ("xboxleft") * movementSpeed/3);
        }

        if(Input.GetKeyDown("joystick button 18") && Dead == false)
        {
            fightMode();
        }

        if(Input.GetKeyUp("joystick button 18") && Dead == false)
        {
            
        }

        if(Input.GetKeyDown("joystick button 16") && Dead == false)
        {
            
        }

        if(Input.GetKeyUp("joystick button 16") && Dead == false)
        {
            
        }

        if(Health <= 0){
            Dead = true;
        }
	}

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "Grass")
        {   
            steppingGrass = true;
        }
    }

    void OnTriggerExit(Collider other) {

        if(other.gameObject.tag == "Grass")
        {   
            steppingGrass = false;
        }
    }

    void fightMode ()
    {
        attackRandomNumber = (Random.Range(0, 10));
    }
}
