using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    #region make singleton
    public static SpawnGhost Instance;



    private void Awake()
    {
        Instance = this;
    }
    #endregion


    public GameObject ghost;
    public Transform player;

    float timer = 0;
    float spawnEveryBlankSeconds = 1;

    int spawnFirstGhost = 0;

    




   


    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            SpawnAGhost();
            GameManager.playerInside = false;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            GameManager.playerInside = true;
        }        
    }

    private void Update()
    {



        if (GameManager.playerInside == false)
        {
            timer = timer + Time.deltaTime;
            if (timer > spawnEveryBlankSeconds)
            {
                timer = 0;
            }


            if (timer == 0)
            {
                SpawnAGhost();
            }
        }
    }




    public void SpawnAGhost()
    {
        if (WavesManager.waveActive == true)
        {
            int randomPosi;
            randomPosi = Random.Range(1, 5);


            switch (randomPosi)
            {
                case 1:
                    Instantiate(ghost, new Vector3(player.transform.position.x, Random.Range(player.transform.position.y - 11, player.transform.position.y - 3), Random.Range(player.transform.position.z + 50, player.transform.position.z + 40)), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(ghost, new Vector3(player.transform.position.x, Random.Range(player.transform.position.y - 11, player.transform.position.y - 3), Random.Range(player.transform.position.z - 50, player.transform.position.z - 40)), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(ghost, new Vector3(Random.Range(player.transform.position.x - 50, player.transform.position.x - 40), Random.Range(player.transform.position.y - 11, player.transform.position.y - 3), player.transform.position.z), Quaternion.identity);
                    break;
                case 4:
                    Instantiate(ghost, new Vector3(Random.Range(player.transform.position.x + 50, player.transform.position.x + 40), Random.Range(player.transform.position.y - 11, player.transform.position.y - 3), player.transform.position.z), Quaternion.identity);
                    break;
            }
        }
        
        
    }
    
}
