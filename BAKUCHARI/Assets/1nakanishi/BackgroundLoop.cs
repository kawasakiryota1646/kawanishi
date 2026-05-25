using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public Transform cameraTransform;

    // プレイヤー
    public Rigidbody2D playerRb;

    public float moveSpeed = 1f;

    float width;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // プレイヤーが動いている時だけ背景を動かす
        if (Mathf.Abs(playerRb.linearVelocity.x) > 0.1f)
        {
            // 背景を左に流す
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        // 左に消えたら右へ
        if (transform.position.x < cameraTransform.position.x - width)
        {
            transform.position += new Vector3(width * 2f, 0, 0);
        }

        // 右に消えたら左へ
        if (transform.position.x > cameraTransform.position.x + width)
        {
            transform.position -= new Vector3(width * 2f, 0, 0);
        }
    }
}