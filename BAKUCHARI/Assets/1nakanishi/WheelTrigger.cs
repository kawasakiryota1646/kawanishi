using UnityEngine;

public class WheelTrigger : MonoBehaviour
{
    public BikeMove bikeMove;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("DashPad"))
        {
            bikeMove.StartDashPad();
        }
    }
}