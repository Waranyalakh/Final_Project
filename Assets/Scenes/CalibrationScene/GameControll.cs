using UnityEngine;

public class GameControll : MonoBehaviour
{
    public GameObject[] stageObjects;      
    public GameObject[] stageBackgrounds;  

    void Start()
    {
        
        int selectedStage = DataHandlerSingleton.Instance.selectedStage;
        ShowStage(selectedStage);
    }

    private void ShowStage(int stageIndex)
    {
        foreach (var stageObject in stageObjects)
        {
            stageObject.SetActive(false);
        }

        foreach (var background in stageBackgrounds)
        {
            background.SetActive(false);
        }

        if (stageIndex == 0)
        {
            stageIndex = 1;  
        }

        if (stageIndex > 0 && stageIndex <= stageObjects.Length)
        {
            stageObjects[stageIndex - 1].SetActive(true); 
            stageBackgrounds[stageIndex - 1].SetActive(true);  
        }
    }
}
