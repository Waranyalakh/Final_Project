using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotation : MonoBehaviour
{
    [SerializeField] private InputAction press, axis;
    [SerializeField] private float speed = 1;

    private Vector2 rotation;
    private bool rotateAllowed;
    private Transform modelTransform;

    private void Awake()
    {
        modelTransform = this.transform;
    }

    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0, -180, 0); // ตั้งค่าให้เริ่มต้นที่ x:0, y:180, z:0

        press.Enable();
        axis.Enable();

        press.performed += StartRotation;
        press.canceled += StopRotation;
        axis.performed += UpdateRotation;
    }

    private void OnDisable()
    {
        press.performed -= StartRotation;
        press.canceled -= StopRotation;
        axis.performed -= UpdateRotation;

        press.Disable();
        axis.Disable();
    }

    private void StartRotation(InputAction.CallbackContext _)
    {
        if (!gameObject.activeInHierarchy) return;
        StartCoroutine(Rotate());
    }

    private void StopRotation(InputAction.CallbackContext _)
    {
        rotateAllowed = false;
    }

    private void UpdateRotation(InputAction.CallbackContext context)
    {
        rotation = context.ReadValue<Vector2>();
    }

    private IEnumerator Rotate()
    {
        rotateAllowed = true;
        while (rotateAllowed)
        {
            if (modelTransform == null) yield break;
            modelTransform.Rotate(Vector3.up, rotation.x * speed, Space.World);
            yield return null;
        }
    }
}
