using UnityEngine;
using System.Collections;

public class EnemyAI2 : MonoBehaviour {

    public float Hunger = 100f;

	// Use this for initialization
	void Start () {
	    
      
	}
	
	// Update is called once per frame
	
    void Update () {
	    
        Hunger -= Time.deltaTime / 4;
	}


}
