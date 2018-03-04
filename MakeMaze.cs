using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public Light myLight;

    MazeGen mazegen = new MazeGen();
    Cube cube = new Cube();

    void makeMaze()
    {

    }

    // Use this for initialization
    void Start () {
        int gridsize = mazegen.gridSize;
        Node[,] mazeArray = mazegen.mazeMap; //get the 2d array of nodes from mazegen

        for(int i =0; i < gridsize; i++) //go through 2d array
        {
            for(int j = 0; j<gridsize; j++)
            {
                //if there isn't a pathway (path = 0), put a wall there
                //go through all 4 pointers
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        //example code
        if (Input.GetKey("space"))
        {
            myLight.enabled = true;
        }
        else
        {
            myLight.enabled = false;
        }
    }
}
