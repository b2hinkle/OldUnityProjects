using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekLimbDmg : MonoBehaviour
{
	public GameObject shrek;



	public void takeDamage(float amount)                         // void function to allow the object to recieve dmg
	{
		shrek.GetComponent<ShrekManager>().shrekHealth -= amount;
		if (shrek.GetComponent<ShrekManager>().shrekHealth <= 0f)
		{
			shrek.GetComponent<ShrekManager>().shrekHealth = 0;
		}



	}
}
