using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void StartGame() 
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Credit()
    {
        SceneManager.LoadSceneAsync(6);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

