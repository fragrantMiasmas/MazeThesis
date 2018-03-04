using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour {

    public int gridSize = 4; //start with 4x4 maze
    public Node[,] mazeMap; //declare a 2d array to be called in makeMaze
    int startRow;
    int startCol;
    Node currNode;

    void createMazeMap()
    {
        //create 2d array of nodes
        mazeMap = new Node[gridSize, gridSize];
        Debug.Log("hello");

        //pick random starting node along one side
        startRow = 0; //change to random number later
        startCol = 0;
        Node startNode = mazeMap[startRow, startCol];
        startNode.setPath();

        //fill 2d array with nodes, is this reduntant?
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Node node = new Node(i, j);
                mazeMap[i, j] = node;
            }
        }


    }

    void recursiveFunction(Node[,] mazeMap)
    {
        for(int i = 0; i <gridSize; i++)
        {
            for(int j = 0; j < gridSize; j++)
            {
                //top node

                int currNumNodes = 0;
                int numNodes = 0;
                //top node
                if (currNode.topRow >= 0 && mazeMap[currNode.topRow,currNode.col].path == false)
                {
                    currNumNodes++;
                    if (mazeMap[currNode.topRow, currNode.col].visit == false) //change to !mazeMap.isvist()
                    {
                        mazeMap[currNode.topRow,currNode.col].setVisit();
                        numNodes++;
                    }
                }

                //right node
                if (currNode.rightCol < this.gridSize && mazeMap[currNode.row, currNode.rightCol].path == false)
                {
                    currNumNodes++;
                    if (mazeMap[currNode.row,currNode.rightCol].visit == false)
                    {
                        mazeMap[currNode.row,currNode.col].setVisit();
                        numNodes++;
                    }
                }

                //bottom node
                if (currNode.botRow < gridSize && mazeMap[currNode.botRow, currNode.col].path == false)
                {
                    currNumNodes++;
                    if (mazeMap[currNode.botRow, currNode.col].visit == false)
                    {
                        mazeMap[currNode.botRow, currNode.col].setVisit();
                        numNodes++;
                    }
                }
                //left node
                if (currNode.leftCol >= 0 && mazeMap[currNode.row, currNode.leftCol].path == false)
                {
                    currNumNodes++;
                    if (mazeMap[currNode.row, currNode.col].visit == false)
                    {
                        mazeMap[currNode.row, currNode.col].setVisit();
                        numNodes++;
                    }
                }

            }
        }
    }
    // Use this for initialization
    void Start () {
        
        //walls
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.localScale = new Vector3(3, 1, 2);
        //cube.transform.position = new Vector3(2, 1, 1); 


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
