using UnityEngine;
using UnityEngine.UI;

public class StageSelection : MonoBehaviour
{
    public Button[] stageButtons;        
    public Image selectedStageImage;     
    public Sprite[] stageSprites;       
    public Button selectButton;         

    void Start()
    {
        if (selectButton != null)
        {
            selectButton.gameObject.SetActive(false);
        }

        for (int i = 0; i < stageButtons.Length; i++)
        {
            int index = i; 
            stageButtons[i].onClick.AddListener(() => SelectStage(index));
        }
    }

    public void SelectStage(int stageIndex)
    {
        Debug.Log("Select state " + stageIndex);
        DataHandlerSingleton.Instance.selectedStage = stageIndex + 1; 

        selectedStageImage.sprite = stageSprites[stageIndex];  
        selectedStageImage.gameObject.SetActive(true);         

        if (selectButton != null)
        {
            selectButton.gameObject.SetActive(true);
        }

    }
}