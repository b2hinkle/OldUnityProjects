using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekSpawnManager : MonoBehaviour
{
	public GameObject shrekWalk;
	public GameObject shrekRun;

	public Transform SpawnA;
	public Transform SpawnB;
	public Transform SpawnC;
	public Transform SpawnD;
	public Transform SpawnE;
	public Transform SpawnF;
	public Transform SpawnG;
	public Transform SpawnH;

	int index;

	int prefabToSpawn;




	public void spawnRandomShrek(int value)
	{
		prefabToSpawn = value;
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



	#region spawnPoints


	void spawnAtA()
	{
		if (prefabToSpawn == 2)
		{
			Instantiate(shrekWalk, SpawnA.transform.position, SpawnA.transform.rotation);
		}
		if (prefabToSpawn == 3)
		{
			Instantiate(shrekRun, SpawnA.transform.position, SpawnA.transform.rotation);
		}
	}
	void spawnAtB()
	{
		if (prefabToSpawn == 2)
		{
			Instantiate(shrekWalk, SpawnB.transform.position, SpawnB.transform.rotation);
		}
		if (prefabToSpawn == 3)
		{
			Instantiate(shrekRun, SpawnB.transform.position, SpawnB.transform.rotation);
		}
	}
	void spawnAtC()
	{
		if (prefabToSpawn == 2)
		{
			Instantiate(shrekWalk, SpawnC.transform.position, SpawnC.transform.rotation);
		}
		if (prefabToSpawn == 3)
		{
			Instantiate(shrekRun, SpawnC.transform.position, SpawnC.transform.rotation);
		}
	}
	void spawnAtD()
	{
		if (prefabToSpawn == 2)
		{
			Instantiate(shrekWalk, SpawnD.transform.position, SpawnD.transform.rotation);
		}
		if (prefabToSpawn == 3)
		{
			Instantiate(shrekRun, SpawnD.transform.position, SpawnD.transform.rotation);
		}
	}
	void spawnAtE()
	{
		if (prefabToSpawn == 2)
		{
			Instantiate(shrekWalk, SpawnE.transform.position, SpawnE.transform.rotation);
		}
		if (prefabToSpawn == 3)
		{
			Instantiate(shrekRun, SpawnE.transform.position, SpawnE.transform.rotation);
		}
	}
	void spawnAtF()
	{
		if (prefabToSpawn == 2)
		{
			Instantiate(shrekWalk, SpawnF.transform.position, SpawnF.transform.rotation);
		}
		if (prefabToSpawn == 3)
		{
			Instantiate(shrekRun, SpawnF.transform.position, SpawnF.transform.rotation);
		}
	}
	void spawnAtG()
	{
		if (prefabToSpawn == 2)
		{
			Instantiate(shrekWalk, SpawnG.transform.position, SpawnG.transform.rotation);
		}
		if (prefabToSpawn == 3)
		{
			Instantiate(shrekRun, SpawnG.transform.position, SpawnG.transform.rotation);
		}
	}
	void spawnAtH()
	{
		if (prefabToSpawn == 2)
		{
			Instantiate(shrekWalk, SpawnH.transform.position, SpawnH.transform.rotation);
		}
		if (prefabToSpawn == 3)
		{
			Instantiate(shrekRun, SpawnH.transform.position, SpawnH.transform.rotation);
		}
	}
	#endregion
}

