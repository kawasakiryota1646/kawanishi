using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotateSpeed = 100f;

    void Update()
    {
        // ZŽ²‚É‰ñ“]
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}