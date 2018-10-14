using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            GetComponent<Rigidbody2D>().velocity += new Vector2(-1, 0.0f); 
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            GetComponent<Rigidbody2D>().velocity += new Vector2(1, 0.0f);
    }
}
