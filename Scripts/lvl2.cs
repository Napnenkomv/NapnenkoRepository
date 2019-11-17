using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2 : MonoBehaviour

    
{

    void OnTriggerEnter2D(Collider2D othercol)
    {
        if (othercol.tag == "Player")
        {
            Application.LoadLevel("Scene2");
        }
    }
}

