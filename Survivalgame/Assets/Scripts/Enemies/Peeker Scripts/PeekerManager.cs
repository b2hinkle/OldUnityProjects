using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeekerManager : MonoBehaviour
{
	public float peekerHealth = 50;

	public float peekerDestroyTime = 15f;

	private Animator peekerAnimator;
	public GameObject Peeker;                                    // used to disable Peeker's animator and for reference in "Void SetIsKinematicToFalse"

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
		if (peekerHealth <= 0 && deadUpdatePrevent == 0)
		{
			deadUpdatePrevent = deadUpdatePrevent + 1;
		}
		
		if (deadUpdatePrevent == 1)
		{
			justdied();
			deadUpdatePrevent = deadUpdatePrevent + 1;
		}







	}

	public void justdied()
	{
		tag = "Untagged";
		GameManager.enemiesOutInWave--;
		GameManager.enemiesLeftInWave--;
		GameManager.enemiesLeftInEvent--;




		Destroy(Peeker, peekerDestroyTime);

		Peeker.GetComponent<Animator>().enabled = false;         // disables peeker's animator

		SetIsKinematicToFalse();                                 // makes "isKinematic" false for all rb's in gameobject "Peeker"

		gun.GetComponent<gun>().ApplyKillForce();

		
	}

	void SetIsKinematicToFalse()
	{
		foreach (var rb in Peeker.GetComponentsInChildren<Rigidbody>()) rb.isKinematic = isKinematic = false;
	}

	

}
