using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float speed;
    public int health;
    public float speedTurn;

        public bool Team1;
        public bool Team2;

        public bool Top;
        public bool Middle;
        public bool Bottom;

        private Transform target;
        private int wavepointIndex = 0;

        static Transform heroTarget;
    static bool heroTriggered;


        void Start ()
        {
                if(Team1 == true)
                    {
                        if(Top == true)
                            {
                                target = 1_Top.1_Top[0];
                            }

                        if(Middle == true)
                            {
                                target = 1_Middle.1_Middle[0];
                            }

                        if(Bottom == true)
                            {
                                target = 1_Bottom.1_Top[0];
                            }
                    }

                if(Team2 == true)
                    {
                        if(Top == true)
                            {
                                target = 2_Top.2_Top[0];
                            }

                        if(Middle == true)
                            {
                                target = 2_Middle.2_Middle[0];
                            }

                        if(Bottom == true)
                            {
                                target = 2_Bottom.2_Top[0];
                            }
                    }
                     speed = 10f;
                     speedTurn = 0.2f;
            }
                
        void Update ()
        {
                    Vector3 dir = target.position - transform.position;
                    transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

                    if(Vector3.Distance(transform.position, target.position) <= 0.4f && heroTriggered == false)
                             {
                                 GetNextWaypoint();
                             }

                    if(heroTriggered == true)
                    {
                        GetHeroWaypoint();
                    }

                     Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, speedTurn, 0.0F);

                     transform.rotation = Quaternion.LookRotation(newDir);
            }

        void GetNextWaypoint()
        {
                if(Team1 == true)
                    {
                        if(Top == true)
                            {
                                if(wavepointIndex >= 1_Top.1_Top.Length - 1)
                                    {
                                        Destroy(gameObject);
                                        return;
                                    }

                                wavepointIndex++;
                                target = 1_Top.1_Top[wavepointIndex];
                            }

                        if(Middle == true)
                            {
                                if(wavepointIndex >= 1_Middle.1_Middle.Length - 1)
                                    {
                                        Destroy(gameObject);
                                        return;
                                    }

                                wavepointIndex++;
                                target = 1_Middle.1_Middle[wavepointIndex];
                            }

                        if(Bottom == true)
                            {
                                if(wavepointIndex >= 1_Bottom.1_Bottom.Length - 1)
                                    {
                                        Destroy(gameObject);
                                        return;
                                    }

                                wavepointIndex++;
                                target = 1_Bottom.1_Bottom[wavepointIndex];
                            }
                    }

                if(Team2 == true)
                    {
                        if(Top == true)
                            {
                                if(wavepointIndex >= 2_Top.2_Top.Length - 1)
                                    {
                                        Destroy(gameObject);
                                        return;
                                    }

                                wavepointIndex++;
                                target = 2_Top.2_Top[wavepointIndex];
                            }

                        if(Middle == true)
                            {
                                if(wavepointIndex >= 2_Middle.2_Middle.Length - 1)
                                    {
                                        Destroy(gameObject);
                                        return;
                                    }

                                wavepointIndex++;
                                target = 2_Middle.2_Middle[wavepointIndex];
                            }

                        if(Bottom == true)
                            {
                                if(wavepointIndex >= 2_Bottom.2_Bottom.Length - 1)
                                    {
                                        Destroy(gameObject);
                                        return;
                                    }

                                wavepointIndex++;
                                target = 2_Bottom.2_Bottom[wavepointIndex];
                            }
                    }
            }

    void GetHeroWaypoint()
    {
        target = heroTarget.transform;
    }


}
