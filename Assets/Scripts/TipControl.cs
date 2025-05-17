using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    // Reference ของ Canvas และ Buttons
    public GameObject tip1Canvas; // Canvas สำหรับ Tip1
    public GameObject tip2Canvas; // Canvas สำหรับ Tip2
    public Button nextButton;     // ปุ่ม Next
    public Button skipButton;     // ปุ่ม Skip
    public Button backButton;     // ปุ่ม Back
    public Button doneButton;     // ปุ่ม Done

    private bool isOnTip2 = false; // เช็คว่าตอนนี้อยู่ที่ Tip2 หรือไม่

    void Start()
    {
        // ตั้งค่าเริ่มต้น
        tip1Canvas.SetActive(true); // เริ่มต้นที่ Tip1
        tip2Canvas.SetActive(false); // ซ่อน Tip2
        backButton.gameObject.SetActive(false); // ซ่อนปุ่ม Back
        doneButton.gameObject.SetActive(false); // ซ่อนปุ่ม Done

        // กำหนดฟังก์ชันให้ปุ่ม
        nextButton.onClick.AddListener(OnNextClicked);
        skipButton.onClick.AddListener(OnSkipClicked);
        backButton.onClick.AddListener(OnBackClicked);
        doneButton.onClick.AddListener(OnDoneClicked);
    }

    // กดปุ่ม Next
    public void OnNextClicked()
    {
        if (!isOnTip2)
        {
            // เปลี่ยนจาก Tip1 เป็น Tip2
            tip1Canvas.SetActive(false);
            tip2Canvas.SetActive(true);

            // แสดงปุ่ม Back และ Done, ซ่อนปุ่ม Next
            backButton.gameObject.SetActive(true);
            doneButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);

            // เปลี่ยนชื่อปุ่ม Next เป็น Done

            isOnTip2 = true; // อัปเดตสถานะ
        }
    }

    // กดปุ่ม Skip
    public void OnSkipClicked()
    {
        // ไป Scene ถัดไปทันที
        SceneManager.LoadSceneAsync(4);
    }

    // กดปุ่ม Back
    public void OnBackClicked()
    {
        if (isOnTip2)
        {
            // เปลี่ยนจาก Tip2 กลับไป Tip1
            tip2Canvas.SetActive(false);
            tip1Canvas.SetActive(true);

            // ซ่อนปุ่ม Back และ Done, แสดงปุ่ม Next
            backButton.gameObject.SetActive(false);
            doneButton.gameObject.SetActive(false);
            nextButton.gameObject.SetActive(true);


            isOnTip2 = false; // อัปเดตสถานะ
        }
    }

    // กดปุ่ม Done
    public void OnDoneClicked()
    {
        // ไป Scene ถัดไป
        SceneManager.LoadSceneAsync(4);
    }
}