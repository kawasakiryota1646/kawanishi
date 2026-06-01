using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpPower = 15f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // âÒì]Çé~ÇﬂÇÈ
            rb.angularVelocity = 0f;

            // ê^è„Ç…îÚÇŒÇ∑
            rb.linearVelocity = new Vector2(0f, jumpPower);
        }
    }
}
