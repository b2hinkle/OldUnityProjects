using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Peeker_attack : MonoBehaviour
{
	public Animator peekerAnimator;
	GameObject gameMaster;


	int playerDieOnce = 0;


	private Transform Player;
	public int MoveSpeed;
	public int MinDist;


	private void Start()
	{
        gameMaster = GameObject.FindGameObjectWithTag("Game Master");
		Player = GameObject.FindWithTag("Player").transform;
	}


	void Update()
	{
		if (this.peekerAnimator.GetCurrentAnimatorStateInfo(0).IsName("pillarCharge"))
		{
			if (Vector3.Distance(transform.position, Player.position) <= MinDist)  // if peeker reaches the min distance then....
			{
				playerDieOnce = playerDieOnce + 1;
				if (playerDieOnce == 1)
				{
					GameManager.Instance.GameOver();
                    playerDieOnce++;
				}

			}
			transform.LookAt(Player);                                           // look at player

			if (Vector3.Distance(transform.position, Player.position) >= MinDist)   // if npc is far enough away to move at you 
			{
				
				transform.position += transform.forward * MoveSpeed * Time.deltaTime; // move toward player with MoveSpeed
			}
		}		
	}
}