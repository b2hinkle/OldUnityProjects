using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUse : MonoBehaviour
{
    #region make singleton
    public static PlayerUse Instance;



    private void Awake()
    {
        Instance = this;
        cameraController = GameObject.Find("Camera Control");
    }
    #endregion


    GameObject cameraController;

    public GameObject upgradeArea;

    public static RaycastHit useHit;
    public Camera fpsCam;
    int useRange = 8;

    public GameObject upgradeCanvas;


    public bool upgradeAreaActive = false;
    int upgradeAreaActiveIndex = 0;

    public GameObject cameraControl;

    public GameObject weaponSwayGameObject;

    bool dispenserOn = false;

    

    



    void Update()
    {

        if (Input.GetKeyDown("e"))
        {
            Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out useHit, useRange);

            #region Dispenser
            if (dispenserOn == true && useHit.transform.tag == "Dispenser")
            {
                upgradeAreaActive = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }

            if (dispenserOn == false && useHit.transform.tag == "Dispenser")
            {

                Destroy(GameObject.Find("OffScreen"));
                dispenserOn = true;
            }
        }
        if (Input.GetKeyDown("escape") && upgradeAreaActive == true)
        {
            upgradeAreaActive = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (upgradeAreaActive == true && upgradeAreaActiveIndex % 2 == 0)
        {
            upgradeAreaActiveIndex++;
            upgradeArea.SetActive(true);
            GetComponent<PlayerMovement>().enabled = false;
            cameraController.GetComponent<Headbobber>().enabled = false;
            cameraController.GetComponent<CharacterLook>().enabled = false;
            
        }
        else if (upgradeAreaActive == false && upgradeAreaActiveIndex % 2 == 1)
        {
            upgradeAreaActiveIndex++;
            upgradeArea.SetActive(false);
            GetComponent<PlayerMovement>().enabled = true;
            cameraController.GetComponent<Headbobber>().enabled = true;
            cameraController.GetComponent<CharacterLook>().enabled = true;
        }
        #endregion



    }



    #region Dispenser
    void Dispenser()
    {
        if (dispenserOn == true && useHit.transform.tag == "Dispenser")
        {
            upgradeCanvas.SetActive(true);
            upgradeAreaActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }

        if (dispenserOn == false && useHit.transform.tag == "Dispenser")
        {
            
            Destroy(GameObject.Find("OffScreen"));
            dispenserOn = true;
        }
    }
    #endregion
}
