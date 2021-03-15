using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScript : MonoBehaviour
{
    public float time = 0;
    public bool countTimeBool = true;
    public bool starCheck = true;
    public float StarsEarned = 0;
    public float falseSwitchNumber;
    public GameManager gmScript;

    public Text textTime;
    public Text textStarsEarned;
    public Text textfalseSwitchNumber;
    public Text TitleText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeKeeper();
        textfalseSwitchNumber.text = falseSwitchNumber.ToString();
        textStarsEarned.text = StarsEarned.ToString();
    }
    void TimeKeeper()
    {
        if (countTimeBool)
        {
            time += Time.deltaTime;
        }
        textTime.text = time.ToString() + " seconds";
    }
    public void StopTime()
    {
        countTimeBool = false;
    }
    public void CalculateStars()
    {
        if (starCheck)
        {
            if (falseSwitchNumber < 1)
            {
                StarsEarned++;
            }
            if (falseSwitchNumber < 3)
            {
                StarsEarned++;
            }
            if (falseSwitchNumber < 5 )
            {
                StarsEarned++;
            }
            starCheck = false;
        }
        CheckIfPlayerPassed();
        gmScript.AddToTotalStars(StarsEarned);
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
    void CheckIfPlayerPassed()
    {
        if(StarsEarned < 1)
        {
            TitleText.text = "You Failed!";
        }
    }
}
