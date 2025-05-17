using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public Text countdownText;  // UI Text สำหรับแสดงเวลา
    public float startDelay = 10f;         // เวลาที่รอก่อนเริ่มนับถอยหลัง (10 วินาที)
    public float countdownTime = 3f;       // เวลาถอยหลัง (ตอนนี้เป็น public)
    public float postCountdownDelay = 2f;  // เวลาที่รอหลังจากนับถอยหลังเสร็จ (ปรับได้ใน Inspector)
    public string nextSceneName = "Ending_Scene";  // ชื่อ Scene ที่จะเปลี่ยนไป

    private bool isCountdownStarted = false; // ตัวแปรเพื่อป้องกันการเริ่มนับซ้ำ

    void Update()
    {
        // ตรวจสอบว่าผู้เล่นกดปุ่ม C และยังไม่ได้เริ่มนับถอยหลัง
        if (Input.GetKeyDown(KeyCode.C) && !isCountdownStarted)
        {
            isCountdownStarted = true; // ตั้งค่าว่าเริ่มนับแล้ว
            countdownText.gameObject.SetActive(false); // ซ่อนก่อนเริ่มนับเวลา
            StartCoroutine(StartCountdown()); // เริ่มนับเวลาหลังจากผ่านไปตาม startDelay
        }
    }

    IEnumerator StartCountdown()
    {
        // รอเวลา startDelay ก่อนเริ่มการนับถอยหลัง (10 วินาที)
        yield return new WaitForSeconds(startDelay);

        countdownText.gameObject.SetActive(true); // แสดง countdownText หลังจากหน่วงเวลา startDelay

        while (countdownTime > 0)
        {
            countdownText.text = "TIME " + countdownTime.ToString("F0"); // อัปเดต UI

            // เล่นเสียง Tick เมื่อเวลาเหลือ 3 วินาทีหรือน้อยกว่า
            if (countdownTime <= 10 && AudioManager.instance != null)
            {
                AudioManager.instance.PlayTickSound();
            }

            yield return new WaitForSeconds(1f); // รอ 1 วินาที
            countdownTime--; // ลดเวลาลง 1 วิ
        }

        countdownText.text = "Time's up!"; // แสดงข้อความเมื่อหมดเวลา

        // รอเวลาหน่วงหลังจากหมดเวลา (ก่อนเปลี่ยนซีน)
        yield return new WaitForSeconds(postCountdownDelay);

        // เปลี่ยน Scene หลังจากเวลาหน่วง
        SceneManager.LoadScene(nextSceneName); // โหลดซีนที่กำหนดไว้ใน nextSceneName
    }
}