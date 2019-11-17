using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGame : MonoBehaviour
{
    private bool Pause = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0f;
                Pause = false; 
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1f;
                Pause = true;
            }
        }
    }
}
