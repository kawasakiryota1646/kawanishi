using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float range = 3f;

    public bool moveUpDown;

    Vector3 startPos;
    float timer;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float move = Mathf.Sin(timer * speed) * range;

        if (moveUpDown)
        {
            transform.position = startPos + new Vector3(0, move, 0);
        }
        else
        {
            transform.position = startPos + new Vector3(move, 0, 0);
        }
    }
}