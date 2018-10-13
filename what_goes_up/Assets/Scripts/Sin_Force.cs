using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sin_Force : MonoBehaviour {

    private Vector3 _startPosition; 

	// Use this for initialization
	void Start () {
        _startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = _startPosition + new Vector3(Mathf.Sin(Time.time) * 2, 0.0f, 0.0f);
    }
}
