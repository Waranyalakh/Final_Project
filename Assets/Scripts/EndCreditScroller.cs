using UnityEngine;

public class EndCreditScroller : MonoBehaviour
{
    public float scrollSpeed = 50f;     // ความเร็วในการเลื่อน
    public float startDelay = 3f;       // หน่วงเวลาก่อนเริ่มเลื่อน
    private float endPositionY = 5700f;  // จุดสิ้นสุดที่อยากให้เลื่อนถึง (ใน local Y)

    private RectTransform rectTransform;
    private bool isScrolling = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Invoke("StartScrolling", startDelay);
    }

    void Update()
    {
        if (!isScrolling) return;

        // ถ้ายังไม่ถึงปลายทาง ก็เลื่อนขึ้น
        if (rectTransform.anchoredPosition.y < endPositionY)
        {
            float newY = Mathf.Min(rectTransform.anchoredPosition.y + scrollSpeed * Time.deltaTime, endPositionY);
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, newY);
        }
    }

    void StartScrolling()
    {
        isScrolling = true;
    }
}
