using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public static int attackOrder;
    public bool nearPlayer;
    public bool nearEnemyAttacked;
    public float distancePlayer;
    public static int charactersAttacking;
    private bool Attack;
    private bool Defend;
    private bool runAway;
    private bool surpriseAttack;

    void Update () {
                
            if(distancePlayer < 30f)
                {
                    nearPlayer = true;
                }

        if(distancePlayer > 30f)
        {
            nearPlayer = false;
        }

            if(nearPlayer == true && attackOrder == 1)
                {
                    Attack = true;
                }

            else 
                {
                    Defend = true;
                }

    } 

}
