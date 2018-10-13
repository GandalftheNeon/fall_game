using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafMotion : MonoBehaviour
{
    //Vector2 position;
    Vector2 velocity;

    // Use this for initialization
    void Start()
    {
        //position = new Vector2();
        velocity = new Vector2(24, 0);
    }

    // Update is called once per frame
    void Update()
    {
        var rot = velocity.magnitude * 0.002f;
        if (velocity.x > 0)
            rot = -rot;

        velocity = velocity.Rotate(rot);

        Debug.Log(velocity); 

        if (velocity.y > 0)
            velocity += velocity.normalized * -1;
        else
            velocity += velocity.normalized * 1;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            velocity = velocity.Rotate(-0.02f);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            velocity = velocity.Rotate(0.02f);

        GetComponent<Rigidbody2D>().velocity = velocity; 
    }
}
