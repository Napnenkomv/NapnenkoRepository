using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundWalk : MonoBehaviour
{
    private float Speed = 3f;
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
        if (transform.position.x <= -9)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            MoveInLeft = false;
        }
        else if (transform.position.x >= -1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            MoveInLeft = true;
        }
    }
}
