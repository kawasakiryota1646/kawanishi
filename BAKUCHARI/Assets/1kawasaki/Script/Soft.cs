using UnityEngine;

public class Soft : MonoBehaviour
{
    public float springForce = 5f;
    public float damping = 0.5f;

    void Start()
    {
        var joints = GetComponentsInChildren<SpringJoint2D>();
        foreach (var joint in joints)
        {
            joint.frequency = springForce;
            joint.dampingRatio = damping;
        }
    }
}
