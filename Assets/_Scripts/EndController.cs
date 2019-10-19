using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject QuitButton;
    public Text HScore;


    void Start()
    {
        HScore.text = "High Score: " + PlayerPrefs.GetInt("Score").ToString();   
    }
    public void OnRestartClick()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitClick()
    {
        Application.Quit();
    }
}
