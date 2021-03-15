using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertionTutorialScriptObjects : MonoBehaviour
{
    public bool CurrentObjectSelected = false;
    public bool CurrentObjectIsMostLeft = false;
    public bool ObjectIsSelected_1 = false;
    public bool ObjectIsSorted = false;
    public bool ToBeSortedNext = false;

    public Material sortedMaterial;
    public Material unsortedMaterial;

    public SpawnObjects sp;
    public float tempNumber;
    public float XNumber;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Object script: " + gameObject.name);
        ObjectIsMostLeft();
    }
    void ObjectIsMostLeft()
    {
        if (CurrentObjectIsMostLeft)
        {
            gameObject.GetComponent<MeshRenderer>().material = sortedMaterial;
            ObjectIsSorted = true;
            CurrentObjectIsMostLeft = true;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = unsortedMaterial;
            CurrentObjectIsMostLeft = false;
        }
    }
}
