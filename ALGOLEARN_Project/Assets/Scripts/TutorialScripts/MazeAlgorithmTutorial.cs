using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeAlgorithmTutorial : MonoBehaviour
{
    public MazeTutorialScripts maze;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // the algorithm its self
    public void Algorithm()
    {
        Debug.Log(" the out of bound numbers" + maze.mazeGrid[maze.currentRow, maze.currentCol]);
        // set the current cell as visited
        maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell = true;

        //pick a random direction to go 
        int direction = Random.Range(0, 4);

        if (Input.GetKeyDown(KeyCode.UpArrow) || (maze.solveForPlayer == true && direction == 0))
        //if (direction == 0) // if random generator picks 0 go up
        {
            if (maze.currentRow > 0 && !maze.mazeGrid[maze.currentRow - 1, maze.currentCol].VisitedCell && maze.boundries() != 5) // if the current row is greater then 0 and the cell above is not visited and it its not the top row 
            {
                if (maze.mazeGrid[maze.currentRow, maze.currentCol].upWall) // if the current cell has a top wall destory it 
                {
                    Destroy(maze.mazeGrid[maze.currentRow, maze.currentCol].upWall);
                }
                // insert the current row and column values into a stack for backtracking
                maze.trackX.Push(maze.currentRow);
                maze.trackY.Push(maze.currentCol);
                maze.noVisitedCells++; // add this cell to the total number of cells 

                maze.currentRow--; // go to the cell above

                //set the current cell to visited
                maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell = true;

                // if the current cell has a bottom wall destroy it 
                if (maze.mazeGrid[maze.currentRow, maze.currentCol].downWall)
                {
                    Destroy(maze.mazeGrid[maze.currentRow, maze.currentCol].downWall);
                }
            }
        }//down
        //else if (direction == 1)
        if (Input.GetKeyDown(KeyCode.DownArrow) || (maze.solveForPlayer == true && direction == 1))
        {
            //  Debug.Log(" going down from: " + currentRow + " " + currentCol);
            if (maze.currentRow < maze.Rows - 1 && !maze.mazeGrid[maze.currentRow + 1, maze.currentCol].VisitedCell && maze.boundries() != 6)// if the current row is less then row max value and the cell below is not visited and it its not the bottom row 
            {
                if (maze.mazeGrid[maze.currentRow, maze.currentCol].downWall)// if the current cell has a bottom wall destroy it 
                {
                    Destroy(maze.mazeGrid[maze.currentRow, maze.currentCol].downWall);
                }
                // insert the current row and column values into a stack for backtracking
                maze.trackX.Push(maze.currentRow);
                maze.trackY.Push(maze.currentCol);
                maze.noVisitedCells++;// add this cell to the total number of cells 

                maze.currentRow++; // go to the cell below

                //set the current cell to visited
                maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell = true;

                // if the current cell has a top wall destroy it
                if (maze.mazeGrid[maze.currentRow, maze.currentCol].upWall)
                {
                    Destroy(maze.mazeGrid[maze.currentRow, maze.currentCol].upWall);
                }
            }
        }//left
         // else if (direction == 2)
        if (Input.GetKeyDown(KeyCode.LeftArrow) || (maze.solveForPlayer == true && direction == 2))
        {
            //  Debug.Log(" going left from :" + currentRow + " " + currentCol);
            if (maze.currentCol > 0 && !maze.mazeGrid[maze.currentRow, maze.currentCol - 1].VisitedCell && maze.boundries() != 7) // if the current column is greater then 0 value and the cell to the left is not visited and it its not the left side 
            {
                if (maze.mazeGrid[maze.currentRow, maze.currentCol].leftWall) // if the current cell has a left wall destroy it
                {
                    Destroy(maze.mazeGrid[maze.currentRow, maze.currentCol].leftWall);
                }
                // insert the current row and column values into a stack for backtracking
                maze.trackX.Push(maze.currentRow);
                maze.trackY.Push(maze.currentCol);
                maze.noVisitedCells++;// add this cell to the total number of cells 

                maze.currentCol--; // go to the cell on the left

                //set the current cell to visited
                maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell = true;

                // if the current cell has a right wall destroy it
                if (maze.mazeGrid[maze.currentRow, maze.currentCol].rightWall)
                {
                    Destroy(maze.mazeGrid[maze.currentRow, maze.currentCol].rightWall);
                }
            }
        }//right
        //else if (direction == 3)
        if (Input.GetKeyDown(KeyCode.RightArrow) || (maze.solveForPlayer == true && direction == 3))
        {
            //  Debug.Log(" going right from: " + currentRow + " " + currentCol);
            if (maze.currentCol < maze.Cols - 1 && !maze.mazeGrid[maze.currentRow, maze.currentCol + 1].VisitedCell && maze.boundries() != 8) // if the current column is less then most right col value and the cell to the right is not visited and it its not the right side 
            {
                if (maze.mazeGrid[maze.currentRow, maze.currentCol].rightWall)// if the current cell has a right wall destroy it
                {
                    Destroy(maze.mazeGrid[maze.currentRow, maze.currentCol].rightWall);
                }
                // insert the current row and column values into a stack for backtracking
                maze.trackX.Push(maze.currentRow);
                maze.trackY.Push(maze.currentCol);
                maze.noVisitedCells++;// add this cell to the total number of cells 

                maze.currentCol++;// go to the cell on the left

                //set the current cell to visited
                maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell = true;
                // if the current cell has a left wall destroy it
                if (maze.mazeGrid[maze.currentRow, maze.currentCol].leftWall)
                {
                    Destroy(maze.mazeGrid[maze.currentRow, maze.currentCol].leftWall);
                }
            }
        }
        maze.visitObjectCheck();
        // this function just runs boundry check 
        maze.boundries();
        // method that applies the recursive backtracking to the algorithm
        checkBack();
    }

    //method that checks if the current cell has visited cell next to it 
    public void checkBack()
    {
        if (maze.boundries() == 1) // if 1 gets returned from boundries method it means the algorithm is in the top left corner so no need to check for cells to the left or cells to above
        {   // this checks for visited cells to the right and bottom of the current cell 
            if ((maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell == true) &&
                (maze.mazeGrid[maze.currentRow + 1, maze.currentCol].VisitedCell == true && maze.mazeGrid[maze.currentRow, maze.currentCol + 1].VisitedCell == true) && maze.trackX.Count != 0)
            {
                maze.BacktrackingCell();
                maze.currentRow = maze.trackX.Pop(); // get the most recent values added to the stack 
                maze.currentCol = maze.trackY.Pop(); // get the most recent values added to the stack              
            }
        }
        if (maze.boundries() == 2)// if 2 gets returned from boundries method it means the algorithm is in the bottom left corner so no need to check for cells to the left or cells down
        {// this checks for visited cells to the right and up of the current cell 
            if ((maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell == true) &&
                (maze.mazeGrid[maze.currentRow - 1, maze.currentCol].VisitedCell == true && maze.mazeGrid[maze.currentRow, maze.currentCol + 1].VisitedCell == true) && maze.trackX.Count != 0)
            {
                maze.BacktrackingCell();
                maze.currentRow = maze.trackX.Pop(); // get the most recent values added to the stack 
                maze.currentCol = maze.trackY.Pop(); // get the most recent values added to the stack              
            }
        }

        if (maze.boundries() == 3)// if 3 gets returned from boundries method it means the algorithm is in the top righ corner so no need to check for cells to the right or cells above
        {// this checks for visited cells to the left and down of the current cell
            if ((maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell == true) &&
                (maze.mazeGrid[maze.currentRow + 1, maze.currentCol].VisitedCell == true && maze.mazeGrid[maze.currentRow, maze.currentCol - 1].VisitedCell == true) && maze.trackX.Count != 0)
            {
                maze.BacktrackingCell();
                maze.currentRow = maze.trackX.Pop(); // get the most recent values added to the stack 
                maze.currentCol = maze.trackY.Pop(); // get the most recent values added to the stack
            }
        }
        if (maze.boundries() == 4)// if 4 gets returned from boundries method it means the algorithm is in the botom righ corner so no need to check for cells to the right or cells down
        {// this checks for visited cells to the left and up of the current cell
            if ((maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell == true) &&
                (maze.mazeGrid[maze.currentRow - 1, maze.currentCol].VisitedCell == true && maze.mazeGrid[maze.currentRow, maze.currentCol - 1].VisitedCell == true) && maze.trackX.Count != 0)
            {
                maze.BacktrackingCell();
                maze.currentRow = maze.trackX.Pop(); // get the most recent values added to the stack 
                maze.currentCol = maze.trackY.Pop(); // get the most recent values added to the stack     
            }
        }
        //Row 0
        if (maze.boundries() == 5)// if 5 gets returned from boundries method it means the algorithm is in the top row and it will not check the cell above
        {
            if (maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell &&
                (maze.mazeGrid[maze.currentRow + 1, maze.currentCol].VisitedCell == true &&
                maze.mazeGrid[maze.currentRow, maze.currentCol + 1].VisitedCell == true && maze.mazeGrid[maze.currentRow, maze.currentCol - 1].VisitedCell == true) && maze.trackX.Count != 0)
            {
                maze.BacktrackingCell();
                maze.currentRow = maze.trackX.Pop(); // get the most recent values added to the stack 
                maze.currentCol = maze.trackY.Pop(); // get the most recent values added to the stack    
            }
        }
        //Rows - 1
        if (maze.boundries() == 6)// if 6 gets returned from boundries method it means the algorithm is in the bottom row and it will not check the cell below
        {
            if ((maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell == true) &&
                (maze.mazeGrid[maze.currentRow - 1, maze.currentCol].VisitedCell == true &&
                maze.mazeGrid[maze.currentRow, maze.currentCol + 1].VisitedCell == true && maze.mazeGrid[maze.currentRow, maze.currentCol - 1].VisitedCell == true) && maze.trackX.Count != 0)
            {
                maze.BacktrackingCell();
                maze.currentRow = maze.trackX.Pop(); // get the most recent values added to the stack 
                maze.currentCol = maze.trackY.Pop(); // get the most recent values added to the stack    
            }
        }
        //col 0
        if (maze.boundries() == 7)// if 6 gets returned from boundries method it means the algorithm is in the left most cell and it will not check the cell left
        {
            if ((maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell == true) &&
                (maze.mazeGrid[maze.currentRow + 1, maze.currentCol].VisitedCell == true &&
                maze.mazeGrid[maze.currentRow - 1, maze.currentCol].VisitedCell == true && maze.mazeGrid[maze.currentRow, maze.currentCol + 1].VisitedCell == true) && maze.trackX.Count != 0)
            {
                maze.BacktrackingCell();
                maze.currentRow = maze.trackX.Pop(); // get the most recent values added to the stack 
                maze.currentCol = maze.trackY.Pop(); // get the most recent values added to the stack      
            }
        }
        //cols - 1
        if (maze.boundries() == 8)// if 8 gets returned from boundries method it means the algorithm is in the right most cell and it will not check the cell right
        {
            if ((maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell == true) &&
                (maze.mazeGrid[maze.currentRow + 1, maze.currentCol].VisitedCell == true &&
                maze.mazeGrid[maze.currentRow - 1, maze.currentCol].VisitedCell == true && maze.mazeGrid[maze.currentRow, maze.currentCol - 1].VisitedCell == true) && maze.trackX.Count != 0)
            {
                maze.BacktrackingCell();
                maze.currentRow = maze.trackX.Pop(); // get the most recent values added to the stack 
                maze.currentCol = maze.trackY.Pop(); // get the most recent values added to the stack    
            }
        }
        if (maze.boundries() == 0)// if 0 gets returned from boundries method it means the algorithm is not near the boundries and will check for visited cells in every direction
        {
            if ((maze.mazeGrid[maze.currentRow, maze.currentCol].VisitedCell == true) && (maze.mazeGrid[maze.currentRow + 1, maze.currentCol].VisitedCell == true && maze.mazeGrid[maze.currentRow - 1, maze.currentCol].VisitedCell == true
                && maze.mazeGrid[maze.currentRow, maze.currentCol + 1].VisitedCell == true && maze.mazeGrid[maze.currentRow, maze.currentCol - 1].VisitedCell == true))// && trackX.Count != 0)
            {
                maze.BacktrackingCell();
                maze.currentRow = maze.trackX.Pop(); // get the most recent values added to the stack 
                maze.currentCol = maze.trackY.Pop(); // get the most recent values added to the stack    
            }
        }

    }
}

