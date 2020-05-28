using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesManager : MonoBehaviour
{
	#region making singleton
	public static WavesManager Instance;

	private void Awake()
	{
		Instance = this;
	}
	#endregion

	#region variables
	public static float zombie1UniversalHealth;

	public GameObject zombie1;

	float wavesAfter9;

	public Text waveNumberText;

	private float preGameTimer = 3f;		//Timer before wave 1 starts
	public Text preGameTimerText;

    public Text pressK; 

	public static bool waveActive = false;		//Indicates wether the wave is active or not
	private bool waveModifierActive = false;//Indicates wether there is a wave modifier for the wave that is active
	private bool spawnActive = false;


	private bool runWaveClearedOnce = false;                               //Prevents the "WaveCleared" function from running multible times after you beat a wave. Must be true for WaveCleared function to be called at the end of a wave

	private List<ModifiedWave> modifiedWaves = new List<ModifiedWave>();    //Takes into account the Modified Waves that were setup

	int runWinOnlyOnce = 0;

	float startingWave;
	#endregion






	private void Start()
	{
		startingWave = GameManager.waveNumber;
		Zombie1SetHealth();





		foreach (ModifiedWave mW in GetComponents<ModifiedWave>())	// Makes it so that you have to place "Modified Wave" on GameObject "Game Master"
		{
			modifiedWaves.Add(mW);
		}


		StartCoroutine(StartFirstWave());							//Begins the first wave

		
	}

	IEnumerator StartFirstWave()
	{
		bool noMoreModifiedWaves = false;

		if (modifiedWaves.Count == 0)
		{
			noMoreModifiedWaves = true;
		}
		if (GameManager.waveNumber == 0)		// if wave number = 0 like it should
		{
			yield return new WaitForSeconds(preGameTimer); //waits the time before game starts
			IncreaseWaveNumber();
			Zombie1SetHealth();
			waveActive = true;
			runWaveClearedOnce = true;

			if (noMoreModifiedWaves == false)           //if ther are existing modified waves
			{
				if (modifiedWaves[0].modifiedWaveWaveNumber == 1)   // if pending modified wave number = 1
				{
					modifiedWaves[0].StartThisModifiedWave();   //start the modified wave
					waveModifierActive = true;
				}
				else
				{
					StandardWaveSpawner();
				}
			}
			else
			{
				StandardWaveSpawner();
			}
		}
		else			// if wave number != 1 (so if I'm debugging)
		{
			preGameTimer = 0;
			if (modifiedWaves.Count == 0)
			{
				noMoreModifiedWaves = true;
			}

			waveActive = true;
			runWaveClearedOnce = true;
			if (noMoreModifiedWaves == false)                                       //If there are modified waves
			{
				if (modifiedWaves[0].modifiedWaveWaveNumber == GameManager.waveNumber)      //If wave number assigned in the wave modifier = the actual static wave, then
				{
					waveModifierActive = true;
					StartPotentialModifiedWave();
				}
				else
				{
					StandardWaveSpawner();
				}
			}
			else
			{
				StandardWaveSpawner();
			}
		}
		
	}


	private void StartPotentialModifiedWave()
	{
		modifiedWaves[0].StartThisModifiedWave();                   //Start the pending modified wave
		spawnActive = true;

		Debug.Log("Modified wave is starting");
		

		
	}

	public void EndModifiedWave()			// cleans up the and destroys the modified wave after all events are done
	{
		Debug.Log("ending wave");
		waveModifierActive = false;
		Destroy(modifiedWaves[0]);
		modifiedWaves.RemoveAt(0);
		spawnActive = false;
	}
	

	private void Update()
	{

		
	
		
		


		if (GameManager.enemiesLeftInWave == 0)
		{
			waveActive = false;
		}



		if (preGameTimer <=0 && GameManager.waveNumber > 0 && !waveModifierActive && !waveActive && GameManager.enemiesLeftInWave == 0)		// if first wave already started and there is no wave modifier active and if the wave is not active, and there are no more enemies left in the wave then
		{
            pressK.text = "(K) for next Wave".ToString();

            if (Input.GetKeyDown(KeyCode.K))
			{
				StartNewWave();
			}
		}
        else
        {
            pressK.text = "".ToString();
        }
	

		if (GameManager.enemiesLeftInWave == 0 && spawnActive == false && GameManager.waveNumber >= 1 && runWaveClearedOnce == true)
		{
			WaveCleared();
		}


		#region UI
		if (GameManager.waveNumber > 0)
		{
			waveNumberText.text = "Wave " + GameManager.waveNumber.ToString();
		}
	

		if (GameManager.waveNumber < 1)
		{
			if (preGameTimer > 0)
			{
				preGameTimer -= Time.deltaTime;
			}

			preGameTimerText.text = "Get Ready: " + string.Format("{0:0}", preGameTimer);
            if (preGameTimer <= 0)
            {
                Destroy(preGameTimerText);
            }
		}
		#endregion

	}

	void WaveCleared()
	{
		Debug.Log("Wave cleared");
		waveActive = false;
		runWaveClearedOnce = false;
		if (modifiedWaves.Count == 0)
		{
			BeatAllModifiedWaves();
		}
	}

	private void BeatAllModifiedWaves()
	{
		runWinOnlyOnce++;

		if (runWinOnlyOnce == 1)
		{
			Debug.Log("you beat all modified waves");
		}
		
	}




	public void IncreaseWaveNumber()
	{
		GameManager.waveNumber++;
	}


	void StartNewWave()
	{
		bool noMoreModifiedWaves = false;

		if (modifiedWaves.Count == 0)
		{
			noMoreModifiedWaves = true;
		}

		IncreaseWaveNumber();
		Zombie1SetHealth();
		waveActive = true;
		runWaveClearedOnce = true;
		if (noMoreModifiedWaves == false)										//If there are modified waves
		{
			if (modifiedWaves[0].modifiedWaveWaveNumber == GameManager.waveNumber)      //If wave number assigned in the wave modifier = the actual static wave, then
			{
				waveModifierActive = true;
				StartPotentialModifiedWave();
			}
			else
			{
				StandardWaveSpawner();
			}
		}
		else
		{
			StandardWaveSpawner();
		}		
	}











	



	void Zombie1SetHealth()			// called at Start(), StartFirstWave(), and StartNewWave()
	{
		if (startingWave > 9)
		{
			if (GameManager.waveNumber == startingWave)     //for debugging (starting on later waves. It fixes the normal zombies' health after wave 9)
			{
				zombie1UniversalHealth = 950;
				wavesAfter9 = GameManager.waveNumber - 9;

				for (int i = 0; i < wavesAfter9 - 1; i++)
				{
					zombie1UniversalHealth = zombie1UniversalHealth * (1.1f);
				}
			}
		}


		if (GameManager.waveNumber == 1)
		{
			zombie1UniversalHealth = 150f;
		}
		if (GameManager.waveNumber == 2)
		{
			zombie1UniversalHealth = 250f;
		}
		if (GameManager.waveNumber == 3)
		{
			zombie1UniversalHealth = 350f;
		}
		if (GameManager.waveNumber == 4)
		{
			zombie1UniversalHealth = 450f;
		}
		if (GameManager.waveNumber == 5)
		{
			zombie1UniversalHealth = 550f;
		}
		if (GameManager.waveNumber == 6)
		{
			zombie1UniversalHealth = 650f;
		}
		if (GameManager.waveNumber == 7)
		{
			zombie1UniversalHealth = 750f;
		}
		if (GameManager.waveNumber == 8)
		{
			zombie1UniversalHealth = 850f;
		}
		if (GameManager.waveNumber == 9)
		{
			zombie1UniversalHealth = 950f;
		}
		if (GameManager.waveNumber > 9)
		{
			zombie1UniversalHealth = zombie1UniversalHealth * (1.1f);
		}
	}

	public void StandardWaveSpawner()
	{
		if (GameManager.waveNumber == 1)
		{
            // Amount of normal zombies
			GameManager.normalZombiesLeftInWave = 6;
			GameManager.enemiesLeftInWave = GameManager.enemiesLeftInWave + GameManager.normalZombiesLeftInWave;

            // Speed and Spawner of normal zombies.....   1st bool is slow, 2nd is medium, both false is fast
            SpawnManager.Instance.NormalZombieSpawner(true, 6, false, 0, false);
		}
		if (GameManager.waveNumber == 2)
		{
            // Amount of normal zombies
            GameManager.normalZombiesLeftInWave = 8;
			GameManager.enemiesLeftInWave = GameManager.enemiesLeftInWave + GameManager.normalZombiesLeftInWave;

            // Speed and Spawner of normal zombies.....   1st bool is slow, 2nd is medium, both false is fast
            SpawnManager.Instance.NormalZombieSpawner(true, 6, true, 2, false);
		}
		if (GameManager.waveNumber == 3)
		{
            // Amount of normal zombies
            GameManager.normalZombiesLeftInWave = 13;
			GameManager.enemiesLeftInWave = GameManager.enemiesLeftInWave + GameManager.normalZombiesLeftInWave;

            // Speed and Spawner of normal zombies.....   1st bool is slow, 2nd is medium, both false is fast
            SpawnManager.Instance.NormalZombieSpawner(true, 5, true, 8, false);
		}
		if (GameManager.waveNumber == 4)
		{
            // Amount of normal zombies
            GameManager.normalZombiesLeftInWave = 18;
			GameManager.enemiesLeftInWave = GameManager.enemiesLeftInWave + GameManager.normalZombiesLeftInWave;

            // Speed and Spawner of normal zombies.....   1st bool is slow, 2nd is medium, both false is fast
            SpawnManager.Instance.NormalZombieSpawner(false, 0, true, 16, false);
		}
		if (GameManager.waveNumber == 5)
		{
            // Amount of normal zombies
            GameManager.normalZombiesLeftInWave = 24;
			GameManager.enemiesLeftInWave = GameManager.enemiesLeftInWave + GameManager.normalZombiesLeftInWave;

            // Speed and Spawner of normal zombies.....   1st bool is slow, 2nd is medium, both false is fast
            SpawnManager.Instance.NormalZombieSpawner(false, 0, true, 20, false);
		}
		if (GameManager.waveNumber == 6)
		{
            // Amount of normal zombies
            GameManager.normalZombiesLeftInWave = 27;
			GameManager.enemiesLeftInWave = GameManager.enemiesLeftInWave + GameManager.normalZombiesLeftInWave;

            // Speed and Spawner of normal zombies.....   1st bool is slow, 2nd is medium, both false is fast
            SpawnManager.Instance.NormalZombieSpawner(true, 0, true, 15, false);
		}
		if (GameManager.waveNumber == 7)
		{
            // Amount of normal zombies
            GameManager.normalZombiesLeftInWave = 28;
			GameManager.enemiesLeftInWave = GameManager.enemiesLeftInWave + GameManager.normalZombiesLeftInWave;

            // Speed and Spawner of normal zombies.....   1st bool is slow, 2nd is medium, both false is fast
            SpawnManager.Instance.NormalZombieSpawner(false, 0, true, 10, false);
		}
		if (GameManager.waveNumber == 8)
		{
            // Amount of normal zombies
            GameManager.normalZombiesLeftInWave = 28;
			GameManager.enemiesLeftInWave = GameManager.enemiesLeftInWave + GameManager.normalZombiesLeftInWave;

            // Speed and Spawner of normal zombies.....   1st bool is slow, 2nd is medium, both false is fast
            SpawnManager.Instance.NormalZombieSpawner(false, 0, true, 3, false);
		}
		if (GameManager.waveNumber == 9)
		{
            // Amount of normal zombies
            GameManager.normalZombiesLeftInWave = 29;
			GameManager.enemiesLeftInWave = GameManager.enemiesLeftInWave + GameManager.normalZombiesLeftInWave;

            // Speed and Spawner of normal zombies.....   1st bool is slow, 2nd is medium, both false is fast
            SpawnManager.Instance.NormalZombieSpawner(false, 0, true, 1, false);
		}



		if (GameManager.waveNumber > 9)
		{
            // Amount of normal zombies
            GameManager.normalZombiesLeftInWave = Mathf.RoundToInt(((GameManager.waveNumber * .15f) * 24f));
			GameManager.enemiesLeftInWave = GameManager.enemiesLeftInWave + GameManager.normalZombiesLeftInWave;

            // Speed and Spawner of normal zombies.....   1st bool is slow, 2nd is medium, both false is fast
            // Last bool being true means it is after wave 9
            SpawnManager.Instance.NormalZombieSpawner(false, 0, false, 0, true);
		}

	}

	


}