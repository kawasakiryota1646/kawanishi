using UnityEngine;

public class HammerSwing : MonoBehaviour
{
    public float angle = 60f;
    public float speed = 2f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        float z = Mathf.Sin(timer * speed) * angle;

        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}