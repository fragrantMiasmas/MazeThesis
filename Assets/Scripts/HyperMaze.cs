using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperMaze : MonoBehaviour
{
    public HMazeGen hm; //make hypermaze
    public int gridsize;
    float wallThick = 1; //0.75f
    float wallHeight = 1;


    // Use this for initialization
    void Start()
    {
        hm = (HMazeGen)gameObject.GetComponent(typeof(HMazeGen));
        int gridsize = hm.ArraySize;
        Node[, ,] mazeArray = hm.nodeGrid; //get the 2d array of nodes from mazegen

        //maze walls
        int centerVal = (gridsize - 1) / 2;
        for (int i = 0; i < gridsize; i++)
        {
            for (int j = 0; j < gridsize; j++)
            {
                for(int k = 0; k <gridsize; k++) { 
                    if (!mazeArray[i, j, k].path) //if wall exists
                    {
                        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        wall.transform.position = new Vector3(i - centerVal, k, j - centerVal);
                        wall.transform.localScale = new Vector3(wallThick, wallHeight, wallThick);

                    }
                } 
            }
        }

        
        //// top and bottom walls: needs to be transpaprent
        //for (int i = 0; i < gridsize + 2; i++)
        //{
        //    if (i - 1 != g2.startRow)
        //    {
        //        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //        wall.transform.position = new Vector3(i - 1 - centerVal, height, -centerVal - 1);
        //        wall.transform.localScale = new Vector3(wallThick, wallHeight, wallThick);

        //        wall.transform.position = new Vector3(i - 1 - centerVal, height, centerVal + 1);
        //        wall.transform.localScale = new Vector3(wallThick, wallHeight, wallThick);

        //    }
        //}

        //// left and right walls
        //for (int i = 0; i < gridsize; i++)
        //{
        //    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    wall.transform.position = new Vector3(-centerVal - 1, height, i - centerVal);
        //    wall.transform.localScale = new Vector3(wallThick, wallHeight, wallThick);


        //    wall.transform.position = new Vector3(centerVal + 1, height, i - centerVal);
        //    wall.transform.localScale = new Vector3(wallThick, wallHeight, wallThick);

        //}

        
    }

    // Update is called once per frame
    void Update()
    {


    }
}
