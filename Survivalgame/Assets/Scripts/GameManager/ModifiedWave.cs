using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModifiedWave : MonoBehaviour
{
	public List<WaveEvent> events = new List<WaveEvent>();

	private bool isPlaying = false;

	public bool allowStandardWaveSpawner = false;


	public float modifiedWaveWaveNumber;



	public void StartThisModifiedWave()
	{
		#region Gets static ints
		for (int i = 0; i < events.Count; i++)
		{
			events[i].GetEnemiesLeftInWave();           //Gets the amount of enemies you need to kill in order to complete the current wave
		}
		events[0].GetEnemiesLeftInEvent();              // Gets the amount of enemies you need to kill in order to complete the current event
		#endregion

		if (allowStandardWaveSpawner == true)
		{
			AllowStandardWaveSpawner();
		}
		
		

		isPlaying = true;
		if (events.Count != 0)      // if there is an event in the wave
		{
			events[0].StartEvent();

		}
		else
		{
			WavesManager.Instance.EndModifiedWave();
		}
	}

	public void AllowStandardWaveSpawner()
	{
		if (modifiedWaveWaveNumber == GameManager.waveNumber)
		{
			SpawnManager.Instance.AllowStandardWaveSpawner(allowStandardWaveSpawner);
		}
	}

	private void Update()
	{
		if (!isPlaying)
		{
			return;
		}
		
		if (!events[0].RunEvent())      // (RunEvent must be false) if there is an event, and its over, 
		{
			
			events.RemoveAt(0);         //then remove it from the list


			if (events.Count == 0)      //if there is no more events on the list, then 
			{
				WavesManager.Instance.EndModifiedWave();
			}
			else
			{
				events[0].StartEvent(); // play the next event
				events[0].GetEnemiesLeftInEvent();              // Gets the amount of enemies you need to kill in order to complete the current event
			}
		}
	}

	[System.Serializable]
	public class WaveEvent
	{
		private int amount;

		public float duration;
		public List<SpawnInfo> spawnInfos;



		private float startTime;

		#region Get Static Vars
		public void GetEnemiesLeftInWave()          //called in the "Wave" class to get "enemiesLeftInWave"
		{
			for (int i = 0; i < spawnInfos.Count; i++)
			{
				GameManager.enemiesLeftInWave = GameManager.enemiesLeftInWave + spawnInfos[i].amount;
			}
		}
		public void GetEnemiesLeftInEvent()         //called at the beginning of "StartWave" & called in the end of the update func
		{
			for (int i = 0; i < spawnInfos.Count; i++)
			{
				GameManager.enemiesLeftInEvent = GameManager.enemiesLeftInEvent + spawnInfos[i].amount;
			}
		}
		#endregion





		public void StartEvent()
		{
			startTime = Time.time;


		}




		public bool RunEvent()
		{
			if (duration == 0.0f && spawnInfos.Count == 0)      // if we put no duration to our event, and if the event has lasted for 5 or more seconds, and enemiesOutInWave = 0, then
			{
				return false;                                   // end event
			}
			else if (Time.time - startTime > duration && duration != 0.0f) // if we did put a duration to our event, then when the duration ends, 
			{
				return false;   // stop spawning stuff
			}



			for (int i = 0; i < spawnInfos.Count; i++)  // for every spawnInfo we have (prefab along with its values),
			{
				if (spawnInfos[i].amount > 0)
				{
					spawnInfos[i].ReadyToSpawn();
				}
				

				if (spawnInfos[i].amount == 0)          // if we are done spawning stuff
				{

					spawnInfos.RemoveAt(i);
				}


			}

			return true;
		}

		[System.Serializable]
		public class SpawnInfo
		{
			private List<ModifiedWave> modifiedWaves = new List<ModifiedWave>();
			[Header("If Spawn Point 0, spawn in specified random locations")]
			[Header("specified random locations are changable in SpawnManager script")]
			public int spawnPointIndex;
			public int spawnPrefabIndex;
			public int amount;
			




			public float interval;

			

			
				
				
			


			private float lastTime;                 // last time an object was spawned


			

			public void InstantSpawn()
			{
				SpawnManager.Instance.Spawn(spawnPrefabIndex, spawnPointIndex);
				amount--;
				lastTime = Time.time;
			}

			public void ReadyToSpawn()
			{
				if (Time.time - lastTime >= (interval))
				{
					SpawnManager.Instance.Spawn(spawnPrefabIndex, spawnPointIndex);
					amount--;
					lastTime = Time.time;
				}
			}


		}
	}


}
