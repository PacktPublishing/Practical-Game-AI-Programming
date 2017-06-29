using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour {

    void OnTriggerEnter (Collider other){

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("I can see the player");
        }
    }

    void OnTriggerStay (Collider other){

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("I can see the player");
        }
    }

    void OnTriggerExit (Collider other){

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("I've lost the player");
        }
    }
}
