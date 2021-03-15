using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicked : MonoBehaviour
{
    Vector3 BringObjectForward = new Vector3();
    public GameObject gameObj;
    bool selectingDisabled = false;

    private List<GameObject> spawnList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
        CheckForHitglitedObjects();
    }
    public void OnMouseClick()
    {
        if (gameObj.transform.position.z == 10f && selectingDisabled == false)
        {
            BringObjectForward = gameObj.transform.position;
            BringObjectForward.z = 8.5f;
            gameObj.transform.position = BringObjectForward; 
            gameObj.tag = "ObjectSelected";
            gameObj.GetComponent<ObjectScript>().CurrentObjectSelected = true;
        }
        else if(gameObj.transform.position.z == 8.5f)
        {
            BringObjectForward = gameObj.transform.position;
            BringObjectForward.z = 10f;
            gameObj.transform.position = BringObjectForward;
            gameObj.tag = "Object";
            gameObj.GetComponent<ObjectScript>().CurrentObjectSelected = false;

        }
    }
    void CheckForHitglitedObjects()
    {
       if(GameObject.FindGameObjectsWithTag("ObjectSelected").Length == 2)
       {
            selectingDisabled = true;
       }
       else
       {
            selectingDisabled = false;
       }
    }
}
