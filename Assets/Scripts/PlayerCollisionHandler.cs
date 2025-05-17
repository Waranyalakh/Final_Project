using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; // ใช้เพื่ออ้างอิง Text UI

public class PlayerCollisionHandler : MonoBehaviour
{
    //public Text scoreText; // อ้างอิงไปยัง UI Text ที่จะแสดงคะแนน


    [ContextMenu("Add Component")]
    private void SetComponent()
    {
        // ดึงเฉพาะ playerTag
        HashSet<string> playerTags = new HashSet<string>();
        foreach (var pair in validCollisions)
        {
            playerTags.Add(pair.playerTag);
        }

        // วนลูปทุก Child ของ GameObject นี้ (รวมตัวเองด้วย)
        foreach (Transform child in GetComponentsInChildren<Transform>(true))
        {
            if (playerTags.Contains(child.tag))
            {
                if (child.GetComponent<PlayerCollisionHandler>() == null)
                {
                    child.gameObject.AddComponent<PlayerCollisionHandler>();
                    Debug.Log($"➕ เพิ่ม BoxCollider ให้ {child.name}");
                }
            }
        }
    }
    // List ของ Tuple สำหรับกำหนดคู่ของ Tag ที่จะเพิ่มคะแนน
    private List<(string playerTag, string wallTag)> validCollisions = new List<(string, string)>()
    {
        ("Head", "Head"),
        ("Hip", "Hip"),
        ("Hand_L", "Hand_L"),
        ("Hand_R", "Hand_R"),
        ("UpperArm_L", "UpperArm_L"),
        ("UpperArm_R", "UpperArm_R"),
        ("LowerArm_L", "LowerArm_L"),
        ("LowerArm_R", "LowerArm_R"),
        ("UpperLeg_L", "UpperLeg_L"),
        ("UpperLeg_R", "UpperLeg_R"),
        ("LowerLeg_L", "LowerLeg_L"),
        ("LowerLeg_R", "LowerLeg_R")
    };

    // เมื่อชนกับ Collider ใดๆ
    private void OnTriggerEnter(Collider collision)
    {
        // ตรวจสอบว่า Tag ของ Collider ที่ชนกันตรงกับคู่ที่กำหนดหรือไม่
        foreach (var pair in validCollisions)
        {
            if (this.gameObject.CompareTag(pair.playerTag) && collision.gameObject.CompareTag(pair.wallTag))
            {

                Collider col = collision.gameObject.GetComponent<Collider>();
                if (col != null)
                {
                    Destroy(col); // ลบเฉพาะ Collider ออก
                }

                // เล่นเสียงเมื่อชนกำแพง
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.PlayCollisionSound();  // เรียกใช้ฟังก์ชันเล่นเสียงจาก AudioManager
                }

                // Debug Log เพื่อตรวจสอบการชน โดยแสดงเฉพาะชื่อ Collider
                Debug.Log($"Correct collision detected! Player Collider: {this.gameObject.name}, Wall Collider: {collision.gameObject.name}");

                DataHandlerSingleton.Instance.score += 1;
                ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
                scoreManager.UpdateScoreDisplay();

                // อัพเดท UI Text ด้วยคะแนนล่าสุด
                //if (scoreText != null)
                //{
                //    scoreText.text = "Score: " + score;  // แสดงคะแนนใน UI
                //}

                return; // ออกจากลูปเมื่อพบคู่ที่ตรง
            }
        }
    }
}
             