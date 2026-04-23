using UnityEngine;
using UnityEngine.InputSystem;

public class BikeMove : MonoBehaviour
{
    public Rigidbody2D rearWheel;
    public float motorSpeed = 10f;
    public float rotateSpeed = 20f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveInput = 0f;
        float rotateInput = 0f;

        // 前後移動（W/S）
        if (Keyboard.current.wKey.isPressed)
        {
            moveInput = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            moveInput = -1f;
        }

        // 回転（A/D）
        if (Keyboard.current.aKey.isPressed)
        {
            rotateInput = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            rotateInput = -1f;
        }

        // タイヤ回転
        if (moveInput != 0f)
        {
            rearWheel.AddTorque(-moveInput * motorSpeed);
        }

        // 本体回転
        if (rotateInput != 0f)
        {
            rb.AddTorque(rotateInput * rotateSpeed);
        }
    }
}