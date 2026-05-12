using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;   // “®‚­‘¬‚³
    public float range = 3f;   // “®‚­‹——£

    public bool moveUpDown;    // true‚È‚çã‰ºAfalse‚È‚ç¶‰E

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float move = Mathf.Sin(Time.time * speed) * range;

        if (moveUpDown)
        {
            // ã‰ºˆÚ“®
            transform.position = startPos + new Vector3(0, move, 0);
        }
        else
        {
            // ¶‰EˆÚ“®
            transform.position = startPos + new Vector3(move, 0, 0);
        }
    }
}