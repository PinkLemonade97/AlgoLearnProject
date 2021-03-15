using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public List<GameObject> listOfConnectedEdges;
    public bool isVisited = false;
    public bool rootNode = false;
    public bool currentNode = false;
    public float lowestWeightEdge = 25;
    public Material selectedMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //edgesTest();
        HighlightLowestEdge();

    }
    private void OnTriggerEnter(Collider other)
    {
        listOfConnectedEdges.Add(other.gameObject);
    }
    void HighlightLowestEdge()
    {
        for(int i = 0; i < listOfConnectedEdges.Count ;i++)
        {
            if(lowestWeightEdge == listOfConnectedEdges[i].gameObject.GetComponent<EdgeScript>().edgeWeight)
            {
                listOfConnectedEdges[i].gameObject.GetComponent<EdgeScript>().SelectedEdge();
            }
        }
    }
    public void FindLowestWeighEdge()
    {
        foreach (GameObject f in listOfConnectedEdges)
        {
            if (f.GetComponent<EdgeScript>().edgeWeight < lowestWeightEdge && f.GetComponent<EdgeScript>().isLowestEdge == false)
            {
                lowestWeightEdge = f.GetComponent<EdgeScript>().edgeWeight;
            }
        }
        AssignEdgeAsLowest();
    }
    public void AssignEdgeAsLowest()
    {
        for (int i = 0; i < listOfConnectedEdges.Count; i++)
        {
            if (lowestWeightEdge == listOfConnectedEdges[i].gameObject.GetComponent<EdgeScript>().edgeWeight)
            {
                listOfConnectedEdges[i].gameObject.GetComponent<EdgeScript>().isLowestEdge = true;
            }
        }
    }
    public GameObject RetriveSmallestEdgeThatIsConnectedToNode()
    {
        GameObject tempObject = new GameObject();
        for (int i = 0; i < listOfConnectedEdges.Count; i++)
        {
            if (lowestWeightEdge == listOfConnectedEdges[i].gameObject.GetComponent<EdgeScript>().edgeWeight)
            {
                 tempObject =  listOfConnectedEdges[i].gameObject;
            }
        }
        return tempObject;
    }
    public void nodeHasBeenReached()
    {
        gameObject.GetComponent<MeshRenderer>().material = selectedMaterial;
        Vector3 scaleobj = gameObject.transform.localScale;
        gameObject.transform.localScale = scaleobj;
    }
}
