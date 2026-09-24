using UnityEngine;
using UnityEngine.InputSystem;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;

    private Vector2 touchStart;

    void Update()
    {
        if (Touchscreen.current == null)
            return;

        var finger = Touchscreen.current.primaryTouch;

        if (finger.press.wasPressedThisFrame)
        {
            touchStart = finger.position.ReadValue();
        }

        if (finger.press.isPressed)
        {
            Vector2 touchNow = finger.position.ReadValue();
            Vector2 movement = touchNow - touchStart;

            transform.Rotate(-movement.x * speed, 0f, 0f);

            touchStart = touchNow;
        }
    }
}