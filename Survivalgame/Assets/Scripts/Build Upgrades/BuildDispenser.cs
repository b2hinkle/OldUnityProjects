using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildDispenser : MonoBehaviour
{
    GameObject gameMaster;
    int range = 8;

    public Image progressBar;


    bool dispenserOn = false;



    void Awake()
    {
        
        

        gameMaster = GameObject.Find("Game Master");
    }

    private float startTime = 0f;
    private float timer = 0f;
    float holdTime = 5.0f; // how long you need to hold to trigger the effect
 
    // Use if you only want to call the method once after holding for the required time
    private bool held = false;







    void OnTriggerStay ()
    {


        // Starts the timer from when the key is pressed
        if (Input.GetKeyDown("e") && PlayerInventory.hasDispenserKit == true)
        {
            startTime = Time.time;
            timer = startTime;
        }
 
        // Adds time onto the timer so long as the key is pressed
        if (Input.GetKey("e") && held == false && PlayerInventory.hasDispenserKit == true)
        {
            progressBar.fillAmount += 1.0f / 5 * Time.deltaTime;
            timer += Time.deltaTime;
 
            // Once the timer float has added on the required holdTime, changes the bool (for a single trigger), and calls the function
            if (timer > (startTime + holdTime))
            {
                held = true;
                FinishedHolding();
            }
        }
        else
        {
            progressBar.fillAmount = 0;
            held = false;
        }

 
        
        
    }

    void OnTriggerExit()
    {
        progressBar.fillAmount = 0;
        held = false;
    }


    // Method called after held for required time
    void FinishedHolding()
    {
        progressBar.fillAmount = 0;
        Instantiate(gameMaster.GetComponent<PlayerInventory>().itemBuildings[0], new Vector3 (transform.position.x, transform.position.y - 13.6f, transform.position.z), transform.rotation);
        PlayerInventory.hasDispenserKit = false;
        PlayerInventory.Instance.DeleteFromInventory("DispenserKit");
        PlayerInventory.dispenserBuilt = true;
        Destroy(this);
    }
	
    
}
