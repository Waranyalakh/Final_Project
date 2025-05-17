using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    public void BackToMenu()
    {
        ResetGameData();
        SceneManager.LoadSceneAsync(0);
    }
    public void Restart()
    {
        ResetGameData();

        SceneManager.LoadSceneAsync(1);  
    }

    private void ResetGameData()
    {
        DataHandlerSingleton.Instance.score = 0;
        DataHandlerSingleton.Instance.victoryIndex = 0;
        DataHandlerSingleton.Instance.selectedCharacter = 0;
        DataHandlerSingleton.Instance.selectedStage = 0;

    }
  
}