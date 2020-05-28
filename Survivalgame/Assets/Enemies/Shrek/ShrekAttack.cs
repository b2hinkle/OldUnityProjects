using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekAttack : MonoBehaviour
{
	public Collider[] attackHitboxes;

	
	public void Hit()
	{
		ActivateHitboxes(attackHitboxes[0 & 1 & 2 & 3 & 4 & 5]); // Make a big sphere hitbox to replace with the many small arm hitboxes when I have new animations. Make it "is trigger"
	}


	public void ActivateHitboxes(Collider col)
	{
		
		Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Player1HurtHitbox"));
		foreach (Collider c in cols)
		{
			PlayerHealth.Instance.HurtPlayer(100);

			Debug.Log("You lost health");
		}
	}


}
