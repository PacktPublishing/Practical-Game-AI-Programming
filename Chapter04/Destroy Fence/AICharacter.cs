using UnityEngine;
using System.Collections;

public class AICharacter : MonoBehaviour {

    public static float fenceHP;
    public static float lowerFenceHP;
    public static float fencesAnalyzed;
    public static GameObject bestFence;
    private Transform House;
    private float timeWasted;

    public float speed;


   
	void Start () {
	    
        fenceHP = 100f;
        lowerFenceHP = fenceHP;
        fencesAnalyzed = 0;
        speed = 0.8f;

        Vector3 House = new Vector3(300.2f, 83.3f, -13.3f);

	}
	
	void Update () {

        timeWasted += Time.deltaTime;
	    
        if(fenceHP > lowerFenceHP)
        {
            lowerFenceHP = fenceHP;
        }

        if(timeWasted > 30f)
        {
            GoToFence();   
        }
	}

    void GoToFence() {

        Vector3 positionA = this.transform.position;
        Vector3 positionB = bestFence.transform.position;
        this.transform.position = Vector3.Lerp(positionA, positionB, Time.deltaTime * speed);
    }
}
