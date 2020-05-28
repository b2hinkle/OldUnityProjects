using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peeker_BodyPartHealth : MonoBehaviour
{
	public GameObject Peeker;



	public void takeDamage(float amount)                         // void function to allow the object to recieve dmg
	{
		Peeker.GetComponent<PeekerManager>().peekerHealth -= amount;
		if (Peeker.GetComponent<PeekerManager>().peekerHealth <= 0f)
		{
			Peeker.GetComponent<PeekerManager>().peekerHealth = 0;
		}



	}
}
