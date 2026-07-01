using UnityEngine;

public class KirinoBike : MonoBehaviour
{
    [Header("Sprite Renderers")]
    public SpriteRenderer bodyRenderer;
    public SpriteRenderer handleRenderer;
    public SpriteRenderer pedal1Renderer;
    public SpriteRenderer pedal2Renderer;
    public SpriteRenderer pedal3Renderer;
    public SpriteRenderer saddleRenderer;
    public SpriteRenderer tireRenderer;
    public SpriteRenderer tireCenterRenderer;
    public SpriteRenderer tire2Renderer;
    public SpriteRenderer tireCenter2Renderer;


    [Header("Blue Sprites")]
    public Sprite blueBody;
    public Sprite blueHandle;
    public Sprite bluePedal1;
    public Sprite bluePedal2;
    public Sprite bluePedal3;
    public Sprite blueSaddle;
    public Sprite blueTire;
    public Sprite blueTireCenter;
    public Sprite blueTire2;
    public Sprite blueTireCenter2;

    [Header("Red Sprites")]
    public Sprite redBody;
    public Sprite redHandle;
    public Sprite redPedal1;
    public Sprite redPedal2;
    public Sprite redPedal3;
    public Sprite redSaddle;
    public Sprite redTire;
    public Sprite redTireCenter;
    public Sprite redTire2;
    public Sprite redTireCenter2;

    private bool isBlue = true;
    private bool alreadySwitched = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.K) &&
            Input.GetKey(KeyCode.L) &&
            Input.GetKeyDown(KeyCode.N))
        {
            SwitchBike();
        }
    }

    void SwitchBike()
    {
        if (alreadySwitched) return;

        isBlue = !isBlue;
        alreadySwitched = true;

        UpdateBike();
    }

    void UpdateBike()
    {
        if (isBlue)
        {
            bodyRenderer.sprite = blueBody;
            handleRenderer.sprite = blueHandle;
            pedal1Renderer.sprite = bluePedal1;
            pedal2Renderer.sprite = bluePedal2;
            pedal3Renderer.sprite = bluePedal3;
            saddleRenderer.sprite = blueSaddle;
            tireRenderer.sprite = blueTire;
            tireCenterRenderer.sprite = blueTireCenter;
            tire2Renderer.sprite = blueTire2;
            tireCenter2Renderer.sprite = blueTireCenter2;

        }
        else
        {
            bodyRenderer.sprite = redBody;
            handleRenderer.sprite = redHandle;
            pedal1Renderer.sprite = redPedal1;
            pedal2Renderer.sprite = redPedal2;
            pedal3Renderer.sprite = redPedal3;
            saddleRenderer.sprite = redSaddle;
            tireRenderer.sprite = redTire;
            tireCenterRenderer.sprite = redTireCenter;
            tire2Renderer.sprite = redTire2;
            tireCenter2Renderer.sprite = redTireCenter2;

        }
    }
}
