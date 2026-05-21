using UnityEngine;

public class IcicleSensor : MonoBehaviour
{
    [SerializeField]
    Icicle icicle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("aaaaaaa");
            icicle.Fall();
        }
    }
}
