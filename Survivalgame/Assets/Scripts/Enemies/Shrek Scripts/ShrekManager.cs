using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekManager : MonoBehaviour
{
	public float shrekHealth = 1250f;

	public float shrekDestroyTime = 15f;

	private Animator shrekAnimator;
	public GameObject shrek;                                    // used to disable shrek's animator and for reference in "Void SetIsKinematicToFalse"

	private bool isKinematic;                                     // used in "void SetIsKinematicToFalse"

	private int deadUpdatePrevent = 0;

	private GameObject gun;





	


	private void Start()
	{
		gun = GameObject.Find("Gun");
		GameManager.enemiesOutInWave++;

	}


	private void Update()
	{
		if (shrekHealth <= 0 && deadUpdatePrevent == 0)
		{
			deadUpdatePrevent = deadUpdatePrevent + 1;
		}

		if (deadUpdatePrevent == 1)
		{
			justdied();
			deadUpdatePrevent = deadUpdatePrevent + 1;
		}







	}

	void justdied()
	{
		tag = "Untagged";
		GameManager.enemiesOutInWave--;
		GameManager.enemiesLeftInWave--;
		GameManager.enemiesLeftInEvent--;




		Destroy(shrek, shrekDestroyTime);

		shrek.GetComponent<Animator>().enabled = false;         // disables shrek's animator

		SetIsKinematicToFalse();                                 // makes "isKinematic" false for all rb's in gameobject "shrek"

		gun.GetComponent<gun>().ApplyKillForce();


	}

	void SetIsKinematicToFalse()
	{
		foreach (var rb in shrek.GetComponentsInChildren<Rigidbody>()) rb.isKinematic = false;
	}



}
