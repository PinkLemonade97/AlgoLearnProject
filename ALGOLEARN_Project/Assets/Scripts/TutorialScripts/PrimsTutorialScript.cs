using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimsTutorialScript : MonoBehaviour
{
    public float TimerPara1 = 0;
    public float HeightPara1 = 0;
    public float TimerPara2 = 0;
    public float HeightPara2 = 0;
    public bool Para1Bool;
    public bool Para2Bool;
    public Text Para1;
    public Text Para2;
    private void Awake()
    {
        ChangeBool1();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Para1Bool)
        RunScript1();
        if(Para2Bool)
        RunScript2();
    }
    public void RunScript1()
    {
        if (TimerPara1 % 10 == 0)
        {
            HeightPara1++;
        }
        if (HeightPara1 <= 400)
        {
            Para1.rectTransform.sizeDelta = new Vector2(500, HeightPara1);
        }
        else if (HeightPara1 > 400)
        {
            Para1.rectTransform.sizeDelta = new Vector2(500, 400);
            HeightPara1 = 400;
        }
        TimerPara1++;
    }
    public void RunScript2()
    {
        if (TimerPara2 % 10 == 0)
        {
            HeightPara2++;
        }
        if (HeightPara2 <= 400)
        {
            Para2.rectTransform.sizeDelta = new Vector2(500, HeightPara2);
        }
        else if (HeightPara2 > 400)
        {
            Para2.rectTransform.sizeDelta = new Vector2(500, 400);
            HeightPara2 = 400;
        }
        TimerPara2++;
    }
    public void ChangeBool1()
    {
        Para1Bool = true;
        Para2Bool = false;
    }
    public void ChangeBool2()
    {
        Para1Bool = false;
        Para2Bool = true;
    }
}
