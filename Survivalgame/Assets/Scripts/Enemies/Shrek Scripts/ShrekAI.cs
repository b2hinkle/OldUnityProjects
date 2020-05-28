using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShrekAI : MonoBehaviour
{
	Transform target;

	NavMeshAgent myAgent;

	private Animator anim;



	private void Start()
	{
		anim = GetComponent<Animator>();

		if (GameObject.FindWithTag("Player"))
			target = GameObject.FindWithTag("Player").transform;
		myAgent = GetComponent<NavMeshAgent>();
		float dist = myAgent.remainingDistance;
	}

	private void Update()
	{
		myAgent.SetDestination(target.position);

		if (GetComponent<ShrekManager>().shrekHealth <= 0)
		{
			Destroy(myAgent);
			Destroy(this);
			
		}
		if (!myAgent.pathPending && (myAgent.remainingDistance <= myAgent.stoppingDistance) && (!myAgent.hasPath || myAgent.velocity.sqrMagnitude == 0f)) // if navmeshagent reached stopping distance
		{
			anim.Play("Attack");
		}


	}
}
