using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMazeGen : MonoBehaviour //hypermaze
{

    public int ArraySize;
    public int startRow;
    public int startCol;
    public int startLev;
    public Node[, ,] nodeGrid;
    public int numNodes;
    public int currNumNodes;

    // Use this for initialization
    void Start()
    {
        ArraySize = 11; //chose an odd number
        nodeGrid = new Node[ArraySize, ArraySize, ArraySize]; //initualize 3d array

        //create new 2d aray
        for (int i = 0; i < ArraySize; i++)
        {
            for (int j = 0; j < ArraySize; j++)
            {
                for(int k =0; k < ArraySize; k++)
                {
                    Node currNode = Node.CreateInstance("Node") as Node;
                    currNode.setIndex(i, j, k);
                    nodeGrid[i, j, k] = currNode;
                }
                
            }
        }

        //instantiate adjacent nodes
        for (int i = 0; i < ArraySize; i++)
        {
            for (int j = 0; j < ArraySize; j++)
            {
                for (int k = 0; k < ArraySize; k++)
                {
                    Node currNode = nodeGrid[i, j, k];

                    if (i >= 2)
                    {
                        currNode.setNorth(nodeGrid[i - 2, j, k]); //set top node
                    }

                    if (i + 2 < ArraySize)
                    {
                        currNode.setSouth(nodeGrid[i + 2, j, k]); //set bottom node
                    }

                    if (j >= 2)
                    {
                        currNode.setWest(nodeGrid[i, j - 2, k]); //set left
                    }

                    if (j + 2 < ArraySize)
                    {
                        currNode.setEast(nodeGrid[i, j + 2, k]); //set right
                    }

                    if (k >= 2)
                    {
                        currNode.setDown(nodeGrid[i, j, k-2]); //set up
                    }

                    if (k + 2 < ArraySize)
                    {
                        currNode.setUp(nodeGrid[i, j, k + 2]); //set down
                    }

                }
                //end if statements
            }
        }

        startRow = (int)Random.Range(0, ArraySize); //normally returns float;
        startCol = 0;
        startLev = 1;
        Node startNode = nodeGrid[startRow,startCol, startLev];
        startNode.setPath();
        numNodes = 0;
        recursiveFunction(startNode); //start recursive generation

    }

    void recursiveFunction(Node currNode)
    {
        currNumNodes = 0;
        for (int i = 0; i < ArraySize; i++)
        {
            for (int j = 0; j < ArraySize; j++)
            {
                for (int k = 0; k < ArraySize; k++) { 
                    //top node
                    if (currNode.hasTop() && !currNode.top().path)
                {
                    currNumNodes++;
                    if (!currNode.top().visit) 
                    {
                        currNode.top().setVisit();
                        numNodes++;
                    }
                }

                //right node
                if (currNode.hasRight() && !currNode.right().path)
                {
                    currNumNodes++;
                    if (!currNode.right().visit)
                    {
                        currNode.right().setVisit();
                        numNodes++;
                    }
                }

                //bottom node
                if (currNode.hasBot() && !currNode.bot().path)
                {
                    currNumNodes++;

                    if (!currNode.bot().visit)
                    {
                        currNode.bot().setVisit();
                        numNodes++;
                    }
                }
                //left node
                if (currNode.hasLeft() && !currNode.left().path)
                {
                    currNumNodes++;
                    if (!currNode.left().visit)
                    {
                        currNode.left().setVisit();
                        numNodes++;
                    }
                }

                    //up node
                    if (currNode.hasUp() && !currNode.Up().path)
                    {
                        currNumNodes++;
                        if (!currNode.Up().visit)
                        {
                            currNode.Up().setVisit();
                            numNodes++;
                        }
                    }

                    //down node
                    if (currNode.hasDown() && !currNode.down().path)
                    {
                        currNumNodes++;
                        if (!currNode.down().visit)
                        {
                            currNode.down().setVisit();
                            numNodes++;
                        }
                    }
                    //randomly choose a path

                    if (numNodes > 0) //start if statement
                    {
                        while (currNumNodes > 0)
                        {
                            bool flag = false; //has been visited again
                            while (!flag)
                            {
                                int rand = (int)Random.Range(0, 6); //normally returns float

                                switch (rand)
                                {
                                    case 0:
                                        if (currNode.hasTop()) //choose top adjacent node if it exists
                                        {
                                            if (currNode.top().visit && !currNode.top().path)
                                            {
                                                //Debug.Log("case0");
                                                int wallRow = currNode.row - 1;
                                                nodeGrid[wallRow, currNode.col, currNode.lev].setPath();
                                                currNode.top().setPath();
                                                numNodes--;
                                                flag = true;
                                                recursiveFunction(currNode.top());
                                                //recalculate currNumNodes
                                                currNumNodes = calcCurrNumNodes(currNode);
                                            }

                                        }
                                        break; //end case 0
                                    case 1:
                                        if (currNode.hasRight()) //choose right adjacent node
                                        {
                                            if (currNode.right().visit && !currNode.right().path)
                                            {
                                                //Debug.Log("case1");
                                                int wallCol = currNode.col + 1; //choose right index
                                                nodeGrid[currNode.row, wallCol, currNode.lev].setPath();
                                                currNode.right().setPath();
                                                numNodes--;
                                                flag = true;
                                                recursiveFunction(currNode.right());
                                                currNumNodes = calcCurrNumNodes(currNode);
                                            }
                                        }
                                        break;
                                    case 2:
                                        if (currNode.hasBot()) //choose bottom adjacent node
                                        {
                                            if (currNode.bot().visit && !currNode.bot().path)
                                            {
                                                //Debug.Log("case2");
                                                int wallRow = currNode.row + 1;
                                                nodeGrid[wallRow, currNode.col, currNode.lev].setPath();
                                                currNode.bot().setPath();
                                                numNodes--;
                                                flag = true;
                                                recursiveFunction(currNode.bot());
                                                currNumNodes = calcCurrNumNodes(currNode);
                                            }
                                        }
                                        break;
                                    case 3:
                                        if (currNode.hasLeft()) //choose left adjacent nodem
                                        {
                                            if (currNode.left().visit && !currNode.left().path)
                                            {
                                                //Debug.Log("case3");
                                                int wallCol = currNode.col - 1;
                                                nodeGrid[currNode.row, wallCol, currNode.lev].setPath(); //issue
                                                currNode.left().setPath();
                                                numNodes--;
                                                flag = true;
                                                recursiveFunction(currNode.left());
                                                currNumNodes = calcCurrNumNodes(currNode);
                                            }
                                        }
                                        break;
                                    case 4:
                                        if (currNode.hasUp()) //choose above adjacent nodem
                                        {
                                            if (currNode.Up().visit && !currNode.Up().path)
                                            {
                                                Debug.Log("case4");
                                                int wallLev = currNode.lev + 1;
                                                nodeGrid[currNode.row, currNode.col, wallLev].setPath();
                                                currNode.Up().setPath();
                                                numNodes--;
                                                flag = true;
                                                recursiveFunction(currNode.Up());
                                                currNumNodes = calcCurrNumNodes(currNode);
                                            }
                                        }
                                        break;
                                    case 5:
                                        if (currNode.hasDown()) //choose below adjacent nodem
                                        {
                                            if (currNode.down().visit && !currNode.down().path)
                                            {
                                                //Debug.Log("case5");
                                                int wallLev = currNode.lev - 1;
                                                nodeGrid[currNode.row, currNode.col, wallLev].setPath();
                                                currNode.down().setPath();
                                                numNodes--;
                                                flag = true;
                                                recursiveFunction(currNode.down());
                                                currNumNodes = calcCurrNumNodes(currNode);
                                            }
                                        }
                                        break;
                                }
                            }
                        } //end if statement
                    }
                }
            }
        }
    }

    int calcCurrNumNodes(Node currNode)
    {
        //currNumNodes = 0;
        //top node
        if (currNode.hasTop() && !currNode.top().path)
        {
            currNumNodes++;

        }

        //right node
        if (currNode.hasRight() && !currNode.right().path)
        {
            currNumNodes++;
        }

        //bottom node
        if (currNode.hasBot() && !currNode.bot().path)
        {
            currNumNodes++;
        }

        //left node
        if (currNode.hasLeft() && !currNode.left().path)
        {
            currNumNodes++;
        }
        //up node
        if (currNode.hasUp() && !currNode.Up().path)
        {
            currNumNodes++;
        }
        //down node
        if (currNode.hasDown() && !currNode.down().path)
        {
            currNumNodes++;
        }
        else
            Debug.Log("currNumNodes does not increase");

        return currNumNodes;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
