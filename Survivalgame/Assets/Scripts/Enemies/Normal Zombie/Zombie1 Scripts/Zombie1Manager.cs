using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1Manager : MonoBehaviour
{
    GameObject gameMaster;


	public float zombie1Health;

	public float zombie1DestroyTime = 15f;

	private Animator zombie1Animator;
	public GameObject zombie1;                                    // used to disable zombie1's animator and for reference in "Void SetIsKinematicToFalse"

	private bool isKinematic;                                     // used in "void SetIsKinematicToFalse"

	private int deadUpdatePrevent = 0;


	private GameObject gun;




	



	private void Start()
	{
        gameMaster = GameObject.Find("Game Master");

		zombie1Health = WavesManager.zombie1UniversalHealth;		//Sets health based off wave







		gun = GameObject.Find("Gun");
		GameManager.enemiesOutInWave++;

	}


	private void Update()
	{
		if (zombie1Health <= 0 && deadUpdatePrevent == 0)
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
		GameManager.normalZombiesLeftInWave--;
		GameManager.normalZombiesOutInWave--;


        GiveDispensorKit();








        Destroy(zombie1, zombie1DestroyTime);

		zombie1.GetComponent<Animator>().enabled = false;         // disables zombie1's animator

		SetIsKinematicToFalse();                                 // makes "isKinematic" false for all rb's in gameobject "zombie1"

		gun.GetComponent<gun>().ApplyKillForce();


	}

	void SetIsKinematicToFalse()
	{
		foreach (var rb in zombie1.GetComponentsInChildren<Rigidbody>()) rb.isKinematic = false;
	}

    void GiveDispensorKit()
    {
        if (GameManager.waveNumber == 1)
        {
            int hasItem = Random.Range(0, 5);
            if (hasItem == 1 && PlayerInventory.hasDispenserKit == false && PlayerInventory.dispenserBuilt == false)
            {
                Instantiate(gameMaster.GetComponent<PlayerInventory>().items[0], new Vector3 (transform.position.x, transform.position.y + 7, transform.position.z), transform.rotation);
            }

            if (GameManager.enemiesLeftInWave == 0 && PlayerInventory.hasDispenserKit == false && PlayerInventory.dispenserBuilt == false)
            {
                Instantiate(gameMaster.GetComponent<PlayerInventory>().items[0], new Vector3 (transform.position.x, transform.position.y + 7, transform.position.z), transform.rotation);
            }
        }
    }

	
}
