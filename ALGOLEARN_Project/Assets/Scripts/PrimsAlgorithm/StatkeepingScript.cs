using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatkeepingScript : MonoBehaviour
{
    public float time;
    public bool countTimeBool = true;
    public float correctEdges = 0;
    public float incorrectEdges = 0;
    public float StarsEarned = 0;
    public float orderCounter = 0;
    public bool counterStoper = true;
    public Text textTime;
    public Text textCorrectEdge;
    public Text textIncorrectEdge;
    public Text textStarsEarned;
    public Text textorderCounter;


    public ButtonForAlgorithmsTest objectTesting;
    public GameManager gmScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeKeeper();
        checkCorrectEdges();
        checkIncorrectEdges();
        textStarsEarned.text = StarsEarned.ToString();
        textorderCounter.text = orderCounter.ToString();
    }
    void TimeKeeper()
    {
        if (countTimeBool)
        {
            time += Time.deltaTime;
        }
        textTime.text = time.ToString();
    }
    public void StopTime()
    {
        countTimeBool = false;
    }
    void checkCorrectEdges()
    {
        correctEdges = objectTesting.comparable.Count;
        textCorrectEdge.text = correctEdges.ToString();
    }
    void checkIncorrectEdges()
    {
        incorrectEdges = 9 - objectTesting.comparable.Count;
        textIncorrectEdge.text = incorrectEdges.ToString();
    }
    public void CalculateStars()
    {
        if (time < 30)
        {
            StarsEarned++;
        }
        if (time < 20)
        {
            StarsEarned++;
        }
        if (time < 15)
        {
            StarsEarned++;
        }
        if (incorrectEdges == 0)
        {
            StarsEarned++;
        }
        if (orderCounter == 9)
        {
            StarsEarned++;
        }
        gmScript.AddToTotalStars(StarsEarned);
    }
    public void CompereLists()
    {
        if(counterStoper == true)
        {
            for (int i = 0; i < objectTesting.listOfAlgorithmSelectedEdges.Count; i++)
            {
                if (objectTesting.listOfPlayerSelectedEdges[i] == objectTesting.listOfAlgorithmSelectedEdges[i])
                {
                    orderCounter++;
                }
            }
            counterStoper = false;
        }
        StartCoroutine(starCountDown());        
    }
    IEnumerator starCountDown()
    {
        yield return new WaitForSeconds(0.5f);
        CalculateStars();
    }
}
