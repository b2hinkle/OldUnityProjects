using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerStart : MonoBehaviour
{


    Transform player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player").transform;

        Vector3 faceVector = new Vector3(player.position.x - transform.position.x, 0.0f, player.position.z - transform.position.z);
        Quaternion look = Quaternion.LookRotation(faceVector);
        float x = look.eulerAngles.x;
        float y = look.eulerAngles.y;
        float z = look.eulerAngles.z;


        y = Mathf.RoundToInt(y / 90.0f) * 90.0f;
       



        transform.rotation = Quaternion.Euler(look.eulerAngles.x, y - 180, look.eulerAngles.z);

        

       // transform.LookAt(new Vector3((player.position.x), transform.position.y, player.position.z));

        
    }

    


    

}
