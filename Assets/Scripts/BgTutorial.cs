using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgTutorial : MonoBehaviour
{
    public GameObject[] stageBackgrounds;

    void Start()
    {

        int selectedStage = DataHandlerSingleton.Instance.selectedStage;
        ShowStage(selectedStage);
    }

    private void ShowStage(int stageIndex)
    {
        foreach (var background in stageBackgrounds)
        {
            background.SetActive(false);
        }

        if (stageIndex == 0)
        {
            stageIndex = 1;
        }

        if (stageIndex > 0 && stageIndex <= stageBackgrounds.Length)
        {
            stageBackgrounds[stageIndex - 1].SetActive(true);
        }
    }
}
