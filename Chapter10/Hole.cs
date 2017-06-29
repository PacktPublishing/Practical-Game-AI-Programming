using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    public GameObject rabbit;
    public Transform startPosition;
    public bool isOut;

	void Start () {
        isOut = false;
	}
	
	
    void OnTriggerEnter (Collider other){
		
        if(other.gameObject.tag == "Player" && isOut == false)
        {
            isOut = true;
            Instantiate(rabbit, startPosition.position, startPosition.rotation);
        }
	}
}
