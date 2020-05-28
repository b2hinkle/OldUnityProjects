using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePoints : MonoBehaviour
{
    private GameObject gameMaster;

    void Start()
    {
        gameMaster = GameObject.FindGameObjectWithTag("Game Master");
    }


    void UpdatePlayerPoints()
    {
        gameMaster.GetComponent<PointsManager>().player1Points.text = PointsManager.player1CurrentPoints.ToString();
    }
  

}
