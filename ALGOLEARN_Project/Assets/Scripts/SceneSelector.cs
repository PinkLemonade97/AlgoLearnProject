using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PrimsRestartGame()
    {
        SceneManager.LoadScene("PrimsAlgorithm");
    }
    public void PrimsPlayGame()
    {
        SceneManager.LoadScene("PrimsAlgorithm");
    }
    public void DFSRestartGame()
    {
        SceneManager.LoadScene("DepthSearchFirstAlgorithm");
    }
    public void InsertionRestartGame()
    {
        SceneManager.LoadScene("InsertionAlgorithmEasy");
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void PrimsTutorial()
    {
        SceneManager.LoadScene("PrimsAlgorithmTutorial");
    }
    public void DFSTutorial()
    {
        SceneManager.LoadScene("DepthSearchFirstTutorial");
    }
}
