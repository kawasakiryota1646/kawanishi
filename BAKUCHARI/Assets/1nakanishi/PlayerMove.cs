using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1f;
    public float acceleration = 1f;
    public float deceleration = 1f;

    private Rigidbody2D rb;
    private float targetMove = 0f;
    private float currentMove = 0f;

    private bool isGrounded = false; // 接地してるか

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 入力
        if (Keyboard.current.wKey.isPressed)
            targetMove = 1f;
        else if (Keyboard.current.sKey.isPressed)
            targetMove = -1f;
        else
            targetMove = 0f;

        // 空中なら動かさない
        if (!isGrounded)
        {
            targetMove = 0f;
        }

        // 慣性処理
        if (Mathf.Abs(targetMove - currentMove) > 0.01f)
        {
            if (targetMove != 0)
                currentMove = Mathf.MoveTowards(currentMove, targetMove, acceleration * Time.deltaTime);
            else
                currentMove = Mathf.MoveTowards(currentMove, 0f, deceleration * Time.deltaTime);
        }

        // 移動
        rb.linearVelocity = new Vector2(currentMove * speed, rb.linearVelocity.y);
    }

    // 何かに触れたら接地
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    // 離れたら空中
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}