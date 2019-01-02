using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour {
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow)) rb.AddForce(10f * Vector3.forward);
        if (Input.GetKey(KeyCode.RightArrow)) rb.AddForce(10f * Vector3.back);
        if (Input.GetKey(KeyCode.UpArrow)) rb.AddForce(10f * Vector3.right);
        if (Input.GetKey(KeyCode.DownArrow)) rb.AddForce(10f * Vector3.left);
    }
}
