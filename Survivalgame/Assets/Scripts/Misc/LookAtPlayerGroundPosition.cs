using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerGroundPosition : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }
}

