using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject startButton;
    public GameObject quitButton;

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
