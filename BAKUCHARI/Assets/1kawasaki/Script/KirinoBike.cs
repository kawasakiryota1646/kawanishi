using UnityEngine;

public class KirinoBike : MonoBehaviour
{
    //元のバイクのSprite
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

    //青バイクのSprite
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

    //キリノバイクのSprite
    [Header("Kirino Sprites")]
    public Sprite KirinoBody;
    public Sprite KirinoHandle;
    public Sprite KirinoPedal1;
    public Sprite KirinoPedal2;
    public Sprite KirinoPedal3;
    public Sprite KirinoSaddle;
    public Sprite KirinoTire;
    public Sprite KirinoTireCenter;
    public Sprite KirinoTire2;
    public Sprite KirinoTireCenter2;

    private bool isBlue = true;
    private bool alreadySwitched = false;

    [SerializeField] private ParticleSystem particle;

    void Update()//K,L,Nを押すとスキン変更
    {
        if (Input.GetKey(KeyCode.K) &&
            Input.GetKey(KeyCode.L) &&
            Input.GetKeyDown(KeyCode.N))
        {
            particle.Play();


            SwitchBike();
        }
    }

    void SwitchBike()
    {
        //変更済みの場合変更できない
        if (alreadySwitched) return;

        isBlue = !isBlue;
        alreadySwitched = true;

        UpdateBike();
    }

    void UpdateBike()//青とキリノバイクを入れ替える
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
            bodyRenderer.sprite = KirinoBody;
            handleRenderer.sprite = KirinoHandle;
            pedal1Renderer.sprite = KirinoPedal1;
            pedal2Renderer.sprite = KirinoPedal2;
            pedal3Renderer.sprite = KirinoPedal3;
            saddleRenderer.sprite = KirinoSaddle;
            tireRenderer.sprite = KirinoTire;
            tireCenterRenderer.sprite = KirinoTireCenter;
            tire2Renderer.sprite = KirinoTire2;
            tireCenter2Renderer.sprite = KirinoTireCenter2;

        }
    }
}
