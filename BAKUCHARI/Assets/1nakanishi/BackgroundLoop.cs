using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public Transform cameraTransform;
    public float moveSpeed = 1f;

    float width;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // ­‚µ‚¸‚Â¶‚Ö“®‚­
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // ƒJƒƒ‰‚æ‚è¶‚ÖÁ‚¦‚½‚ç‰E‚ÖˆÚ“®
        if (transform.position.x < cameraTransform.position.x - width)
        {
            transform.position += new Vector3(width * 2f, 0, 0);
        }
    }
}