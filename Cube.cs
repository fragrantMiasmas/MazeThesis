using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    BoxCollider t;
    Rigidbody r;

    // Use this for initialization
    void Start () {
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        transform.localScale = new Vector3(2, 2, 1);

        transform.position = new Vector3(3, 2, 1); //why does it need to be a new vector3?
        t = GetComponent<BoxCollider>();
        r = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        //Instantiate(cube, transform.position, transform.rotation);
        r.AddForce(0, 5, 0);
    }
    void onCollisionEnter(Collision coll)
    {
        //this is called when a collision happens
    }
}