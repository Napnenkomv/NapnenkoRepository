using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3 : MonoBehaviour


{

    void OnTriggerEnter2D(Collider2D othercol)
    {
        if (othercol.tag == "Player")
        {
            Application.LoadLevel("Scene3");
        }
    }
}
