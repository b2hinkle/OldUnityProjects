using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1TorsoDmg : MonoBehaviour
{
	public GameObject zombie1;



	public void takeDamage(float amount)                         // void function to allow the object to recieve dmg
	{
		zombie1.GetComponent<Zombie1Manager>().zombie1Health -= amount;
		if (zombie1.GetComponent<Zombie1Manager>().zombie1Health <= 0f)
		{
			zombie1.GetComponent<Zombie1Manager>().zombie1Health = 0;
		}



	}
}
