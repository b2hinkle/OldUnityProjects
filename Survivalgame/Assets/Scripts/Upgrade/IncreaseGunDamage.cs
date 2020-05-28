using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseGunDamage : MonoBehaviour
{
    public gun gunScript;




    public void Triggered()
    {
        if (PointsManager.player1CurrentPoints >= 100)
        {
            PointsManager.player1CurrentPoints = PointsManager.player1CurrentPoints - 100;
            PointsManager.Instance.UpdatePointsNow();
            gunScript.damage = gunScript.damage * 3;
            
        }
    }
}
