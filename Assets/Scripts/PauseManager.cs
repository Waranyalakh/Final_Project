using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        ResetGameData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        ResetGameData(); // ถ้ามี method นี้อยู่แล้วในคลาสเดียวกัน
        SceneManager.LoadSceneAsync(0); // โหลด Scene Index 0 (Main Menu)
    }

    private void ResetGameData()
    {
        // รีเซ็ตข้อมูลเกม เช่น คะแนน ตัวแปรสถานะ ฯลฯ
        DataHandlerSingleton.Instance.score = 0;
        DataHandlerSingleton.Instance.victoryIndex = 0;
        
        // ตัวอย่าง:
        // ScoreManager.instance.Reset();
        // PlayerStats.Reset();
    }
}
