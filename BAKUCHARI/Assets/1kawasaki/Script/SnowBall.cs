using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField] private float moveForce = 15f;
    [SerializeField] private float playerKnockback = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 moveDir = new Vector2(1f, 0.5f).normalized;

        rb.AddForce(moveDir * moveForce, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D targetRb =
            collision.gameObject.GetComponent<Rigidbody2D>();

        if (targetRb == null) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 knockDir =
                (collision.transform.position - transform.position).normalized;

            targetRb.AddForce(
                knockDir * playerKnockback,
                ForceMode2D.Impulse
            );
        }

    }
}