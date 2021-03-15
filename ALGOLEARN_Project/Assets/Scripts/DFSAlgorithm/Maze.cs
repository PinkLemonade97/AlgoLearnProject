using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * AUTHOR: SYLWESTER SZWED
 * FYP - ALGORITHM GAMIFICATION 
 * TITLE: MAZE GENERATOR Game(DEPTH SEARCH FIRST WITH RECURSIVE BACKTRACKING)
 * 
 */
public class Maze : MonoBehaviour
{
    //algorithm script reference
    public DFSAlgorithm algorithm;

    //variables for rows and columns 
    public int Rows = 6;
    public int Cols = 6;

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
    public CameraView cView;

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

    // input field that will take in the width value of the maze 
    public InputField widthField;
    // input field that will take in the height value of the maze 
    public InputField heightField;
    //text field that displays the percentage of maze completion
    public Text percentageText;

    public Text uniquenessPercentageText;

    public GameObject VisitedCellObject;
    public GameObject VisitedCellObject2;
    int i = 0;
    public bool solveForPlayer = false;
    //variable to store maze competion %
    int mazePercent;
    public Canvas GameCanvas;
    public Canvas endGameCanvas;
    public Canvas endGameCanvasFail;
    //helping keep track of players 
    public int checkQUp = 0;
    public int checkQDown = 0;
    public int checkQLeft = 0;
    public int checkQRight = 0;

    public float uniquenessPercentage = 100;
    public Stats statsScript;

    // Start is called before the first frame update
    void Start()
    {
        // initilasin the camera class
        cView = gameObject.AddComponent<CameraView>();
        //getting the total value of cell
        noTotalCells = Rows * Cols;
        // creating the objects in method
        ObjectCreation();
        // set new view depending on the size to the maze 
        cView.camView(Rows, Cols);

    }
    public void Update()
    {

        //if(i % 10 == 0)
        //{
        algorithm.Algorithm();
        solveForPlayerMethod();
        //}
        // run the algorithm one per frame to give it a cool effect

        // display the text and update it pre frame
        PercentText();
        StartNewRound();
        i++;

        uniquenessPercentageText.text = "Maze Uniqueness: " + uniquenessPercentage.ToString();
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

            uniquenessPercentage = 100;
            statsScript.starCheck = true;
            statsScript.StarsEarned = 0;
            statsScript.time = 0;
            statsScript.countTimeBool = true;
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

            uniquenessPercentage = 100;
            statsScript.starCheck = true;
            statsScript.StarsEarned = 0;
            statsScript.time = 0;
            statsScript.countTimeBool = true;

        }
    }
   

    // method to display the percentage of maze compleated
    void PercentText() 
    {
        // variable to store the  percentage
        mazePercent = (noVisitedCells * 100 / noTotalCells * 100) / 100;
        //  set the text in the canvas to the following
        percentageText.text = "Generating Maze: " + mazePercent + "%".ToString();
    }
    void StartNewRound()
    {
        if(mazePercent == 100 && uniquenessPercentage > 80)
        {
            ChangeCanvas();
        }
        else if (mazePercent == 100 && uniquenessPercentage < 80)
        {
            ChangeCanvasFail();
        }
    }
    public void RegenerateMazeByCompletion()
    {
        // calls the clean up function 
        mazeCleanUp(2);
        // set new view depending on the size to the maze 
        cView.camView(Rows, Cols);
    }
    // method to handle the button input 
    public void RegenerateMaze()
    {
        // calls the clean up function 
        mazeCleanUp(1);
        // set new view depending on the size to the maze 
        cView.camView(Rows, Cols);
    }
    public void visitObjectCheck()
    {
        if(mazeGrid[currentRow, currentCol].VisitedCell == true)
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
        if(Input.GetKeyDown(KeyCode.T))
        {
            solveForPlayer = true;
        }
    }
   public void CheckForUniqness(int numberQ)
   {
        if(numberQ == 1)
        {
            checkQUp++;
            checkQDown = 0;
            checkQLeft = 0;
            checkQRight = 0;
        }
        else if (numberQ == 2)
        {
            checkQUp = 0;
            checkQDown++;
            checkQLeft = 0;
            checkQRight = 0;
        }
        else if (numberQ == 3)
        {
            checkQUp = 0;
            checkQDown = 0;
            checkQLeft++;
            checkQRight = 0;
        }
        else if (numberQ == 4)
        {
            checkQUp = 0;
            checkQDown = 0;
            checkQLeft = 0;
            checkQRight++;
        }
        findUniquePercentage();
   }
   void findUniquePercentage()
   {
        if(checkQUp >= 4 || checkQDown >= 4 || checkQLeft >= 4 || checkQRight >=4)
        {
            uniquenessPercentage--;
        }
   }
   void ChangeCanvas()
   {
        statsScript.StopTime();
        statsScript.startCountForStars();
        endGameCanvas.gameObject.SetActive(true);
        GameCanvas.gameObject.SetActive(false);   
   }
    void ChangeCanvasFail()
    {
        statsScript.StopTime();
        statsScript.startCountForStars();
        endGameCanvasFail.gameObject.SetActive(true);
        GameCanvas.gameObject.SetActive(false);
    }
}
