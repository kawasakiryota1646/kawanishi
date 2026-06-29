using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip stompSE;
    private bool isPlayed = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPlayed) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayed = true;

            audioSource.PlayOneShot(stompSE);
        }
    }
}
