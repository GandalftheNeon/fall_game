using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf_Dynamic : MonoBehaviour
{

    private float grav = .5f;
    private float drag = .994f;
    private float drag_min = 10.0f;
    private float controls = .014f;
    private float rotation = .002f;

    private Vector2 upwards = Vector2.up;
    private Vector2 rot = new Vector2(1, 0);
    private Vector2 vel;


    // Use this for initialization
    void Start()
    {

        //Vector2 curPos = transform.position; 
        //Vector2 rotation = new Vector2(transform.rotation.x, 0); 
        vel = new Vector2(12, 0);

    }

    static Vector2 Polar(float len, float dir)
    {
        return new Vector2(len * Mathf.Cos(dir), len * Mathf.Sin(dir));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 curPos = transform.position;
        curPos += vel;
        //curPos += new Vector2(0, -.5f);

        float delta = vel.Get_Delta(upwards) / (Mathf.PI / 2.0f);
        delta *= vel.magnitude * rotation;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            delta -= controls;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            delta += controls;

        vel = Polar(vel.magnitude, Mathf.Atan2(vel.y, vel.x) + delta);
        upwards = Polar(1, Mathf.Atan2(upwards.y, upwards.x) + delta);
        rot = Polar(1, Mathf.Atan2(rot.y, rot.x) + delta);

        if (vel.y < 0)
        {
            vel += vel.normalized * grav;
        }
        else
        {
            vel -= vel.normalized * grav;
        }

        if (vel.magnitude < 1 && upwards.y < 0)
        {
            upwards *= -1;
        }

        if (vel.magnitude > drag_min)
        {
            vel *= drag;
        }

        transform.position = curPos;
    }
}
