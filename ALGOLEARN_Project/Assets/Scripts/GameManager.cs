using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float TotalStars;
    public float totalNumberStars;
    public Text totalNumberStarsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalNumberStarsText.text = "Total Points: " + TotalStars;
    }
    public void AddToTotalStars(float tt)
    {
        TotalStars = TotalStars + tt;
    }

}
