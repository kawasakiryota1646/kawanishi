using UnityEngine;
using UnityEngine.InputSystem;

public class BikeController : MonoBehaviour
{
    public WheelJoint2D frontWheel;   // 前輪
    public WheelJoint2D backWheel;    // 後輪

    public float motorSpeed = 1000f;  // 回転速度
    public float motorPower = 1000f;  // トルク（力）

    public float airTorque = 5f;      // 空中回転

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = 0f;

        // W/Sで前後
        if (Keyboard.current.wKey.isPressed)
            move = 1f;
        else if (Keyboard.current.sKey.isPressed)
            move = -1f;

        // タイヤの回転
        SetMotor(frontWheel, move);
        SetMotor(backWheel, move);

        // ? 空中で回転（A/D）
        if (!isGrounded)
        {
            if (Keyboard.current.aKey.isPressed)
                rb.AddTorque(airTorque);

            if (Keyboard.current.dKey.isPressed)
                rb.AddTorque(-airTorque);
        }
    }

    void SetMotor(WheelJoint2D wheel, float input)
    {
        JointMotor2D motor = wheel.motor;

        motor.motorSpeed = -input * motorSpeed; // 向き調整
        motor.maxMotorTorque = motorPower;

        wheel.motor = motor;
    }

    // ? 地面に触れてるか
    void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}