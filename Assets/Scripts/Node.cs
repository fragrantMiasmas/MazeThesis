using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : ScriptableObject
{ //for generating 3d hypermaze, has up and down pointers

    public int row; //indices of current node
    public int col;
    public int lev;

    Node north;
    Node south;
    Node east;
    Node west;
    Node up;
    Node dwn;

    public int topRow;
    public int botRow;
    public int rightCol;
    public int leftCol;

    public bool path;
    public bool visit;

    public Node() //pass in index of 2d array
    {
        //adjacent nodes
        north = top();
        south = bot();
        east = right();
        west = left();
        up = Up();
        dwn = down();

        path = false;
        visit = false;
    }


    public void setIndex(int r, int c, int l)
    {
        this.row = r;
        this.col = c;
        this.lev = l;
    }

    //set pointers to adjacent nodes
    public void setNorth(Node n) //pass in row index
    {
        this.north = n;
    }

    public void setSouth(Node s) //pass in row index
    {
        this.south = s;
    }

    public void setEast(Node e) //pass in row index
    {
        this.east = e;
    }

    public void setWest(Node w) //pass in row index
    {
        this.west = w;
    }

    public void setUp(Node u) 
    {
        this.up = u;
    }

    public void setDown(Node d) 
    {
        this.dwn = d;
    }


    //get adjacent node
    public Node top()
    {
        return this.north;
    }

    public Node bot()
    {
        return this.south;
    }

    public Node right()
    {
        return this.east;
    }

    public Node left() 
    {
        return this.west;
    }

    public Node Up() 
    {
        return this.up;
    }

    public Node down() //pass in row index
    {
        return this.dwn;
    }


    //information on individual nodes
    public bool setPath() //when wall gets knocked down, set path to true
    {
        return path = true;
    }

    public bool setVisit() //when node gets visited, set bool to true
    {
        return visit = true;
    }

    //edge check when iterating through array
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

    public bool hasUp()
    {
        return this.up != null;
    }

    public bool hasDown()
    {
        return this.dwn != null;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
