using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie1AI : MonoBehaviour
{
    int navmeshAlterationNumber;


	Transform target;

	NavMeshAgent myAgent;

	private Animator anim;

    float timer = 0;
	
	public float zombieNavMeshSpeed = 34;



	private void Start()
	{
        navmeshAlterationNumber = Random.Range(1, 6);

		if (GameObject.FindWithTag("Player"))
			target = GameObject.FindWithTag("Player").transform;
		myAgent = GetComponent<NavMeshAgent>();
		float dist = myAgent.remainingDistance;

		myAgent.speed = zombieNavMeshSpeed;

		anim = GetComponent<Animator>();

		if (zombieNavMeshSpeed == 34)
		{
			anim.Play("zombieRun");
            anim.SetBool("isRunner", true);
            tag = "EnemyRunner";
        }
		else if (zombieNavMeshSpeed == 20)
		{
			anim.Play("zombieSlowRun");
            anim.SetBool("isSlowRunner", true);
            tag = "EnemySlowRunner";
        }
        else if (zombieNavMeshSpeed == 13)
        {
            anim.Play("zombieWalk");
            anim.SetBool("isWalker", true);
            tag = "EnemyWalker";
        }
	}

	private void Update()
	{
		if (GetComponent<Zombie1Manager>().zombie1Health <= 0)
		{
			Destroy(myAgent);
			Destroy(this);
		}
		if (tag.Contains("Enemy"))
		{
            timer = timer + Time.deltaTime;
            myAgent.SetDestination(target.position);

            
            if (timer >= 15)
            {
                
                if (navmeshAlterationNumber == 1)
                {
                    ZombieNavMeshSpeed(0);
                }
                else if (navmeshAlterationNumber == 2)
                {
                    ZombieNavMeshSpeed(10);
                }
                else if (navmeshAlterationNumber == 3)
                {
                    ZombieNavMeshSpeed(30);
                }
                else if (navmeshAlterationNumber == 4)
                {
                    ZombieNavMeshSpeed(27);
                }
                else if (navmeshAlterationNumber == 5)
                {
                    ZombieNavMeshSpeed(25);
                }

            }
            


            if (!myAgent.pathPending && (myAgent.remainingDistance <= myAgent.stoppingDistance) && (!myAgent.hasPath || myAgent.velocity.sqrMagnitude == 0f)) // if navmeshagent reached stopping distance
			{
				anim.Play("zombieAttack");
			}
		}
		



	}

    public void ZombieNavMeshSpeed(float speed)
    {
        zombieNavMeshSpeed = speed;
        myAgent.speed = zombieNavMeshSpeed;
    }
}
