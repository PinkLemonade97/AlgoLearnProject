using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
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
        genterateRandomNumber();
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Object script: " + gameObject.name);
        ObjectIsMostLeft();
    }
    void genterateRandomNumber()
    {
        tempNumber = Random.Range(0, 20);

            if(sp.numbersTaken.Contains(tempNumber))
            {
                Vector3 tempVec = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                tempVec.x = tempNumber - 10;
                gameObject.transform.position = tempVec;
                sp.numbersTaken.Remove(tempNumber);
            }
            else
            {
                genterateRandomNumber();
            }

    }
    void ObjectIsMostLeft()
    {
        if(CurrentObjectIsMostLeft)
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
