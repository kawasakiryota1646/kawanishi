using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed = 1f;
    public float distanceFromCamera = 20f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // ¶‚ÖˆÚ“®
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // ƒJƒƒ‰‚æ‚è¶‚Ös‚«‚·‚¬‚½‚ç‰E‚Ö–ß‚·
        if (transform.position.x < cam.transform.position.x - distanceFromCamera)
        {
            Vector3 pos = transform.position;

            pos.x = cam.transform.position.x + distanceFromCamera;

            transform.position = pos;
        }
    }
}
