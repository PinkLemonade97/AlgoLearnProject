using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickScript : MonoBehaviour
{
    
    public LayerMask LMask;
    string DifferentSceneName1 = "InsertionAlgorithmEasy";
    string DifferentSceneName2 = "PrimsAlgorithm";
    // Update is called once per frame
    void Update()
    {
        Scene sceneName = SceneManager.GetActiveScene();
        if (sceneName.name == DifferentSceneName1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit rH;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rH, Mathf.Infinity, LMask))
                {
                    rH.collider.GetComponent<MouseClicked>().OnMouseClick();
                }
            }
        }

        if (sceneName.name == DifferentSceneName2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit rH;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rH, Mathf.Infinity, LMask))
                {
                    rH.collider.GetComponent<MouseClickedPrims>().OnMouseClick();
                }
            }
        }
    }
}
