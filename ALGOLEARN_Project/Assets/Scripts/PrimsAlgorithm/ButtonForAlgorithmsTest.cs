using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForAlgorithmsTest : MonoBehaviour
{
    public List<GameObject> listOfPlayerSelectedEdges;
    public List<GameObject> listOfAlgorithmSelectedEdges;
    public List<GameObject> comparable;
    public Material correctMaterial;
    public Material incorrectMaterial;
    public int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
      //  Debug.Log("Number of Correct Edges: " + counter);
    }

    public void AddPlayerSelectedEdge(GameObject gm)
    {
        if(!listOfPlayerSelectedEdges.Contains(gm))
        {
            listOfPlayerSelectedEdges.Add(gm);
        }
    }
    public void RemovePlayerSelectedEdge(GameObject gm)
    {
        if (listOfPlayerSelectedEdges.Contains(gm))
        {
            listOfPlayerSelectedEdges.Remove(gm);
        }
    }
    public void AddAlgorithmSelectedEdge(GameObject gm)
    {
        if (!listOfAlgorithmSelectedEdges.Contains(gm))
        {
            listOfAlgorithmSelectedEdges.Add(gm);
        }
    }
    public void ComparePaths()
    {
        foreach(GameObject gg in listOfPlayerSelectedEdges)
        {
            if (listOfAlgorithmSelectedEdges.Contains(gg))
            {
                gg.GetComponent<MeshRenderer>().material = correctMaterial;
;
                if (!comparable.Contains(gg))
                {
                    comparable.Add(gg);
                }
            } 
            else
            {
                gg.GetComponent<MeshRenderer>().material = incorrectMaterial;
            }
        }
    }
    public void compareLists(List<GameObject> list, GameObject obj)
    {
        if(list.Contains(obj))
        {
            if (!comparable.Contains(obj))
            {
                comparable.Add(obj);
            }
        }
    }

}
