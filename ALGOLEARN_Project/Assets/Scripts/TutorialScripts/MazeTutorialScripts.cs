using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MazeTutorialScripts : MonoBehaviour
{
    //algorithm script reference
    public MazeAlgorithmTutorial algorithm;

    //variables for rows and columns 
    public int Rows = 10;
    public int Cols = 10;

    // variables for Rows and Colums after regeneration the maze
    public int RowsAfterGen;
    public int ColsAfterGen;

    // Game object for wall and floor
    public GameObject Wall;
    public GameObject Floor;
    public GameObject CellStructure;

    // 2D Array to hold MazeCell Class
    public MazeCell[,] mazeGrid;
    // class that changes the camera view

    // Variables for current row 
    public int currentRow = 0;
    // Variables for current Column
    public int currentCol = 0;

    // variable for number of visited cells 
    public int noVisitedCells = 1;
    //variable for number of total cells in the maze
    public int noTotalCells;

    // stack that will hold the x value of the cell
    public Stack<int> trackX = new Stack<int>();
    // stack that will hold the y value of the cell 
    public Stack<int> trackY = new Stack<int>();

    public GameObject VisitedCellObject;
    public GameObject VisitedCellObject2;
    int i = 0;
    public bool solveForPlayer = false;
    //variable to store maze competion %


    // Start is called before the first frame update
    void Start()
    {
        //getting the total value of cell
        noTotalCells = Rows * Cols;
        // creating the objects in method
        ObjectCreation();
    }
    public void Update()
    {
        solveForPlayerMethod();
        if (i % 50 == 0)
        {
            algorithm.Algorithm();
            
        }
        // run the algorithm one per frame to give it a cool effect
        i++;
    }
    //creating walls and floors for the maze 
    public void ObjectCreation()
    {
        // getting the size of the Wall
        float size = Wall.transform.localScale.x;

        //instantiating  mazeGrid class
        mazeGrid = new MazeCell[Rows, Cols];
        // for loop to place floor and walls for the lenght of rows
        for (int i = 0; i < Rows; i++)
        {
            // for loop to place floor and walls for the lenght of collums
            for (int j = 0; j < Cols; j++)
            {
                // creating game object "FLOOR" using the values gotten from the for loop 
                GameObject floor = Instantiate(Floor, new Vector3(j * size, 0, -i * size), Quaternion.identity);
                floor.name = "Floor_" + i + "_" + j; // assigning names to the object so it is easy to find 

                // GameObject CellStruct = Instantiate(CellStructure, new Vector3(j * size, 5.5f, -i * size), Quaternion.identity);
                // CellStruct.name = "CellStructure_" + i + "_" + j; // assigning names to the object so it is easy to find 

                // creating game object "Wall" using the values gotten from the for loop
                GameObject upwall = Instantiate(Wall, new Vector3(j * size, 5.5f, -i * size + 4.5f), Quaternion.identity);
                upwall.name = "wallUP_" + i + "_" + j;// assigning names to the object so it is easy to find 

                // creating game object "Wall" using the values gotten from the for loop
                GameObject downwall = Instantiate(Wall, new Vector3(j * size, 5.5f, -i * size - 4.5f), Quaternion.identity);
                downwall.name = "wallDown_" + i + "_" + j;// assigning names to the object so it is easy to find 

                // creating game object "Wall" using the values gotten from the for loop
                GameObject leftwall = Instantiate(Wall, new Vector3(j * size - 4.5f, 5.5f, -i * size), Quaternion.Euler(0, 90, 0));
                leftwall.name = "leftWall_" + i + "_" + j;// assigning names to the object so it is easy to find 

                // creating game object "Wall" using the values gotten from the for loop
                GameObject rightwall = Instantiate(Wall, new Vector3(j * size + 4.5f, 5.5f, -i * size), Quaternion.Euler(0, 90, 0));
                rightwall.name = "rightWall_" + i + "_" + j;// assigning names to the object so it is easy to find 

                //create new instatnce to store a cell at each coordinate of i,j
                mazeGrid[i, j] = new MazeCell();

                //assign game objects created above to the cell variables at each coordinate
                mazeGrid[i, j].upWall = upwall; // 
                mazeGrid[i, j].downWall = downwall;
                mazeGrid[i, j].leftWall = leftwall;
                mazeGrid[i, j].rightWall = rightwall;
                mazeGrid[i, j].floor = floor;
                //   mazeGrid[i, j].floor = CellStruct;

                // transform each object to parent so it is in the maze object in unity
                floor.transform.parent = transform;
                upwall.transform.parent = transform;
                downwall.transform.parent = transform;
                leftwall.transform.parent = transform;
                rightwall.transform.parent = transform;
                floor.transform.parent = transform;
                //   CellStruct.transform.parent = transform;
            }
        }
    }
    // class that when called resets the maze and creates a new one
    public void mazeCleanUp(int number)
    {
        if (number == 1)
        {
            // for each loop to destroy all game obejct in transform
            foreach (Transform transform in transform)
            {
                Destroy(transform.gameObject);
            }
            // get the new total cell value
            noTotalCells = Rows * Cols;
            // create new objects 
            ObjectCreation();

            // set the first cell as visited
            noVisitedCells = 1;
            // set the current row and colum to 0
            currentRow = 0;
            currentCol = 0;
            solveForPlayer = false;
        }
        else if (number == 2)
        {
            // for each loop to destroy all game obejct in transform
            foreach (Transform transform in transform)
            {
                Destroy(transform.gameObject);
            }

            Cols = Cols + 1;
            Rows = Rows + 1;

            // get the new total cell value
            noTotalCells = Rows * Cols;
            // create new objects 
            ObjectCreation();

            // set the first cell as visited
            noVisitedCells = 1;
            // set the current row and colum to 0
            currentRow = 0;
            currentCol = 0;
            solveForPlayer = false;
        }
    }
    //this method checks if the current Row and Column are near a boundry so we dont get a out of bounds error and crash the algorithm
    public int boundries()
    {
        // the first 4 if statements check if the current row and column are in any 4 corners of the maze
        if (currentRow == 0 && currentCol == 0) // check if current row and column are at 0 which is top left
        {
            return 1;
        }
        if (currentRow == Rows - 1 && currentCol == 0) // check if current row and column is bottom letf
        {
            return 2;
        }
        if (currentRow == 0 && currentCol == Cols - 1) // check if current row and column is top right
        {
            return 3;
        }
        if (currentRow == Rows - 1 && currentCol == Cols - 1) // check if current row and column is bottom right
        {
            return 4;
        }
        // the next 4 check if the current row is at the boundries of the maze
        if (currentRow == 0) // check if the current row is the top row
        {
            return 5;
        }
        if (currentRow == Rows - 1) // check if the current row is the bottom row
        {
            return 6;
        }
        if (currentCol == 0) // check if the current col is the left size
        {
            return 7;
        }
        if (currentCol == Cols - 1) // check if the current column is the right size
        {
            return 8;
        }
        return 0;
    }
    public void RegenerateMazeByCompletion()
    {
        // calls the clean up function 
        mazeCleanUp(2);
        // set new view depending on the size to the maze 
    }
    // method to handle the button input 
    public void RegenerateMaze()
    {
        // calls the clean up function 
        mazeCleanUp(1);
        // set new view depending on the size to the maze 
    }
    public void visitObjectCheck()
    {
        if (mazeGrid[currentRow, currentCol].VisitedCell == true)
        {
            GameObject visitObj = Instantiate(VisitedCellObject, new Vector3(mazeGrid[currentRow, currentCol].floor.transform.position.x, 2, mazeGrid[currentRow, currentCol].floor.transform.position.z), Quaternion.identity);
            // transform each object to parent so it is in the maze object in unity
            visitObj.transform.parent = transform;
        }
    }
    public void BacktrackingCell()
    {
        GameObject visitObj = Instantiate(VisitedCellObject2, new Vector3(mazeGrid[currentRow, currentCol].floor.transform.position.x, 3, mazeGrid[currentRow, currentCol].floor.transform.position.z), Quaternion.identity);
        visitObj.transform.parent = transform;
    }
    public void solveForPlayerMethod()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            solveForPlayer = true;
        }
    }
    public void solveTutorial()
    {
        solveForPlayer = true;       
    }
}
