using UnityEngine;

public class WallCollisionHandler : MonoBehaviour
{
    // เมื่อชนกับ Collider ใดๆ
    private void OnTriggerEnter(Collider collision)
    {
        // Debug Log เพื่อตรวจสอบการชน
        Debug.Log($"Wall Collider '{this.gameObject.name}' with Tag '{this.gameObject.tag}' was hit by '{collision.gameObject.name}'.");
    }
}

/* 
  This script is optional.It's only used for printing debug messages when something hits the wall.
  It shows which object collided and with what part, based on tags. You can remove it without affecting gameplay.

 */