using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameTest : MonoBehaviour
{
    public void BackToMap()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void GoEndingScene()
    {
        SceneManager.LoadSceneAsync(4);
    }
}
