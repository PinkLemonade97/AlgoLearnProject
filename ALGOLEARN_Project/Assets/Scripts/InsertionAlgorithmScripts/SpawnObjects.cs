using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    ObjectScript ObjScript;
    public StatsScript statScr;
    GameObject temp;
    GameObject temp2;
    GameObject temp3;
    public Canvas endGameCanvasPass;
    public Canvas endGameCanvasFail;
    public Canvas normalCanvas;
    public List<GameObject> spawnList = new List<GameObject>();
    public List<GameObject> objectList;
    public List<float> numbersTaken = new List<float>() {2, 4, 6, 8, 10, 12, 14, 16, 18};
    public Material mat;
    public Material mat_1;
    public Material mat_2;
    Vector3 positionVec = new Vector3(-12, 1, 10);
    Vector3 ScaleVec = new Vector3(1, 1, 1);
    Vector3 playPos;
    int GNumber = 0;
    int[] number;
    bool FirstMove = true;
    bool correctOrder = false;
    public int switchAttempt = 0;

    // Start is called before the first frame update
    void Start()
    {
        number = new int[spawnList.Count];
    }
    void Update()
    {
        WorkingAlgo();
        RunInsertionAlgorithm();
        FindLeftMostObject();

        if (FirstMove)
        {
            FirstTry();
        }

        SelectObjects();

        if (correctOrder == false)
        {
            temp.gameObject.GetComponent<MeshRenderer>().material = mat_1;
        }

        CheckIfObjectIsInCorrectPosition();
        SelectCanvas();
    }
    void WorkingAlgo()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            number[i] = (int)spawnList[i].gameObject.transform.localScale.y;
           // Debug.Log("Got to here my g " + number[i]);
        }
    }
    void RunInsertionAlgorithm()
    {
        for (int i = 0; i < spawnList.Count - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (spawnList[j - 1].gameObject.transform.localScale.y > spawnList[j].gameObject.transform.localScale.y)
                {
                    GameObject temp = spawnList[j - 1];
                    spawnList[j - 1] = spawnList[j];
                    spawnList[j] = temp;
                    GNumber++;
                }               
            }        
        }
    }
    void FindLeftMostObject()
    {
        int[] XpositionArray = new int[spawnList.Count];
        for (int i = 0; i < spawnList.Count; i++)
        {
            XpositionArray[i] = (int)spawnList[i].gameObject.transform.position.x;
        }
        int min = XpositionArray.Min();

        for (int i = 0; i < spawnList.Count; i++)
        {
            if(spawnList[i].gameObject.transform.position.x == min)
            {
                spawnList[i].gameObject.GetComponent<ObjectScript>().CurrentObjectIsMostLeft = true;
            }
            else
            {
                spawnList[i].gameObject.GetComponent<ObjectScript>().CurrentObjectIsMostLeft = false;
            }
        }
    }
    void FirstTry()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            if (spawnList[i].gameObject.GetComponent<ObjectScript>().CurrentObjectIsMostLeft == true)
            {
                temp = spawnList[i];
                FirstMove = false;
            }
        }
    }
    void SelectObjects()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            if (spawnList[i].gameObject.GetComponent<ObjectScript>().CurrentObjectSelected == true && 
                spawnList[i].gameObject.GetComponent<ObjectScript>().CurrentObjectIsMostLeft != true &&
                (((int)temp.gameObject.transform.position.x + 2 == (int)spawnList[i].transform.position.x)))
            {
                temp2 = spawnList[i];
                temp2.gameObject.GetComponent<MeshRenderer>().material = mat_2;
            }
        }
    }
    public void switchObjects()
    {
        if (temp.gameObject.GetComponent<ObjectScript>().CurrentObjectSelected == true && temp2.gameObject.GetComponent<ObjectScript>().CurrentObjectSelected == true)
        {
            if (GameObject.FindGameObjectsWithTag("ObjectSelected").Length == 2)
            {
                if (temp.transform.position.y > temp2.transform.position.y)
                {
                    Vector3 vecTe = temp.transform.position;
                    Vector3 vecTe2 = temp2.transform.position;
                    Vector3 vecTe3 = temp.transform.position;

                    vecTe.x = vecTe2.x;
                    vecTe2.x = vecTe3.x;

                    temp.transform.position = vecTe;
                    temp2.transform.position = vecTe2;
                    ChangeTempObjectOrder();
                }
                else if(temp.transform.position.y < temp2.transform.position.y)
                {
                    switchAttempt++;
                    ObjectToBeSortedNext();
                }
            }          
        }
    }
    public void ObjectToBeSortedNext()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            if (((int)temp2.gameObject.transform.position.x == (int)spawnList[i].transform.position.x))
            {
                temp = temp2;
                temp2 = spawnList[i];           
            }
        }
    }
    public void SwapTheSelectedObjects()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            if (((int)temp2.gameObject.transform.position.x - 2 == (int)spawnList[i].transform.position.x))
            {
                temp2.gameObject.GetComponent<MeshRenderer>().material = mat;
                temp2 = spawnList[i];
                ObjectToBeSortedNext();
            }
        }    
    }
    void ChangeTempObjectOrder()
    {
            temp3 = temp;
            temp = temp2;
            temp2 = temp3;
    }
    public void solveForPlayer()
    {
        for (int i = 0; i < spawnList.Count; i++)
        {
            Vector3 tempVec = spawnList[i].gameObject.transform.position;
            tempVec.x = (number[i] * 2) - 10;
            spawnList[i].gameObject.transform.position = tempVec;
        }
    }
    public void CheckIfObjectIsInCorrectPosition()
    {
        int allObjectsCorrect = 0;

        for (int i = 0; i < spawnList.Count; i++)
        {
            if (spawnList[i].gameObject.transform.position.x == (number[i] * 2) - 10)
            {               
                allObjectsCorrect++;
            }
        }

        if(allObjectsCorrect == spawnList.Count)
        {
            for (int i = 0; i < spawnList.Count; i++)
            {
                spawnList[i].gameObject.GetComponent<MeshRenderer>().material = mat;
                Vector3 tempVec = spawnList[i].gameObject.transform.position;
                tempVec.z = 10f;
                spawnList[i].gameObject.transform.position = tempVec;
            }                
            correctOrder = true;
        }
    }  
    void SelectCanvas()
    {
        if(correctOrder == true)
        {
            statScr.falseSwitchNumber = switchAttempt;
            statScr.StopTime();
            statScr.startCountForStars();
            endGameCanvasPass.gameObject.SetActive(true);
            normalCanvas.gameObject.SetActive(false);
        }
    }
}