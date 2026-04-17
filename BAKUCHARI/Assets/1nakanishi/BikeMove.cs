using UnityEngine;
using UnityEngine.InputSystem;

public class BikeMove : MonoBehaviour
{
    public float speed = 1000f;          // タイヤの回転速度
    public float acceleration = 2000f;   // 加速の速さ
    public float airTorque = 10f;        // 空中での回転力

    public WheelJoint2D rearWheel;      // 後輪（モーター）
    private Rigidbody2D rb;

    private float currentSpeed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float input = 0f;

        // 前進・後退
        if (Keyboard.current.wKey.isPressed)
            input = 1f;
        else if (Keyboard.current.sKey.isPressed)
            input = -1f;

        // タイヤ回転（ここが重要）
        float targetSpeed = -input * speed;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        JointMotor2D motor = rearWheel.motor;
        motor.motorSpeed = currentSpeed;
        rearWheel.motor = motor;

        // 空中で回転（バランス操作）
        if (Keyboard.current.aKey.isPressed)
            rb.AddTorque(airTorque);

        if (Keyboard.current.dKey.isPressed)
            rb.AddTorque(-airTorque);
    }
}