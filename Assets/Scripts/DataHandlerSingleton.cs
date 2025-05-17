using UnityEngine;

public class DataHandlerSingleton : MonoBehaviour
{
    public static DataHandlerSingleton Instance;

    [SerializeField] public int selectedCharacter;
    [SerializeField] public int selectedStage;
    [SerializeField] public int score;
    [SerializeField] public int victoryIndex = 0; 

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            ResetScore(); 
        }
        else
        {
            Debug.LogWarning("Duplicate DataHandlerSingleton Instance destroyed.");
            Destroy(gameObject);
        }
    }

    public void ResetScore()
    {
        selectedCharacter = 0;
        selectedStage = 1; 
        score = 0;
        victoryIndex = 0; 
    }
}