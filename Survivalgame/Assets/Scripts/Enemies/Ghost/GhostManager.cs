using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    


    int isStupid;

    float destroyTimer = 0;
    float timeSinceSpawn = 0;

    protected bool ghostInside;


    bool idle_normal;
    bool idle_combat;
    bool move_forward;
    bool move_forward_fast;
    bool move_forward_really_fast;


    int setBoolsOnlyOnce = 0;
    int setGhostTypeBackOnlyOnce = 0;

    int ghostType;

    Animator anim;

    int startedGhostType;

    float hurtTimer;
    int hurtOnlyOnce = 0;

    private Transform Player;
    private int MoveSpeed;
    private int MinDist = 11;


    int randomIdleType;

    
    float hurtEveryBlankSeconds = 3;


    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "IsInShelterTrigger")
        {
            ghostInside = true;
            if (timeSinceSpawn < 1)
            {
                Destroy(gameObject);
                SpawnGhost.Instance.SpawnAGhost();
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {


        if (col.tag == "IsInShelterTrigger")
        {
            ghostInside = false;
        }
    }




    void Start ()
    {
        isStupid = Random.Range(1, 4);

        anim = GetComponent<Animator>();


        startedGhostType = Random.Range(1, 6);




        //Making the anim bools

        if (startedGhostType == 1)
        {
            //still
            anim.SetBool("idle_normal", true);
            ghostType = 1;
        }
        if (startedGhostType == 2)
        {
            //alt still
            anim.SetBool("idle_combat", true);
            ghostType = 2;
        }
        if (startedGhostType == 3)
        {
            //chase
            anim.SetBool("move_forward", true);
            ghostType = 3;
        }
        if (startedGhostType == 4)
        {
            //fast chase
            anim.SetBool("move_forward_fast", true);
            ghostType = 4;
        }
        if (startedGhostType == 5)
        {
            //really fast chase
            anim.SetBool("move_forward_really_fast", true);
            ghostType = 5;
        }







        Player = GameObject.FindWithTag("Player").transform;
        




        Debug.Log(startedGhostType);

    }
	
	
	void Update ()
    {
        if (WavesManager.waveActive == false)
        {
            destroyTimer = destroyTimer + Time.deltaTime;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            if (destroyTimer >= .05)
            {
                Destroy(gameObject);
            }
        }




        if (timeSinceSpawn < 2)
        {
            timeSinceSpawn = timeSinceSpawn + Time.deltaTime;
        }


        if (UpgradeManager.ghostBarrierActive == true)
        {
            if (ghostInside == true)
            {




                destroyTimer = destroyTimer + Time.deltaTime;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);

                if (destroyTimer >= .05)
                {
                    Destroy(gameObject);
                }

            }
        }
        



        if (UpgradeManager.ghostBarrierActive == true)
        {
            if (GameManager.playerInside == true && isStupid == 2 || isStupid == 3)
            {

                if (setGhostTypeBackOnlyOnce != 0)
                {
                    setGhostTypeBackOnlyOnce = 0;
                }


                if (setBoolsOnlyOnce == 0)
                {
                    setBoolsOnlyOnce++;
                }

                if (setBoolsOnlyOnce == 1)
                {
                    setBoolsOnlyOnce++;


                    randomIdleType = Random.Range(1, 3);
                    ghostType = randomIdleType;

                    if (ghostType == 1)
                    {
                        anim.SetBool("idle_normal", true);
                        anim.SetBool("idle_combat", false);
                        anim.SetBool("move_forward", false);
                        anim.SetBool("move_forward_fast", false);
                        anim.SetBool("move_forward_really_fast", false);
                    }
                    if (ghostType == 2)
                    {
                        anim.SetBool("idle_normal", false);
                        anim.SetBool("idle_combat", true);
                        anim.SetBool("move_forward", false);
                        anim.SetBool("move_forward_fast", false);
                        anim.SetBool("move_forward_really_fast", false);
                    }
                }


            }
            else if (GameManager.playerInside == false)
            {
                if (setBoolsOnlyOnce != 0)
                {
                    setBoolsOnlyOnce = 0;
                }




                if (setGhostTypeBackOnlyOnce == 0)
                {
                    setGhostTypeBackOnlyOnce++;
                }

                if (setGhostTypeBackOnlyOnce == 1)
                {
                    setGhostTypeBackOnlyOnce++;
                    ghostType = startedGhostType;

                    if (ghostType == 1)
                    {
                        anim.SetBool("idle_normal", true);
                        anim.SetBool("idle_combat", false);
                        anim.SetBool("move_forward", false);
                        anim.SetBool("move_forward_fast", false);
                        anim.SetBool("move_forward_really_fast", false);
                    }
                    if (ghostType == 2)
                    {
                        anim.SetBool("idle_normal", false);
                        anim.SetBool("idle_combat", true);
                        anim.SetBool("move_forward", false);
                        anim.SetBool("move_forward_fast", false);
                        anim.SetBool("move_forward_really_fast", false);
                    }
                    if (ghostType == 3)
                    {
                        anim.SetBool("idle_normal", false);
                        anim.SetBool("idle_combat", false);
                        anim.SetBool("move_forward", true);
                        anim.SetBool("move_forward_fast", false);
                        anim.SetBool("move_forward_really_fast", false);
                    }
                    if (ghostType == 4)
                    {
                        anim.SetBool("idle_normal", false);
                        anim.SetBool("idle_combat", false);
                        anim.SetBool("move_forward", false);
                        anim.SetBool("move_forward_fast", true);
                        anim.SetBool("move_forward_really_fast", false);
                    }
                    if (ghostType == 5)
                    {
                        anim.SetBool("idle_normal", false);
                        anim.SetBool("idle_combat", false);
                        anim.SetBool("move_forward", false);
                        anim.SetBool("move_forward_fast", false);
                        anim.SetBool("move_forward_really_fast", true);
                    }
                }
            }

        



        }


        
        if (ghostType == 3)
        {
            MoveSpeed = 25;
            if (Vector3.Distance(transform.position, Player.position) <= MinDist)  // if peeker reaches the min distance then....
            {
                HurtOnceInUpdate(); // when reaches min distance then hurt player instantly

                hurtTimer = hurtTimer + Time.deltaTime;
                if (hurtTimer > hurtEveryBlankSeconds)
                {
                    hurtTimer = 0;
                }


                if (hurtTimer == 0)
                {

                    PlayerHealth.Instance.HurtPlayer(10);
                }

            }

            if (Vector3.Distance(transform.position, Player.position) >= MinDist)   // if npc is far enough away to move at you 
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime; // move toward player with MoveSpeed
            }
        }
        if (ghostType == 4)
        {
            MoveSpeed = 30;
            if (Vector3.Distance(transform.position, Player.position) <= MinDist)  // if peeker reaches the min distance then....
            {
                HurtOnceInUpdate(); // when reaches min distance then hurt player instantly

                hurtTimer = hurtTimer + Time.deltaTime;
                if (hurtTimer > hurtEveryBlankSeconds)
                {
                    hurtTimer = 0;
                }


                if (hurtTimer == 0)
                {

                    PlayerHealth.Instance.HurtPlayer(10);
                }

            }

            if (Vector3.Distance(transform.position, Player.position) >= MinDist)   // if npc is far enough away to move at you 
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime; // move toward player with MoveSpeed
            }
        }
        if (ghostType == 5)
        {
            MoveSpeed = 32;
            if (Vector3.Distance(transform.position, Player.position) <= MinDist)  // if peeker reaches the min distance then....
            {
                HurtOnceInUpdate(); // when reaches min distance then hurt player instantly

                hurtTimer = hurtTimer + Time.deltaTime;
                if (hurtTimer > hurtEveryBlankSeconds)
                {
                    hurtTimer = 0;
                }


                if (hurtTimer == 0)
                {

                    PlayerHealth.Instance.HurtPlayer(10);
                }

            }

            if (Vector3.Distance(transform.position, Player.position) >= MinDist)   // if npc is far enough away to move at you 
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime; // move toward player with MoveSpeed
            }
        }
    }




    void HurtOnceInUpdate()
    {
        hurtOnlyOnce = hurtOnlyOnce + 1;    // when reaches min distance then hurt player instantly
        if (hurtOnlyOnce == 1)
        {
            PlayerHealth.Instance.HurtPlayer(10);
            hurtOnlyOnce++;
        }
    }
}
