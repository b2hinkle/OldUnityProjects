using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie1Attack : MonoBehaviour
{
	Animator anim;

	NavMeshAgent myAgent;

	public Collider[] attackHitboxes;



	private void Start()
	{
		myAgent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
    }


	

	public void ActivateHitboxes()
	{
        attackHitboxes[0].enabled = true;
		Overlap(attackHitboxes[0]); // Make a big sphere hitbox to replace with the many small arm hitboxes when I have new animations. Make it "is trigger"
        attackHitboxes[0].enabled = false;
	}






	public void Overlap(Collider col)
	{
		
		Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Player1HurtHitbox"));
		foreach (Collider c in cols)
		{
            PlayerHealth.Instance.HurtPlayer(50);
		}
	}


}
