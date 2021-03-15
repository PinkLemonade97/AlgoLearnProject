using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public float time = 0;
    public bool countTimeBool = true;
    public bool starCheck = true;
    public float StarsEarned = 0;
    public float uniquenessNumber;
    public Maze maseScript;

    public Text textTime;
    public Text textTimeFail;
    public Text textStarsEarned;
    public Text textuniquenessNumber;
    public Text textuniquenessNumberFail;
    // Start is called before the first frame update
    public GameManager gmScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uniquenessNumber = maseScript.uniquenessPercentage;
        TimeKeeper();
        textStarsEarned.text = StarsEarned.ToString();
        textuniquenessNumber.text = uniquenessNumber.ToString();
        textuniquenessNumberFail.text = uniquenessNumber.ToString();
    }
    void TimeKeeper()
    {
        if (countTimeBool)
        {
            time += Time.deltaTime;
        }
        textTime.text = time.ToString();
        textTimeFail.text = time.ToString();

    }
    public void StopTime()
    {
        countTimeBool = false;
    }
    public void CalculateStars()
    {
        if (starCheck)
        {
            if (uniquenessNumber > 95)
            {
                StarsEarned++;
            }
            if (uniquenessNumber > 90)
            {
                StarsEarned++;
            }
            if (uniquenessNumber > 85)
            {
                StarsEarned++;
            }
            starCheck = false;
            gmScript.AddToTotalStars(StarsEarned);
        }
    }
    public void startCountForStars()
    {
        StartCoroutine(starCountDown());
    }

    IEnumerator starCountDown()
    {
        yield return new WaitForSeconds(0.5f);
        CalculateStars();
    }
}
