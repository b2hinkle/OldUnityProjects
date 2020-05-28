using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_peekerHead : MonoBehaviour
{
	public float health = 1;
	public void takeDamage (float amount)
	{
		health -= amount;
		if (health <= 0f)
			{
				die();
			}
	}

	void die()
	{
		Destroy(gameObject);
	}
}
