using UnityEngine;

public class DashPad : MonoBehaviour
{
    public float dashPower = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // ƒ_ƒbƒVƒ…”Â‚ÌŒü‚«‚É‰Á‘¬
            rb.linearVelocity = transform.right * dashPower;
        }
    }
}