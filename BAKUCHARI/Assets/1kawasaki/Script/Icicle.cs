using UnityEngine;

public class Icicle : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float fallDelay = 0.5f;

    bool activated = false;

    void Start()
    {
        rb.simulated = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;
            Invoke(nameof(Drop), fallDelay);
        }
    }

    void Drop()
    {
        rb.simulated = true;
    }
}
