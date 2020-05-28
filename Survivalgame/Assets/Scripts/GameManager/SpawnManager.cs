using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public static SpawnManager Instance;

	private void Awake()
	{
		Instance = this;
	}


	public GameObject zombie1;

	[Header("1-8 for any NPC")]
	[Header("9-16 for Peekers")]
	public List<Transform> spawnPoint = new List<Transform>();
	public List<GameObject> spawnPrefabs = new List<GameObject>();


	


	public void Spawn (int spawnPrefabIndex, int spawnPointIndex)
	{
		if (spawnPrefabIndex == 0)
		{
			return;
		}

		#region random spawn
		else if ((spawnPrefabIndex == 1) && spawnPointIndex == 0)		//for peeker is random
		{
			GetComponent<peekerSpawnManager>().spawnRandomPeeker();

		}
		else if ((spawnPrefabIndex == 2 || spawnPrefabIndex == 3) && spawnPointIndex == 0)        //for shrek is random
		{
			GetComponent<ShrekSpawnManager>().spawnRandomShrek(spawnPrefabIndex);
		}
		else if (spawnPrefabIndex == 4 && spawnPointIndex == 0)
		{
			int randomZombieSpawnIndex = Random.Range(1, 9);			//picks a random spawn index for the zombie between 1 and 8 (1 inclusive and 9 exclusive)
			Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[randomZombieSpawnIndex].position, spawnPoint[randomZombieSpawnIndex].rotation);
		}
		#endregion

		

		else
		{
			Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation);
		}
		 

		
	}


	IEnumerator OnlyAllow24NormalSlowZombiesOnMap()
	{
		yield return new WaitUntil(() => GameManager.normalZombiesOutInWave < 24);
		int randomZombieSpawnIndexStandard = Random.Range(1, 9);

		GameObject slowZomb = Instantiate(zombie1, spawnPoint[randomZombieSpawnIndexStandard].position, spawnPoint[randomZombieSpawnIndexStandard].rotation) as GameObject;
		slowZomb.GetComponent<Zombie1AI>().zombieNavMeshSpeed = 13;
		GameManager.normalZombiesOutInWave++;
		Debug.Log("finaly spawned lol");
	}
	IEnumerator OnlyAllow24NormalMediumZombiesOnMap()
	{
		yield return new WaitUntil(() => GameManager.normalZombiesOutInWave < 24);
		int randomZombieSpawnIndexStandard = Random.Range(1, 9);

		GameObject MediumZomb = Instantiate(zombie1, spawnPoint[randomZombieSpawnIndexStandard].position, spawnPoint[randomZombieSpawnIndexStandard].rotation) as GameObject;
		MediumZomb.GetComponent<Zombie1AI>().zombieNavMeshSpeed = 20;
		GameManager.normalZombiesOutInWave++;
		Debug.Log("finaly spawned lol");
	}
	IEnumerator OnlyAllow24NormalRunningZombiesOnMap()
	{
		yield return new WaitUntil(() => GameManager.normalZombiesOutInWave < 24);
		int randomZombieSpawnIndexStandard = Random.Range(1, 9);

		Instantiate(zombie1, spawnPoint[randomZombieSpawnIndexStandard].position, spawnPoint[randomZombieSpawnIndexStandard].rotation);
		GameManager.normalZombiesOutInWave++;
		Debug.Log("finaly spawned lol");
	}

	public void NormalZombieSpawner(bool zombieSlowSpeed, int slowAmount, bool zombieMediumSpeed, int mediumAmount, bool waveGreaterThan9)
	{
        // Spawns the slow zombies
		if (zombieSlowSpeed == true)
		{
			for (int sA = 0; sA < slowAmount; sA++)
			{
				int randomZombieSpawnIndexStandard = Random.Range(1, 9);


				if (GameManager.normalZombiesOutInWave < 24)
				{
					GameObject slowZomb = Instantiate(zombie1, spawnPoint[randomZombieSpawnIndexStandard].position, spawnPoint[randomZombieSpawnIndexStandard].rotation) as GameObject;
					slowZomb.GetComponent<Zombie1AI>().zombieNavMeshSpeed = 13;
					GameManager.normalZombiesOutInWave++;
				}
				else
				{
					StartCoroutine(OnlyAllow24NormalSlowZombiesOnMap());
				}
				
			}


		}
        // Spawns the medium speeded zombies
		if (zombieMediumSpeed == true)
		{
			for (int mA = 0; mA < mediumAmount; mA++)
			{
				int randomZombieSpawnIndexStandard = Random.Range(1, 9);



				if (GameManager.normalZombiesOutInWave < 24)
				{
					GameObject MediumZomb = Instantiate(zombie1, spawnPoint[randomZombieSpawnIndexStandard].position, spawnPoint[randomZombieSpawnIndexStandard].rotation) as GameObject;
					MediumZomb.GetComponent<Zombie1AI>().zombieNavMeshSpeed = 20;
					GameManager.normalZombiesOutInWave++;
				}
				else
				{
					StartCoroutine(OnlyAllow24NormalMediumZombiesOnMap());
				}
				
			}

		}



        // Spawns the runners
		for (int i = 0; i < GameManager.normalZombiesLeftInWave - (mediumAmount + slowAmount); i++)
		{
			int randomZombieSpawnIndexStandard = Random.Range(1, 9);




			if (GameManager.normalZombiesOutInWave < 24)
			{
				Instantiate(zombie1, spawnPoint[randomZombieSpawnIndexStandard].position, spawnPoint[randomZombieSpawnIndexStandard].rotation);
				GameManager.normalZombiesOutInWave++;
			}
			else
			{
				StartCoroutine(OnlyAllow24NormalRunningZombiesOnMap());
			}
			
		}

        // Spawns zombies after wave 9
        if (waveGreaterThan9 == true)
        {
            for (int i = 0; i < GameManager.normalZombiesLeftInWave; i++)
            {
                int randomZombieSpawnIndexStandard = Random.Range(1, 9);




                if (GameManager.normalZombiesOutInWave < 24)
                {
                    Instantiate(zombie1, spawnPoint[randomZombieSpawnIndexStandard].position, spawnPoint[randomZombieSpawnIndexStandard].rotation);
                    GameManager.normalZombiesOutInWave++;
                }
                else
                {
                    StartCoroutine(WaitUntilLessThan24NormalZombies());
                }

            }
        }
    }

    IEnumerator WaitUntilLessThan24NormalZombies()
    {
        yield return new WaitUntil(() => GameManager.normalZombiesOutInWave < 24);
        Spawn(4, 0);
        GameManager.normalZombiesOutInWave++;
        Debug.Log("finaly spawned lol");
    }



    public void AllowStandardWaveSpawner(bool allowStandardWaveSpawner)
	{
		
		if (allowStandardWaveSpawner == true)
		{
			
			GetComponent<WavesManager>().StandardWaveSpawner();
		}
	}
}
