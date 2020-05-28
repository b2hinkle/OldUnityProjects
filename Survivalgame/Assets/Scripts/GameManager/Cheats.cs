using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
	public GameObject player;
	public GameObject gun;


    public int points;


	public float gunDmg;

	public float runSpeed;

	public float waveNumber;

	public int clipSize;

	public bool allowCheats;

    private void Start()
    {
        if (allowCheats == true)
        {
            PointsManager.player1CurrentPoints = points;
        }
    }

    private void Awake()
	{
		if (allowCheats == true)
		{
           

			gun.GetComponent<gun>().damage = gunDmg;

			player.GetComponent<PlayerMovement>().runSpeed = runSpeed;

			GameManager.waveNumber = waveNumber;

			gun.GetComponent<gun>().maxAmmo = clipSize;
		}
	}
}
