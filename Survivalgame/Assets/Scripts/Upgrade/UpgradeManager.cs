using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    #region
    public static bool ghostBarrierActive;
    #endregion


    public gun gunScript;




    private void Awake()
    {
        ghostBarrierActive = false;
    }









    public void UpgradeJug()
    {
        if (PointsManager.player1CurrentPoints >= 1000)
        {
            PointsManager.player1CurrentPoints = PointsManager.player1CurrentPoints - 1000;
            PlayerHealth.Instance.UpgradeJug();
            Debug.Log("Health Upgraded");
        }
            
    }


    public void UpgradeDamage()
    {
        if (PointsManager.player1CurrentPoints >= 1000)
        {
            PointsManager.player1CurrentPoints = PointsManager.player1CurrentPoints - 1000;
            PointsManager.Instance.UpdatePointsNow();
            gunScript.damage = gunScript.damage * 3;

            Debug.Log("Damage upgraded");
        }
    }

    public void GhostBarrier()
    {
        if (PointsManager.player1CurrentPoints >= 100 && ghostBarrierActive == false)
        {
            PointsManager.player1CurrentPoints = PointsManager.player1CurrentPoints - 100;
            PointsManager.Instance.UpdatePointsNow();
            ghostBarrierActive = true;


            Debug.Log("Ghost Barrier Bought");

        }
    }
}
