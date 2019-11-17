using UnityEngine;

public class Dead2 : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Application.LoadLevel("Scene3");
        }
    }
}

