using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickedPrims : MonoBehaviour
{
    public Material highlitedMaterial;
    public Material normalMaterial;   
    public bool objectSelected = false;
    public ButtonForAlgorithmsTest playerTest;
   
    public void OnMouseClick()
    {
        if (objectSelected == false)
        {
            gameObject.GetComponent<MeshRenderer>().material = highlitedMaterial;
            Vector3 scaleobj = gameObject.transform.localScale;
            scaleobj.x = 1.0f;
            scaleobj.z = 1.0f;
            gameObject.transform.localScale = scaleobj;
            objectSelected = true;
            playerTest.AddPlayerSelectedEdge(gameObject);


        }
        else if(objectSelected)
        {
            Vector3 scaleobj = gameObject.transform.localScale;
            scaleobj.x = 0.8f;
            scaleobj.z = 0.8f;
            gameObject.transform.localScale = scaleobj;
            gameObject.GetComponent<MeshRenderer>().material = normalMaterial;
            objectSelected = false;
            playerTest.RemovePlayerSelectedEdge(gameObject);
        }
    }
}
