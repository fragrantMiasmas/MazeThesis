using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : ScriptableObject { //alternative for node
    public int row; //indices of current node
    public int col;

    Cell north;
    Cell south;
    Cell east;
    Cell west;

    public int topRow;
    public int botRow;
    public int rightCol;
    public int leftCol;

    public bool path;
    public bool visit;

    public Cell() //pass in index of 2d array
    {
          //adjacent nodes
        north = top();
        south = bot();
        east = right();
        west = left();

        // indices of adjacent nodes
        topRow = row - 2;
        rightCol = col + 2;
        botRow = row + 2;
        leftCol = col - 2;

        path = false;
        visit = false;
    }

   
    public void setIndex(int r, int c)
    {
        this.row = r;
        this.col = c;
    }

    public void setNorth(Cell n) //pass in row index
    {
        this.north = n;
    }

    public void setSouth(Cell s) //pass in row index
    {
        this.south = s;
    }

    public void setEast(Cell e) //pass in row index
    {
        this.east = e;
    }

    public void setWest(Cell w) //pass in row index
    {
        this.west = w;
    }

    public Cell top() 
    {
        return this.north;
    }

    public Cell bot() 
    {
        return this.south;
    }

    public Cell right() 
    {
        return this.east;
    }

    public Cell left() //pass in row index
    {
        return this.west;
    }


    public bool setPath() //when wall gets knocked down, set path to true
    {
        return path = true;
    }

    public bool setVisit() //when node gets visited, set bool to true
    {
        return visit = true;
    }

    public bool hasTop()
    {
        return this.north != null;
    }

    public bool hasBot()
    {
        return this.south != null;
    }

    public bool hasRight()
    {
        return this.east != null;
    }

    public bool hasLeft()
    {
        return this.west != null;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
