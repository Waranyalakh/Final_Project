using UnityEngine;
using UnityEngine.UI;

public class DisplayEnd : MonoBehaviour
{
    public Image victoryImage;  // UI Image ที่จะใช้แสดงรูปภาพ

    void Start()
    {
        // ดึงค่าจาก DataHandlerSingleton
        int selectedCharacter = DataHandlerSingleton.Instance.selectedCharacter;
        int selectedStage = DataHandlerSingleton.Instance.selectedStage;
        int victoryIndex = DataHandlerSingleton.Instance.victoryIndex;

        // สร้างชื่อไฟล์จากค่าที่ได้
        string characterCode = selectedCharacter.ToString("00");  // ทำให้เป็นรูปแบบ 2 หลัก เช่น 01, 02, 03, 04
        string mapCode = "Map" + selectedStage.ToString();  // สร้างชื่อ Map เช่น Map1, Map2, Map3
        string victory = GetVictoryString(victoryIndex);

        // สร้างชื่อไฟล์ เช่น "01_map1_fail"
        string imageName = $"{characterCode}_{mapCode}_{victory}";

        // โหลด Sprite จาก Resources โดยใช้ชื่อที่สร้างขึ้น
        Sprite victorySprite = Resources.Load<Sprite>("Images/" + imageName);

        // ตรวจสอบว่ารูปภาพโหลดสำเร็จหรือไม่
        if (victorySprite != null)
        {
            // ถ้ารูปภาพโหลดสำเร็จ, แสดงใน UI
            victoryImage.sprite = victorySprite;
        }
        else
        {
            Debug.LogError("ไม่พบรูปภาพ: " + imageName);
        }

        // เล่นเสียงตาม Rank โดยใช้ AudioManager
        PlaySoundBasedOnRank(victoryIndex);
    }

    // ฟังก์ชันเพื่อแปลง victoryIndex เป็นข้อความ
    private string GetVictoryString(int index)
    {
        switch (index)
        {
            case 0:
                return "fail";
            case 1:
                return "beginner";
            case 2:
                return "intermediate";
            case 3:
                return "advanced";
            case 4:
                return "expert";
            case 5:
                return "master";
            default:
                return "unknown";  // กรณีที่ไม่ได้ระบุค่า
        }
    }

    // ฟังก์ชันสำหรับเล่นเสียงตาม Rank
    private void PlaySoundBasedOnRank(int victoryIndex)
    {
        // ตรวจสอบว่า AudioManager มี Instance หรือไม่
        if (AudioManager.instance == null)
        {
            Debug.LogError("AudioManager instance is missing!");
            return;
        }

        // ตรวจสอบ Rank และเล่นเสียงตามเงื่อนไข
        switch (victoryIndex)
        {
            case 0: // Fail
                AudioManager.instance.PlayFailSound(); // เสียง Aww
                break;
            case 5: // Master
                AudioManager.instance.PlayMasterSound(); // เสียง Master
                break;
            default: // Rank อื่น ๆ (Beginner, Intermediate, Advanced, Expert)
                AudioManager.instance.PlayRankSound(); // เสียง Allrank
                break;
        }
    }
}