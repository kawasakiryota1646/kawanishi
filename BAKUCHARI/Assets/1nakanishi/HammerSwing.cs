using UnityEngine;

public class HammerSwing : MonoBehaviour
{
    public float angle = 60f;   // U‚ê‚éŠp“x
    public float speed = 2f;    // U‚é‘¬‚³

    void Update()
    {
        float z = Mathf.Sin(Time.time * speed) * angle;

        transform.rotation = Quaternion.Euler(0, 0, z);
    }
}