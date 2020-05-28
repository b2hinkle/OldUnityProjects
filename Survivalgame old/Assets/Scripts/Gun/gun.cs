using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
	public float damage = 10f;
	public float range = 100f;

	public Camera fpsCam;

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			shoot();

		}

	}
	void shoot ()
	{
		RaycastHit hit;
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);

			target_peekerHead target = hit.transform.GetComponent<target_peekerHead>();
			if (target != null)
			{
				target.takeDamage(damage);
			}
		}
	}
}
