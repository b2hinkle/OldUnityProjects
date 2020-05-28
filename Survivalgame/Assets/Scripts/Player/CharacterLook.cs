using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    GameObject player;

	Vector2 MouseLook;
	Vector2 SmoothV;
	public float Sensitivity = 5.0f;
	public float Smoothing = 2.0f;

	GameObject Character;


	public void AdjustSensitivity(float newSensitivity)
	{
		Sensitivity = newSensitivity;
	}



	private void Start()
	{
        player = GameObject.FindWithTag("Player");


		Character = this.transform.parent.gameObject;





		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;                   // cursor/mouse locked
	}

	private void Update()
	{
		var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		md = Vector2.Scale(md, new Vector2(Sensitivity * Smoothing, Sensitivity * Smoothing));
		SmoothV.x = Mathf.Lerp(SmoothV.x, md.x, 1f / Smoothing);
		SmoothV.y = Mathf.Lerp(SmoothV.y, md.y, 1f / Smoothing);
		MouseLook += SmoothV;
		MouseLook.y = Mathf.Clamp(MouseLook.y, -90f, 90f);         // clamp looking up and down past 90 degrees

		
		Character.transform.localRotation = Quaternion.AngleAxis(MouseLook.x, Character.transform.up);
		transform.localRotation = Quaternion.AngleAxis(-MouseLook.y, Vector3.right);






		if (Input.GetKeyDown("escape") && player.GetComponent<PlayerUse>().upgradeAreaActive == false)
		{
            
			Cursor.lockState = CursorLockMode.None;                // cursor/mouse unlocked if esc
		}
	}

	
}
