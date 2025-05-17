using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI victoryText;
    [SerializeField] private Image frameImg;
    [SerializeField] private Image rankImg;

    private int fullScoreStage1 = 195;
    private int fullScoreStage2 = 195;
    private int fullScoreStage3 = 195;

    [SerializeField] private FinalSceneDataBaseSO database;

    [ContextMenu("Test display")]
    public void SetDisplayTest(int num)
    {
        if (victoryText != null)
            victoryText.text = database.victoryTextList[num];
        if (frameImg != null)
            frameImg.sprite = database.framesList[num];
        if (rankImg != null)
            rankImg.sprite = database.rankList[num];
    }

    void Start()
    {
        UpdateScoreDisplay();
    }

    public void UpdateScoreDisplay()
    {
        // ดึงข้อมูล selectedStage และ playerScore จาก DataHandlerSingleton
        int selectedStage = DataHandlerSingleton.Instance.selectedStage;
        int playerScore = DataHandlerSingleton.Instance.score;

        // ตรวจสอบและดักค่า selectedStage
        if (selectedStage < 1 || selectedStage > 3)
        {
            Debug.LogWarning("Invalid selectedStage value! Defaulting to Stage 1.");
            selectedStage = 1; // ตั้งค่าเริ่มต้นเป็น Stage 1
        }

        // ตรวจสอบและดักค่า score
        if (playerScore <= 0)
        {
            Debug.LogWarning("Invalid score value! Setting score to 0.");
            playerScore = 0; // ตั้งค่าเริ่มต้นเป็น 0
        }

        int GetscoreInParts(int playerScore)
        {
            if (playerScore > 195) //แก้เอา 195 ออก
                return 6;
            else if (playerScore >= 160)
                return 5; // MASTER
            else if (playerScore >= 132)
                return 4; // EXPERT
            else if (playerScore >= 95)
                return 3; // ADVANCED
            else if (playerScore >= 70)
                return 2; // INTERMEDIATE
            else if (playerScore >= 50)
                return 1; // BEGINNER
            else if (playerScore >= 1)
                return 0; // FAIL
            else
                return 0; // กรณี playerScore <= 0 ถือว่า FAIL
        }

        int scoreInParts = GetscoreInParts(playerScore);

        // คำนวณคะแนนแต่ละส่วน
        //int scorePerPart = fullScore / 6;
        //int scoreInParts = Mathf.FloorToInt((float)playerScore / scorePerPart);

        // จำกัดค่า scoreInParts ไม่ให้เกิน 5
        //if (scoreInParts > 5)
        //    scoreInParts = 5;

        // อัปเดต victoryIndex และแสดงผล
        DataHandlerSingleton.Instance.victoryIndex = scoreInParts;
        SetDisplayTest(scoreInParts);
    }

    int GetFullScoreForCurrentStage(int stage)
    {
        // ตรวจสอบและดักค่า stage
        if (stage < 1 || stage > 3)
        {
            Debug.LogWarning("Invalid stage value in GetFullScoreForCurrentStage! Defaulting to Stage 1.");
            return fullScoreStage1; // คืนค่าคะแนนเต็มของ Stage 1
        }

        // คืนค่าคะแนนเต็มตาม Stage
        switch (stage)
        {
            case 1:
                return fullScoreStage1;
            case 2:
                return fullScoreStage2;
            case 3:
                return fullScoreStage3;
            default:
                Debug.LogError("Stage ไม่มีคะแนน");
                return fullScoreStage1; // คืนค่าคะแนนเต็มของ Stage 1 หากเกิดกรณีที่ไม่คาดคิด
        }
    }
}