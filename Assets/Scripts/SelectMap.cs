using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectMapscene : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void BacktoAvatar()
    {
        SceneManager.LoadSceneAsync(1);
    }
}