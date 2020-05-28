using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peeker_instakill : MonoBehaviour
{
	public GameObject Peeker;
	private float health = 1;                                     // how much health the object has             (health is set to "1" b/c its supposed to be an instakill)


	private int shotDeadTwicePrevent = 0;



	public void takeDamage(float amount)                         // void function to allow the object to recieve dmg
	{
		health -= amount;
		if (health <= 0f)
		{
			Peeker.GetComponent<PeekerManager>().peekerHealth = 0;
		}



	}
}
