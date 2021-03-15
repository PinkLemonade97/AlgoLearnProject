using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell 
{
    public bool VisitedCell = false;
    // Game objects for to structure maze
    //public GameObject cellStructure;
    public GameObject upWall;
    public GameObject downWall;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject floor;
}
