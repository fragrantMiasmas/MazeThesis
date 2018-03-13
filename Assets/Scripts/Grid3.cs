using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid3 : MonoBehaviour //create cell array
{

    public int ArraySize;
    public int startRow;
    public int startCol;
    public Cell[,] CellArray;
    public int numNodes;
    public int currNumNodes;

    // Use this for initialization
    void Start()
    {
        ArraySize = 15;
        CellArray = new Cell[ArraySize, ArraySize];

        //create new 2d aray
        for (int i = 0; i < ArraySize; i++)
        {
            for (int j = 0; j < ArraySize; j++)
            {
                Cell currNode = Cell.CreateInstance("Cell") as Cell;
                currNode.setIndex(i,j);
                CellArray[i, j] = currNode;
                //Debug.Log(i + ", " + j);
            }
        } //end double for loop

        //instantiate adjacent nodes
        for (int i = 0; i < ArraySize; i++)
        {
            for (int j = 0; j < ArraySize; j++)
            {
                Cell currNode = CellArray[i, j];

                if (i >= 2)
                {
                    currNode.setNorth(CellArray[i - 2, j]); //set top node
                }

                if (i+2 < ArraySize)
                {
                    currNode.setSouth(CellArray[i + 2, j]); //set bottom node
                }

                if (j >= 2)
                {
                    currNode.setWest(CellArray[i , j-2]); //set left
                }

                if (j + 2 < ArraySize)
                {
                    currNode.setEast(CellArray[i, j + 2]); //set right
                }

                //end if statements
            }
        }
        startRow = (int)Random.Range(0, ArraySize); //normally returns float;
        startCol = 0;
        Cell startNode = CellArray[startRow, startCol];
        startNode.setPath();
        numNodes = 0;
        recursiveFunction(startNode); //start recursive generation

    }

    void recursiveFunction(Cell currNode)
    {
        currNumNodes = 0;
        for (int i = 0; i < ArraySize; i++)
        {
            for (int j = 0; j < ArraySize; j++)
            {

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
                    Debug.Log("curr num nodes = " + currNumNodes);
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

                //randomly choose a path

                if (numNodes > 0) //start if statement
                {
                    while (currNumNodes > 0)
                    {
                        bool flag = false; //has been visited again
                        while (!flag)
                        {
                            int rand = (int)Random.Range(0, 4); //normally returns float

                            switch (rand)
                            {
                                case 0:
                                    if (currNode.hasTop()) //choose top adjacent node if it exists
                                    {
                                        if (currNode.top().visit && !currNode.top().path)
                                        {
                                            int wallRow = currNode.row - 1;
                                            CellArray[wallRow, currNode.col].setPath();
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
                                            int wallCol = currNode.col + 1;
                                            CellArray[currNode.row, wallCol].setPath();
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
                                            int wallRow = currNode.row + 1;
                                            CellArray[wallRow, currNode.col].setPath();
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
                                            int wallCol = currNode.col - 1;
                                            CellArray[currNode.row, wallCol].setPath();
                                            currNode.left().setPath();
                                            numNodes--;
                                            flag = true;
                                            recursiveFunction(currNode.left());
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

    int calcCurrNumNodes(Cell currNode)
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
        else
            Debug.Log("currNumNodes does not increase");

        //Debug.Log("currNumNodes = " + currNumNodes);
        return currNumNodes;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
