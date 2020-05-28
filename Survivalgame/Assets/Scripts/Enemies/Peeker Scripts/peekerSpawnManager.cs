using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peekerSpawnManager : MonoBehaviour
{	public GameObject prefabToSpawn;

	public Transform peekerSpawnA;
	public Transform peekerSpawnB;
	public Transform peekerSpawnC;
	public Transform peekerSpawnD;
	public Transform peekerSpawnE;
	public Transform peekerSpawnF;
	public Transform peekerSpawnG;
	public Transform peekerSpawnH;

	int index;

	




	public void spawnRandomPeeker()
	{
		index = Random.Range(1, 9);
		executeFuntionByIndex();
	}



	void executeFuntionByIndex()
	{


		switch (index)
		{
			case 1: spawnAtA(); break;  //spawnA
			case 2: spawnAtB(); break;  //spawnB
			case 3: spawnAtC(); break;  //spawnC
			case 4: spawnAtD(); break;  //spawnD
			case 5: spawnAtE(); break;  //spawnE
			case 6: spawnAtF(); break;  //spawnF
			case 7: spawnAtG(); break;  //spawnG
			case 8: spawnAtH(); break;  //spawnH
		}
	}

	



	IEnumerator WaitThenSpawn()
	{
		yield return new WaitForSeconds (10.39999996f);
		spawnRandomPeeker();
	}

	#region spawnPoints
	

	void spawnAtA()
	{

		float _overlapRadius = 2.5f;
		Vector3 _overlapPosition = peekerSpawnA.transform.position; // paste here your spawn point position
																	//_overlapPosition = new Vector3(_overlapPosition.x, _overlapPosition.y + 1.5f, _overlapPosition.z);  //uncomment it if your spawn point y=0 (grounded) 
		Collider[] hitColliders = Physics.OverlapSphere(_overlapPosition, _overlapRadius);

		if (hitColliders.Length != 0)
		{
			StartCoroutine(WaitThenSpawn());
		}
		else
		{
			Instantiate(prefabToSpawn, peekerSpawnA.transform.position, peekerSpawnA.transform.rotation);
		}
	}
	void spawnAtB()
	{

		float _overlapRadius = 2.5f;
		Vector3 _overlapPosition = peekerSpawnB.transform.position; // paste here your spawn point position
																	//_overlapPosition = new Vector3(_overlapPosition.x, _overlapPosition.y + 1.5f, _overlapPosition.z);  //uncomment it if your spawn point y=0 (grounded) 
		Collider[] hitColliders = Physics.OverlapSphere(_overlapPosition, _overlapRadius);

		if (hitColliders.Length != 0)
		{
			StartCoroutine(WaitThenSpawn());
		}
		else
		{
			Instantiate(prefabToSpawn, peekerSpawnB.transform.position, peekerSpawnB.transform.rotation);
		}
	}
	void spawnAtC()
	{
		float _overlapRadius = 2.5f;
		Vector3 _overlapPosition = peekerSpawnC.transform.position; // paste here your spawn point position
																	//_overlapPosition = new Vector3(_overlapPosition.x, _overlapPosition.y + 1.5f, _overlapPosition.z);  //uncomment it if your spawn point y=0 (grounded) 
		Collider[] hitColliders = Physics.OverlapSphere(_overlapPosition, _overlapRadius);

		if (hitColliders.Length != 0)
		{
			StartCoroutine(WaitThenSpawn());
		}
		else
		{
			Instantiate(prefabToSpawn, peekerSpawnC.transform.position, peekerSpawnC.transform.rotation);
		}
	}
	void spawnAtD()
	{
		float _overlapRadius = 2.5f;
		Vector3 _overlapPosition = peekerSpawnD.transform.position; // paste here your spawn point position
																	//_overlapPosition = new Vector3(_overlapPosition.x, _overlapPosition.y + 1.5f, _overlapPosition.z);  //uncomment it if your spawn point y=0 (grounded) 
		Collider[] hitColliders = Physics.OverlapSphere(_overlapPosition, _overlapRadius);

		if (hitColliders.Length != 0)
		{
			StartCoroutine(WaitThenSpawn());
		}
		else
		{
			Instantiate(prefabToSpawn, peekerSpawnD.transform.position, peekerSpawnD.transform.rotation);
		}
	}
	void spawnAtE()
	{
		float _overlapRadius = 2.5f;
		Vector3 _overlapPosition = peekerSpawnE.transform.position; // paste here your spawn point position
																	//_overlapPosition = new Vector3(_overlapPosition.x, _overlapPosition.y + 1.5f, _overlapPosition.z);  //uncomment it if your spawn point y=0 (grounded) 
		Collider[] hitColliders = Physics.OverlapSphere(_overlapPosition, _overlapRadius);

		if (hitColliders.Length != 0)
		{
			StartCoroutine(WaitThenSpawn());
		}
		else
		{
			Instantiate(prefabToSpawn, peekerSpawnE.transform.position, peekerSpawnE.transform.rotation);
		}
	}
	void spawnAtF()
	{
		float _overlapRadius = 2.5f;
		Vector3 _overlapPosition = peekerSpawnF.transform.position; // paste here your spawn point position
																	//_overlapPosition = new Vector3(_overlapPosition.x, _overlapPosition.y + 1.5f, _overlapPosition.z);  //uncomment it if your spawn point y=0 (grounded) 
		Collider[] hitColliders = Physics.OverlapSphere(_overlapPosition, _overlapRadius);

		if (hitColliders.Length != 0)
		{
			StartCoroutine(WaitThenSpawn());
		}
		else
		{
			Instantiate(prefabToSpawn, peekerSpawnF.transform.position, peekerSpawnF.transform.rotation);
		}
	}
	void spawnAtG()
	{
		float _overlapRadius = 2.5f;
		Vector3 _overlapPosition = peekerSpawnG.transform.position; // paste here your spawn point position
																	//_overlapPosition = new Vector3(_overlapPosition.x, _overlapPosition.y + 1.5f, _overlapPosition.z);  //uncomment it if your spawn point y=0 (grounded) 
		Collider[] hitColliders = Physics.OverlapSphere(_overlapPosition, _overlapRadius);

		if (hitColliders.Length != 0)
		{
			StartCoroutine(WaitThenSpawn());
		}
		else
		{
			Instantiate(prefabToSpawn, peekerSpawnG.transform.position, peekerSpawnG.transform.rotation);
		}
	}
	void spawnAtH()
	{
		float _overlapRadius = 2.5f;
		Vector3 _overlapPosition = peekerSpawnH.transform.position; // paste here your spawn point position
																	//_overlapPosition = new Vector3(_overlapPosition.x, _overlapPosition.y + 1.5f, _overlapPosition.z);  //uncomment it if your spawn point y=0 (grounded) 
		Collider[] hitColliders = Physics.OverlapSphere(_overlapPosition, _overlapRadius);

		if (hitColliders.Length != 0)
		{
			StartCoroutine(WaitThenSpawn());
		}
		else
		{
			Instantiate(prefabToSpawn, peekerSpawnH.transform.position, peekerSpawnH.transform.rotation);
		}
	}
	#endregion
}

