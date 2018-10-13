using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafMotion : MonoBehaviour
{
    Vector2 position;
    Vector2 velocity;

    // Use this for initialization
    void Start()
    {
        //position = new Vector2();
        velocity = new Vector2(0.05f, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }


	void FixedUpdate() {
		var rot = velocity.magnitude * 0.02f;
		if (velocity.x > 0)
			rot = -rot;

		velocity = velocity.Rotate(rot);

		Debug.Log(velocity); 

		if (velocity.y > 0)
			velocity += velocity.normalized * 0.05f;
		else
			velocity -= velocity.normalized * 0.05f;

		if (Input.GetKeyDown(KeyCode.LeftArrow))
			velocity = velocity.Rotate(-0.02f);
		else if (Input.GetKeyDown(KeyCode.RightArrow))
			velocity = velocity.Rotate(0.02f);

		position = velocity + position;

		GetComponent<Rigidbody2D>().position = position; 
	}
}