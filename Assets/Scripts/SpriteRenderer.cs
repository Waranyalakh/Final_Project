using UnityEngine;

public class ButtonSpriteController : MonoBehaviour
{
    public GameObject pressedSprite; // Assign the pressed sprite in the inspector

    void Update()
    {
        if (Input.anyKeyDown) // เมื่อกดปุ่มใด ๆ
        {
            if (!Input.GetKeyDown(KeyCode.Space)) // ยกเว้นปุ่มที่ใช้กด sprite นี้
            {
                pressedSprite.SetActive(false); // ปิดการแสดงผล sprite
            }
        }
    }
}
