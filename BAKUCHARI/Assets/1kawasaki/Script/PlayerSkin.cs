using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    public GameObject normal_bike;
    public GameObject uma_bike;

    private bool isSkin = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) &&
    Input.GetKeyDown(KeyCode.C))
        {
            UmaForm();
        }

    }
    void UmaForm()
    {
        isSkin = !isSkin;
        
        normal_bike.SetActive(!isSkin);
        uma_bike.SetActive(isSkin);
    }
}
