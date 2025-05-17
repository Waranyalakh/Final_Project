using UnityEngine;

public class CalibrationManager : MonoBehaviour
{
    public GameObject[] characterPrefabs;  // Prefabs ของตัวละครทั้งหมด
    public Transform spawnPoint;           // ตำแหน่งที่ต้องการให้ตัวละครเกิด
    public LayerMask groundLayer;          // กำหนด LayerMask ของพื้นดิน (ตั้งค่าใน Inspector)

    void Start()
    {
        int selectedIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", -1);
        if (selectedIndex >= 0 && selectedIndex < characterPrefabs.Length)
        {
            // สร้างตัวละครจาก Prefab ตามตำแหน่ง spawnPoint
            Vector3 spawnPos = spawnPoint.position;
            Quaternion spawnRot = spawnPoint.rotation;
            GameObject currentCharacter = Instantiate(characterPrefabs[selectedIndex], spawnPos, spawnRot);


            // เพิ่ม Component "Avatar" เข้าไปในตัวละครที่สร้างขึ้นมา
            Avatar avatarScript = currentCharacter.AddComponent<Avatar>();

            // ตั้งค่า Preview Camera ให้เป็น Main Camera
            avatarScript.previewCamera = Camera.main;

            // ตั้งค่า Animator ให้เป็น Animator ที่อยู่ในตัวละคร (ถ้ามี)
            avatarScript.animator = currentCharacter.GetComponent<Animator>();

            // ตั้งค่า Ground Layer ที่ใช้สำหรับตรวจจับพื้น (เช่น สำหรับการเช็คตำแหน่งเท้า)
            avatarScript.ground = groundLayer;

            // ตั้งค่าให้ footTracking เปิดใช้งาน
            avatarScript.footTracking = true;

            // ตั้งค่า footGroundOffset เป็น 0.1f (สำหรับปรับตำแหน่งเท้าเล็กน้อย)
            avatarScript.footGroundOffset = 0.1f;

            // ตั้งค่า useCalibrationData เป็น false (ไม่ใช้ข้อมูล Calibration ที่บันทึกไว้)
            avatarScript.useCalibrationData = false;

            // หากต้องการตั้งค่า calibrationData ให้เพิ่มโค้ดในส่วนนี้ (ถ้ามี)
            // avatarScript.calibrationData = somePersistentCalibrationData;

            Debug.Log("Avatar script added and fields set automatically!");
        }
        else
        {
            Debug.LogWarning("No valid character selected!");
        }
    }
}
