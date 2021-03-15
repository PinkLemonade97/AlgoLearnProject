using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    // camera variable for main camera
    public Camera cameraMain;

    // vector 3 to store the position of the camera
    public Vector3 maincamView;

     public void camView(int a, int b)
    {
        //initialising
        maincamView = new Vector3();

        // the maze is bigger then 10 cells use those camara settings (Width over Height)
        if ( b >= a && b >= 10)
        {
            maincamView.x = 40;
            maincamView.y = b * 10;
            maincamView.z = -(maincamView.y / 2) + 5;
        }
        // the maze is smaller then 10 cells use those camara settings (Width over Height)
        if (b >= a && b <= 10)
        {
            maincamView.x = 20;
            maincamView.y = b * 10 + 10;
            maincamView.z = -(maincamView.y / 2) + 10;
        }
        if (b >= a && b >= 30)
        {
            maincamView.x = 100;
            maincamView.y = b * 10;
            maincamView.z = -(maincamView.y / 2) + 5;
        }
        // the maze is bigger then 10 cells use those camara settings (Width over Height)
        if (b >= a && b >= 50)
        {
            maincamView.x = 100;
            maincamView.y = b * 10;
            maincamView.z = -(maincamView.y / 2) + 5;
        }
        // the maze is bigger then 10 cells use those camara settings (Height over Width)
        if (b < a && b >=10)
        {      
            maincamView.y = a * 10;    
            maincamView.z = -(maincamView.y / 2) + 10;
            maincamView.x = 10;
        }
        // the maze is smaller then 10 cells use those camara settings (Height over Width)
        if (b < a && b <= 10)
        {
            maincamView.y = a * 10 + 10;
            maincamView.x = 0;
            maincamView.z = -(maincamView.y / 2) + 10;
        }
        // get the reference for the main camera 
        cameraMain = Camera.main;
        // set the main camera with the vector3 values
        cameraMain.transform.position = maincamView;
    }
}
