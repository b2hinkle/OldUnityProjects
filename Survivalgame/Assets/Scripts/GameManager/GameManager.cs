using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	#region make singleton
	public static GameManager Instance;



	private void Awake()
	{
		Instance = this;
	}
    #endregion

    public static bool playerInside;

    public static float waveNumber = 0f;    //Game Wave number

    public static bool gotHit = false;
    




	public static int enemiesLeftInWave;            // "ModifiedWave" and "WavesManager" script takes care of adding when the wave starts, and value is subtracted in the enemies' manager script
	public static int enemiesLeftInEvent;
	public static int enemiesOutInWave;             // Added and subtracted in the enemies' manager script

	public static int normalZombiesLeftInWave;      // Set in the StandardWaveSpawner() function in "WavesManager", subracted in the normal zombie's manager
	public static int normalZombiesOutInWave;       // Added in the StandardWaveSpawner() function in "WavesManager", subracted in the normal zombie's manager



	

	public void GameOver()
	{
		SceneManager.LoadScene(0);
		Debug.Log("Game Over");
    }




    #region Controls

    #endregion
}
