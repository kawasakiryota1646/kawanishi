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

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip icicleSE;
    [SerializeField] private AudioClip ice;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;

    }

    public void Fall()
    {
        if (hasFallen) return;
        hasFallen = true;

        audioSource.PlayOneShot(icicleSE);

        rb.gravityScale = fallGravity;
        StartCoroutine(FallDelay());

    }

    IEnumerator FallDelay()
    {
        yield return new WaitForSeconds(delay);

        rb.gravityScale = fallGravity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Debug.Log("âÛÇÍÇÈ");
            // ï\é¶Çè¡Ç∑
            GetComponent<SpriteRenderer>().enabled = false;

            // ìñÇΩÇËîªíËÇè¡Ç∑
            GetComponent<Collider2D>().enabled = false;
            audioSource.PlayOneShot(ice);
            Destroy(gameObject, ice.length);
        }
    }
}
