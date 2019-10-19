using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject QuitButton;

    public void OnRestartClick()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitClick()
    {
        Application.Quit();
    }
}
