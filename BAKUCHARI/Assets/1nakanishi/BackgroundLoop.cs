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
        // îwåiÇç∂Ç…ó¨Ç∑
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // ç∂Ç…è¡Ç¶ÇΩÇÁâEÇ÷
        if (transform.position.x < cameraTransform.position.x - width)
        {
            transform.position += new Vector3(width * 2f, 0, 0);
        }

        // âEÇ…è¡Ç¶ÇΩÇÁç∂Ç÷
        if (transform.position.x > cameraTransform.position.x + width)
        {
            transform.position -= new Vector3(width * 2f, 0, 0);
        }
    }
}