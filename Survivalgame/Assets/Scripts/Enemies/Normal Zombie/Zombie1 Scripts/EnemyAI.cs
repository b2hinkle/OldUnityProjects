using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

	public float visionRadius = 10;

	Transform target;

	NavMeshAgent myAgent;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, visionRadius);
	}

	private void Start()
	{
		if (GameObject.FindWithTag("Player"))
			target = GameObject.FindWithTag("Player").transform;
		myAgent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		float distance = Vector3.Distance(target.position, transform.position);

		if (GetComponent<ShrekManager>().shrekHealth > 0)
		{
			if (distance <= visionRadius)
			{
				myAgent.SetDestination(target.position);
			}
		}
		else
		{
			Destroy(myAgent);
		}
	}
}
