using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button[] characterButtons;  // ปุ่มเลือกตัวละคร

    void Start()
    {
        // เชื่อมโยงปุ่มให้กับฟังก์ชันเลือกตัวละคร
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int index = i + 1; // ตัวเลขตัวละคร (เริ่มต้นจาก 1)
            characterButtons[i].onClick.AddListener(() => SelectCharacter(index));
        }
    }

    // ฟังก์ชันที่ใช้ในการเลือกตัวละคร
    public void SelectCharacter(int characterNumber)
    {
        // บันทึกตัวละครที่เลือกใน DataHandlerSingleton
        DataHandlerSingleton.Instance.selectedCharacter = characterNumber;

        // ไม่ต้องแสดงข้อความอะไรใน Console
    }
}