using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    #region make singleton
    public static PlayerInventory Instance;



    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public static bool dispenserBuilt = false;




    #region has
    // Items
    public static bool hasDispenserKit = false;

    // PowerUps

    #endregion

    //just to store the prefabs
    public GameObject[] items;
    public GameObject[] itemGUIS;
    public GameObject[] itemBuildings;
    //0 = DispenserKit

    List<string> itemNames = new List<string>();




   

    public void AddToInventory(string itemName) // turn bool on in the item script
    {
        
        
        itemNames.Add(itemName);
        switch (itemName)
        {
            case "DispenserKit": itemGUIS[0].SetActive(true); break;
        }
    }
    public void DeleteFromInventory(string itemName)
    {
        itemNames.Remove(itemName);
        switch (itemName)
        {
            case "DispenserKit": itemGUIS[0].SetActive(false); hasDispenserKit = false; break;
        }
    }

    







    
}
