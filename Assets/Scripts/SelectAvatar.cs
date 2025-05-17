using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectAvatar : MonoBehaviour
{
    public void Select()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void BacktoMain()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
