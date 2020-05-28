using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class gun : MonoBehaviour
{


    #region accuracy
    public float accuracy = .5f;

	#endregion

	bool fire;                                      //Condition for "fire" animation
	bool fireEmpty;                                 //Condition for "fireEmpty" animation
	bool ADS;
    public Animator anim;                           //Player Animator

	public RaycastHit hit;

	


	public float damage = 20f;
	public int range = 100;
	public float hitForce = 100f;


	public Camera fpsCam;							//Player Camera


	public int maxAmmo = 8;
	private int currentAmmo;
	public float reloadEmptyTime = 2.25f;			//Time until player can shoot again for "ReloadEmpty" animation
	public float reloadTime = 2.75f;					//Time until player can shoot again for "Reload" animation
	private bool aReloadAnimationPlaying = false;	//Reload animation is playing if true


	private void Start()
	{
		currentAmmo = maxAmmo;

    }



    private void OnEnable()
	{
		aReloadAnimationPlaying = false;
		anim.SetBool("reloadingEmpty", false);
	}

	

	private void Update()
	{
#region animator
		///////////////////////////////////////////   GUN BOOLIANS for animation
		if (fire == true)
		{
			anim.SetBool("fire", true);
		}
		if (fire == false)
		{
			anim.SetBool("fire", false);
		}
		if (fireEmpty == true)
		{
			anim.SetBool("fireEmpty", true);
		}
		if (fireEmpty == false)
		{
			anim.SetBool("fireEmpty", false);
		}
		if (ADS == true)
		{
			anim.SetBool("ADS", true);
		}
		if (ADS == false)
		{
			anim.SetBool("ADS", false);
		}




		if (Input.GetButtonDown("Fire1") && currentAmmo > 1)
		{
			fire = true;
		}
		if (!Input.GetButtonDown("Fire1"))
		{
			fire = false;
		}

		if (Input.GetButtonDown("Fire1") && currentAmmo == 1)
		{
			fireEmpty = true;
		}
		if (!Input.GetButtonDown("Fire1"))
		{
			fireEmpty = false;
		}

		if (Input.GetButton("Fire2"))
		{
			ADS = true;
		}
		if (!Input.GetButton("Fire2"))
		{
			ADS = false;
		}
		

		







		if (fire == true || fireEmpty == true)
		{
			shoot();
		}
		///////////////////////////////////////////   GUN BOOLIANS for animation
		#endregion
		#region crosshair
		if (this.anim.GetCurrentAnimatorStateInfo(1).IsName("ADS") || this.anim.GetCurrentAnimatorStateInfo(1).IsName("ADSIdle"))    // if ADS or ADSIdle animation playing
		{
			GameObject.Find("Crosshair").GetComponent<Image>().enabled = false;                                                     // disable crosshair component
		}
		else
		{
			GameObject.Find("Crosshair").GetComponent<Image>().enabled = true;
		}
		#endregion




		if (aReloadAnimationPlaying == true)
		{
			return;
		}

		StartCoroutine(Reload());






	}
   
    void shoot ()
	{
		if (aReloadAnimationPlaying == false)
		{
			currentAmmo--;




			if (currentAmmo > 0)
			{
				if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
				{
					if (hit.rigidbody != null)
					{
                        ApplyHitForce();
                        PointsManager.Instance.StartCoroutine();

                    }

					//Debug.Log(hit.transform.name);

					#region peeker
					Peeker_instakill peekerHead = hit.transform.GetComponent<Peeker_instakill>();
					if (peekerHead != null)
					{
						peekerHead.takeDamage(50);
					}


					Peeker_BodyPartHealth peekerBody = hit.transform.GetComponent<Peeker_BodyPartHealth>();
					if (peekerBody != null)
					{
						peekerBody.takeDamage(damage);
					}
					#endregion

					#region Shrek Damage
					ShrekHeadshotDmg shrekHeadshot = hit.transform.GetComponent<ShrekHeadshotDmg>();
					if (shrekHeadshot != null)
					{
						shrekHeadshot.takeDamage(Random.Range(damage*3.5f, (damage*3.5f)+5));
					}

					ShrekTorsoDmg shrekTorsoshot = hit.transform.GetComponent<ShrekTorsoDmg>();
					if (shrekTorsoshot != null)
					{
						shrekTorsoshot.takeDamage(Random.Range(damage, damage + 5));
					}

					ShrekLimbDmg shrekLimbshot = hit.transform.GetComponent<ShrekLimbDmg>();
					if (shrekLimbshot != null)
					{
						shrekLimbshot.takeDamage(Random.Range(damage-5, damage));
					}
					#endregion

					#region Zombie1 Damage
					Zombie1HeadshotDmg zombie1Headshot = hit.transform.GetComponent<Zombie1HeadshotDmg>();
					if (zombie1Headshot != null)
					{
						zombie1Headshot.takeDamage(Random.Range(damage*3.5f, (damage*3.5f) + 5));
					}

					Zombie1TorsoDmg zombie1Torsoshot = hit.transform.GetComponent<Zombie1TorsoDmg>();
					if (zombie1Torsoshot != null)
					{
						zombie1Torsoshot.takeDamage(Random.Range(damage, damage+5));
					}

					Zombie1LimbDmg zombie1Limbshot = hit.transform.GetComponent<Zombie1LimbDmg>();
					if (zombie1Limbshot != null)
					{
						zombie1Limbshot.takeDamage(Random.Range(damage-5, damage));
					}
					#endregion
				}
			}
		}

		
		
	}

	IEnumerator Reload()
	{
		if (currentAmmo < maxAmmo && (currentAmmo > 0))
		{
			if (Input.GetKeyDown("r"))
			{
				aReloadAnimationPlaying = true;

				anim.SetBool("reloading", true);

				yield return new WaitForSeconds(reloadTime - .25f);
				anim.SetBool("reloading", false);
				yield return new WaitForSeconds(.25f);

				currentAmmo = maxAmmo;
				aReloadAnimationPlaying = false;
			}
		}


		if (currentAmmo <= 0)
		{
			aReloadAnimationPlaying = true;

			anim.SetBool("reloadingEmpty", true);

			yield return new WaitForSeconds(reloadEmptyTime - .25f);
			anim.SetBool("reloadingEmpty", false);
			yield return new WaitForSeconds(.25f);

			currentAmmo = maxAmmo;
			aReloadAnimationPlaying = false;
		}



		
	}

	public void ApplyHitForce()
	{
		hit.rigidbody.AddForce(-hit.normal * hitForce);
	}

	public void ApplyKillForce()
	{
		hit.rigidbody.AddForce(-hit.normal * hitForce * 6);
	}



}

