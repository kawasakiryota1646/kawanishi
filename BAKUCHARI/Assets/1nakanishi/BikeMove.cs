using UnityEngine;
using UnityEngine.InputSystem;

public class BikeMove : MonoBehaviour
{
    public Rigidbody2D rearWheel;
    public float motorSpeed = 2000f;

    void FixedUpdate()
    {
        float moveInput = 0f;

        // ‰Ÿ‚µ‚Ä‚éŠÔ‚¾‚¯“ü—Í
        if (Keyboard.current.wKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            moveInput = 1f;
        }
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            moveInput = -1f;
        }

        // ‰Ÿ‚µ‚Ä‚éŽž‚¾‚¯‰ñ‚·
        if (moveInput != 0f)
        {
            rearWheel.AddTorque(-moveInput * motorSpeed);
        }
    }
}