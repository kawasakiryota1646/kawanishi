using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1f;
    public float acceleration = 1f;   // 加速
    public float deceleration = 1f;    // 減速

    private Rigidbody2D rb;
    private float targetMove = 0f;     // 目標速度（入力）
    private float currentMove = 0f;    // 実際の速度（慣性あり）

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 入力（新InputSystem）
        if (Keyboard.current.wKey.isPressed)
            targetMove = 1f;
        else if (Keyboard.current.sKey.isPressed)
            targetMove = -1f;
        else
            targetMove = 0f;

        // 慣性（補間）
        if (Mathf.Abs(targetMove - currentMove) > 0.01f)
        {
            if (targetMove != 0)
                currentMove = Mathf.MoveTowards(currentMove, targetMove, acceleration * Time.deltaTime);
            else
                currentMove = Mathf.MoveTowards(currentMove, 0f, deceleration * Time.deltaTime);
        }

        // 実際の移動
        rb.linearVelocity = new Vector2(currentMove * speed, rb.linearVelocity.y);
    }
}
