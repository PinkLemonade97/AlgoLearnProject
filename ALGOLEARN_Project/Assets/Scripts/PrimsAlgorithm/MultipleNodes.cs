using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleNodes : MonoBehaviour
{
    public List<GameObject> listOfEdgesInNode;
    public List<GameObject> listOfConfirmedEdges;
    public List<GameObject> listOfNodesInSingularity;
    public ButtonForAlgorithmsTest AlgoTest;

    public float lowestWeightEdge = 0;
    // Update is called once per frame
    void Update()
    {
        AddEdgesToTree();
        FindLowestWeightEdge();
        HighlightLowestEdge();
    }
    public void MergingNodes(GameObject ls)
    {
        listOfEdgesInNode.Add(ls);
    }
    public void AddingNodesToTree(GameObject tr)
    {
        listOfNodesInSingularity.Add(tr);
    }
    public bool CheckIfOtherNodeIsSelected(GameObject gom)
    {
        bool temp = false;
        bool temp2 = false;
            if (gom.GetComponent<EdgeScript>().connectedNodes[0].GetComponent<NodeScript>().isVisited == true)
            {
                temp = true;
            }
            if (gom.GetComponent<EdgeScript>().connectedNodes[1].GetComponent<NodeScript>().isVisited == true)
            {
                temp = true;
            }
            if(temp == true && temp2 == true)
            {
                return true;
            }
        return false;
    }
    public void AddEdgesToTree()
    {
        foreach (GameObject f in listOfNodesInSingularity)
        {
            foreach (GameObject ed in f.GetComponent<NodeScript>().listOfConnectedEdges)
            {
                if(CheckIfOtherNodeIsSelected(ed) == false)
                {
                    if (!listOfConfirmedEdges.Contains(ed))
                    {
                        if (!listOfEdgesInNode.Contains(ed))
                        {
                          //  Debug.Log("Program Run Order: 4 ");
                            listOfEdgesInNode.Add(ed);
                        }
                    }
                }
            }
        }
    }
    public void FindLowestWeightEdge()
    {
        foreach (GameObject f in listOfEdgesInNode)
        {
            if (f.GetComponent<EdgeScript>().edgeWeight < lowestWeightEdge && f.GetComponent<EdgeScript>().isLowestEdge == false)
            {
                lowestWeightEdge = f.GetComponent<EdgeScript>().edgeWeight;
            }
        }
        confirmedEdges();
    }
    public void confirmedEdges()
    {
        for (int i = 0; i < listOfEdgesInNode.Count; i++)
        {
            if (lowestWeightEdge == listOfEdgesInNode[i].gameObject.GetComponent<EdgeScript>().edgeWeight)
            {
                listOfEdgesInNode[i].gameObject.GetComponent<EdgeScript>().isLowestEdge = true;
               // Debug.Log("Program Run Order: 5 ");
            }
        }
    }
    void HighlightLowestEdge()
    {
        for (int i = 0; i < listOfEdgesInNode.Count; i++)
        {
            if (lowestWeightEdge == listOfEdgesInNode[i].gameObject.GetComponent<EdgeScript>().edgeWeight &&
                ((listOfEdgesInNode[i].gameObject.GetComponent<EdgeScript>().connectedNodes[0].GetComponent<NodeScript>().isVisited == false &&
                listOfEdgesInNode[i].gameObject.GetComponent<EdgeScript>().connectedNodes[1].GetComponent<NodeScript>().isVisited == false) || 

                (listOfEdgesInNode[i].gameObject.GetComponent<EdgeScript>().connectedNodes[0].GetComponent<NodeScript>().isVisited == true &&
                listOfEdgesInNode[i].gameObject.GetComponent<EdgeScript>().connectedNodes[1].GetComponent<NodeScript>().isVisited == false) ||

               (listOfEdgesInNode[i].gameObject.GetComponent<EdgeScript>().connectedNodes[0].GetComponent<NodeScript>().isVisited == false &&
                listOfEdgesInNode[i].gameObject.GetComponent<EdgeScript>().connectedNodes[1].GetComponent<NodeScript>().isVisited == true)))
            {
                listOfEdgesInNode[i].gameObject.GetComponent<EdgeScript>().SelectedEdge();

                if(!listOfConfirmedEdges.Contains(listOfEdgesInNode[i].gameObject))
                {
                    listOfConfirmedEdges.Add(listOfEdgesInNode[i].gameObject);
                    AlgoTest.AddAlgorithmSelectedEdge(listOfEdgesInNode[i].gameObject);
                   // Debug.Log("Program Run Order: 6 ");
                    
                }
            }
        }
    }
    public void resetEdgeWeight()
    {
        lowestWeightEdge = lowestWeightEdge + 1;
    }
    public void ClearListOfTempEdges()
    {
        listOfEdgesInNode.Clear();
    }
}
