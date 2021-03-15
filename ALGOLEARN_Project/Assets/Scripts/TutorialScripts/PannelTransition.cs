using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelTransition : MonoBehaviour
{
    Vector3 scaleVector;
    private bool pannel = false;
    // Start is called before the first frame update
    void Start()
    {
        scaleVector.x = 0;
        scaleVector.y = 0;
        scaleVector.z = 1;
        pannel = true;
    }

    // Update is called once per frame
    void Update()
    {
            ScaleUp();   
    }

    void ScaleUp()
    {
        if (gameObject.transform.localScale.x <= 1 && gameObject.transform.localScale.y <= 1)
        {
            scaleVector.x += 0.03f;
            scaleVector.y += 0.03f;           
        }
        gameObject.transform.localScale = scaleVector;
    }
   
}
