using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // variable for rigidbody of the player
    public Rigidbody rigBody;
    // variable for vector3 position 
    public Vector3 plrPosition;

    public  void setPosition()
    {
        // initilize the vector3 to hold the values for the player position
        plrPosition = new Vector3(0, 8, 0);
        //set the position of the player in the maze
        rigBody.transform.position = plrPosition;
    }
    // Update is called once per frame
    void Update()
    {
        // get the keyboard input and move the player in the direction (UP)
        if (Input.GetKey("a"))
        {
            rigBody.AddForce(-2000 * Time.deltaTime, 0, 0);
        }
        // get the keyboard input and move the player in the direction (RIGHT)
        if (Input.GetKey("d"))
        {
            rigBody.AddForce(2000 * Time.deltaTime, 0, 0);
        }
        // get the keyboard input and move the player in the direction (DOWN)
        if (Input.GetKey("s"))
        {
            rigBody.AddForce(0, 0,- 2000 * Time.deltaTime);
        }
        // get the keyboard input and move the player in the direction (LEFT)
        if (Input.GetKey("w"))
        {
            rigBody.AddForce(0, 0, 2000 * Time.deltaTime);
        }
    }
}
