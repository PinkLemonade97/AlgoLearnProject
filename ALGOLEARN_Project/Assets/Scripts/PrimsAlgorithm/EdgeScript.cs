using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeScript : MonoBehaviour
{
    public Material selectedMaterial;
    public float edgeWeight;
    public float tempNumberWeight;
    public TextMesh edge1; 
    public bool isLowestEdge = false;
    public bool isAlreadySelected = false;
    public List<GameObject> connectedNodes;
    public PrimsScript ps;
    // Start is called before the first frame update
    void Start()
    {
        genterateRandomNumber();
        edge1.text = edgeWeight.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void genterateRandomNumber()
    {
        tempNumberWeight = Random.Range(1, 20);
        if (!ps.numbersTaken.Contains(tempNumberWeight))
        {
            edgeWeight = tempNumberWeight;
            ps.numbersTaken.Add(edgeWeight);
        }
        if(edgeWeight == 0)
        {
            genterateRandomNumber();
        }
    }
    public void SelectedEdge()
    {
        gameObject.GetComponent<MeshRenderer>().material = selectedMaterial;
        Vector3 scaleobj = gameObject.transform.localScale;
        scaleobj.x = 1.0f;
        scaleobj.z = 1.0f;
        gameObject.transform.localScale = scaleobj;
      //  objectSelected = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Node"))
        {
            connectedNodes.Add(other.gameObject);
        }      
    }
}
