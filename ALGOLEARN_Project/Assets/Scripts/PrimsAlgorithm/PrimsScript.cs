using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimsScript : MonoBehaviour
{
    public List<GameObject> edgeList;
    public List<GameObject> nodeList;
    public List<GameObject> VisitedList;
    public List<GameObject> ToBeVisitedList;
    public List<GameObject> VisitedEdgesList;
    public List<GameObject> MSTList;
    public MultipleNodes nodeMp;
    public List<float> numbersTaken;
    public bool onecB = false;
    int slow = 100;
    public bool tutorialSrcipt = false;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        FindAllNodes();
        FindAllEdges();
        AddNodesToBeVisitedList();
        SelectRootNode();
    }

    // Update is called once per frame
    void Update()
    {

        highlightSelectedEdge();
        if (slow <= 0 && tutorialSrcipt == false)
        {
            findOppositeNode();
            FindNextLowestEdge();
            nodeMp.ClearListOfTempEdges();
            nodeMp.resetEdgeWeight();
            slow = 100;
        }
        if (slow <= 0 && tutorialSrcipt == true)
        {
            findOppositeNode();
            FindNextLowestEdge();
            nodeMp.ClearListOfTempEdges();
            nodeMp.resetEdgeWeight();
            slow = 500;
        }
        slow--;
    }
    public void ChangeToTutorialMode()
    {
        tutorialSrcipt = true;
    }

    void FindAllNodes()
    {
        foreach(GameObject nodeObj in GameObject.FindGameObjectsWithTag("Node"))
        {
            nodeList.Add(nodeObj);
        }
    }
    void FindAllEdges()
    {

        foreach (GameObject edgeObj in GameObject.FindGameObjectsWithTag("Edge"))
        {
            edgeList.Add(edgeObj);
        }
    }
    void AddNodesToBeVisitedList()
    {
        foreach (GameObject nodeObj in nodeList)
        {
            if(!ToBeVisitedList.Contains(nodeObj))
            {
                ToBeVisitedList.Add(nodeObj);
               // Debug.Log("Name of node going in : " + nodeObj.name);
            }
        }
    }
    void AddNodesVisitedList(GameObject gameOb)
    {
            if (!VisitedList.Contains(gameOb))
            {
                VisitedList.Add(gameOb);
                gameOb.GetComponent<NodeScript>().isVisited = true;
               // Debug.Log("Name of node going in : " + gameOb.name);
            }
    }
    void RemoveNodesFromToBeVisitedList(GameObject gameOb)
    {
            if(ToBeVisitedList.Contains(gameOb))
            {
                ToBeVisitedList.Remove(gameOb);
             //  Debug.Log("Name of node going in : " + gameOb.name);
            }      
    }
    void SelectRootNode()
    {
        nodeList[0].gameObject.GetComponent<NodeScript>().rootNode = true;
    }
    void highlightSelectedEdge()
    {
 
        if(!VisitedList.Contains(nodeList[0].gameObject))
        {
            VisitedList.Add(nodeList[0].gameObject);
            nodeList[0].GetComponent<NodeScript>().isVisited = true;
           /// Debug.Log("Name of node going in : " + VisitedList[0].name);
        }
        if (ToBeVisitedList.Contains(nodeList[0].gameObject))
        {
            ToBeVisitedList.Remove(nodeList[0].gameObject);
            nodeList[0].GetComponent<NodeScript>().isVisited = true;
           // Debug.Log("Name of node going out : " + ToBeVisitedList[0].name);
        }
    }
    void FindNextLowestEdge()
    {
        foreach(GameObject tt in VisitedList)
        {
            foreach (GameObject gg in tt.GetComponent<NodeScript>().listOfConnectedEdges)
            {
                if (!nodeMp.listOfNodesInSingularity.Contains(tt))
                {
                    nodeMp.AddingNodesToTree(tt);
                   // Debug.Log("Program Run Order: 1 ");
                }
            }       
        }
    }
    void findOppositeNode()
    {
        foreach (GameObject tt in nodeMp.listOfEdgesInNode)
        {
            foreach(GameObject gg in tt.GetComponent<EdgeScript>().connectedNodes)
            {
                if(!gg.GetComponent<NodeScript>().isVisited && tt.GetComponent<EdgeScript>().isLowestEdge)
                {
                  //  Debug.Log("Program Run Order: 2 ");
                    gg.GetComponent<NodeScript>().nodeHasBeenReached();
                    AddNodesVisitedList(gg);
                    RemoveNodesFromToBeVisitedList(tt);
                }
            }
        }
       // nodeMp.ClearListOfTempEdges();
       // nodeMp.resetEdgeWeight();
    }
}
