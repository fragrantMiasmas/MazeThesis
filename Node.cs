using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public int row;
    public int col;

    public int topRow;
    public int botRow;
    public int rightCol;
    public int leftCol;

    public bool path;
    public bool visit;

    public Node(int nR, int nC) //pass in index of 2d array
    {
        this.row = nR;
        this.col = nC;

        // indices of adjacent nodes
        this.topRow = nR - 2;
        this.rightCol = nC + 2;
        this.botRow = nR + 2;
        this.leftCol = nC - 2;

        this.path = false;
        this.visit = false;
    }

    public bool getPath()
    {
        return this.path;
    }

    public bool getVisit()
    {
        return this.visit;
    }

    public bool setPath() //when wall gets knocked down, set path to true
    {
        return this.path = true;
    }

    public bool setVisit() //when node gets visited, set bool to true
    {
        return this.visit = true;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
