using UnityEngine;
using System.Collections;

public class WallMovement : MonoBehaviour
{
    public GameObject[] wallPrefabs;       // กำแพงหลายแบบ (Prefab)
    public Transform spawnPoint;           // จุดกำเนิดกำแพง
    public float moveDistance = 15f;       // ระยะทางที่กำแพงต้องเคลื่อนที่
    public float initialSpeed = 1f;        // ความเร็วเริ่มต้น
    public float speedIncrement = 0.5f;      // ค่าที่เพิ่มความเร็วในแต่ละครั้ง
    public float delayBeforeMove = 10f;    // ดีเลย์ก่อนเคลื่อนที่
    public KeyCode triggerKey = KeyCode.C; // ปุ่มเริ่ม

    public GameObject startingWallPrefab;  // Prefab ของกำแพงเริ่มต้น
    private GameObject startingWallInstance; // Instance ของกำแพงเริ่มต้น

    private bool isSpawning = false;
    private float currentSpeed;            // ความเร็วปัจจุบันของกำแพง

    void Update()
    {
        if (Input.GetKeyDown(triggerKey) && !isSpawning)
        {
            StartCoroutine(SpawnWallsSequentially());
        }
    }

    IEnumerator SpawnWallsSequentially()
    {
        isSpawning = true;

        // ขั้นตอนที่ 1: แสดงกำแพงเริ่มต้น
        if (startingWallPrefab != null)
        {
            startingWallInstance = Instantiate(startingWallPrefab, spawnPoint.position, spawnPoint.rotation);
        }

        // รอเป็นเวลา delayBeforeMove วินาที
        yield return new WaitForSeconds(delayBeforeMove);

        // ขั้นตอนที่ 2: ซ่อนกำแพงเริ่มต้น
        if (startingWallInstance != null)
        {
            Destroy(startingWallInstance); // ทำลายกำแพงเริ่มต้น
        }

        // ขั้นตอนที่ 3: เริ่มกระบวนการสร้างและเคลื่อนที่กำแพงปกติ
        currentSpeed = initialSpeed; // เริ่มต้นความเร็วด้วยค่าเริ่มต้น

        // ดึงข้อมูล selectedStage จาก DataHandlerSingleton
        int selectedStage = DataHandlerSingleton.Instance.selectedStage;

        // กรอง wallPrefabs ตาม stage
        int startRange = 0, endRange = 0;

        switch (selectedStage)
        {
            case 1:
                startRange = 0;
                endRange = 14;
                break;
            case 2:
                startRange = 15;
                endRange = 29;
                break;
            case 3:
                startRange = 30;
                endRange = 44;
                break;
            default:
                Debug.LogWarning("Invalid selectedStage value!");
                break;
        }

        // สร้างกำแพงตาม range ที่กำหนด
        for (int i = startRange; i <= endRange && i < wallPrefabs.Length; i++)
        {
            GameObject wall = Instantiate(wallPrefabs[i], spawnPoint.position, spawnPoint.rotation);

            // ส่งกำแพงไปเคลื่อนที่และรอจนกว่าจะถูกทำลาย
            yield return StartCoroutine(MoveAndDestroy(wall, currentSpeed));

            // เพิ่มความเร็วสำหรับกำแพงตัวถัดไป
            currentSpeed += speedIncrement;

            // Debug Log เพื่อแสดงความเร็วของกำแพงแต่ละตัว
            Debug.Log($"Wall {i + 1}: Speed = {currentSpeed}");
        }

        isSpawning = false;
    }

    IEnumerator MoveAndDestroy(GameObject wall, float speed)
    {
        float movedDistance = 0f;

        while (movedDistance < moveDistance)
        {
            float moveStep = speed * Time.deltaTime;
            wall.transform.Translate(Vector3.forward * moveStep);
            movedDistance += moveStep;
            yield return null;
        }

        Destroy(wall); // ลบกำแพงเมื่อเคลื่อนที่ครบ
    }
}