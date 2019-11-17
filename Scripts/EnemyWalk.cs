using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    private float Speed = 2f;
    private bool MoveInLeft = true;
    public float rayDistance = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
        if (transform.position.x <= -2)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            MoveInLeft = false;
        }
        else if (transform.position.x >= 7)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            MoveInLeft = true;
        }
    }
}
    
   
 
