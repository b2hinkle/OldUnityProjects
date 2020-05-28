using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    GameObject thisGameobject;

    void Start()
    {
        thisGameobject = gameObject;
    }

    void Destroy()
    {
        Destroy(thisGameobject);
    }


}
