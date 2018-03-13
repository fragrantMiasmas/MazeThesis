using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMaze : MonoBehaviour
{
    public Grid3 g3;
    public int gridsize;
    float height = 1;
    float wallThick = 1; //0.75f
    float wallHeight = 2;

    //// draw floor
    //transform.position = new Vector3(0, 1 / 10, 0);
    //transform.localScale = new Vector3(gridsize + 1, height, gridsize + 1);
    ////Cube cube = new Cube();
    //Instantiate(cube, transform.position, transform.rotation);

    // Use this for initialization
    void Start()
    {
        g3 = (Grid3)gameObject.GetComponent(typeof(Grid3));
        int gridsize = g3.ArraySize;
        Cell[,] mazeArray = g3.CellArray; //get the 2d array of nodes from mazegen

        //maze walls
        int centerVal = (gridsize - 1) / 2;
        for (int i = 0; i < gridsize; i++)
        {
            for (int j = 0; j < gridsize; j++)
            {
                if (!mazeArray[i, j].path) //if wall exists
                {
                    GameObject mazeWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    mazeWall.transform.position = new Vector3(i - centerVal, height, j - centerVal);
                    mazeWall.transform.localScale = new Vector3(wallThick, wallHeight, wallThick);

                }
            }
        }


        // top and bottom walls: borders
        for (int i = 0; i < gridsize + 2; i++)
        {
            if (i - 1 != g3.startRow)
            {
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.transform.position = new Vector3(i - 1 - centerVal, height, -centerVal - 1);
                wall.transform.localScale = new Vector3(wallThick, wallHeight, wallThick);

                GameObject wall2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall2.transform.position = new Vector3(i - 1 - centerVal, height, centerVal + 1);
                wall2.transform.localScale = new Vector3(wallThick, wallHeight, wallThick);

            }
        }

        // left and right walls
        for (int i = 0; i < gridsize; i++)
        {
            GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall.transform.position = new Vector3(-centerVal - 1, height, i - centerVal);
            wall.transform.localScale = new Vector3(wallThick, wallHeight, wallThick);

            GameObject wall2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            wall2.transform.position = new Vector3(centerVal + 1, height, i - centerVal);
            wall2.transform.localScale = new Vector3(wallThick, wallHeight, wallThick);

        }
        //ground
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ground.transform.localScale = new Vector3(gridsize + 1, (float)0.2, gridsize + 1);

    }

    // Update is called once per frame
    void Update()
    {


    }
}
