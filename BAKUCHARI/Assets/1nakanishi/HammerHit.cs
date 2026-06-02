using UnityEngine;

public class HammerHit : MonoBehaviour
{
    public float force = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }
        }
    }
}