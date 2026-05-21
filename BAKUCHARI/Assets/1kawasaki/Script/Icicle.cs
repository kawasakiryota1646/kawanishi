using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Icicle : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float fallGravity = 3f;

    bool hasFallen = false;

    [SerializeField]
    float delay = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

    }

    public void Fall()
    {
        if (hasFallen) return;

        hasFallen = true;
        rb.gravityScale = fallGravity;
        StartCoroutine(FallDelay());

    }

    IEnumerator FallDelay()
    {
        yield return new WaitForSeconds(delay);

        rb.gravityScale = 3;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            StartCoroutine(FallDelay());

            Destroy(gameObject);
        }
    }
}
