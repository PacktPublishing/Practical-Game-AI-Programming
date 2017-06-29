using UnityEngine;
using System.Collections;

public class Fence : MonoBehaviour {

    public float HP;
    public float distanceValue;
    private Transform characterPosition;
    private GameObject characterMesh;

    private float proximityValueX;
    private float proximityValueY;
    private float nearValue;

	// Use this for initialization
	void Start () {
	    
        HP = 100f;
        distanceValue = 1.5f;

        // Find the Character Mesh
        characterMesh = GameObject.Find("AICharacter");
	}
	
	// Update is called once per frame
	void Update () {
	    
        // Obtain the Character Mesh Position
        characterPosition = characterMesh.transform;

        //Calculate the distance between this object and the AI Character
        proximityValueX = characterPosition.transform.position.x - this.transform.position.x;
        proximityValueY = characterPosition.transform.position.y - this.transform.position.y;

        nearValue = proximityValueX + proximityValueY;

        if(nearValue <= distanceValue){
            if(AICharacter.fencesAnalyzed == 0){
                AICharacter.fencesAnalyzed = 1;
                AICharacter.bestFence = this.gameObject;
            }

            AICharacter.fenceHP = HP;

            if(HP < AICharacter.lowerFenceHP){
                AICharacter.bestFence = this.gameObject;
            }
        }
	}
}
