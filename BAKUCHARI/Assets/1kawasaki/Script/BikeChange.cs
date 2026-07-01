using UnityEngine;

public class BikeChange : MonoBehaviour
{
 public SpriteRenderer bodyRenderer;

    public Sprite blueSprite;
    public Sprite redSprite;

    private bool isBlue = true;
    private bool alreadySwitched = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.U)&& Input.GetKey(KeyCode.M) && Input.GetKeyDown(KeyCode.A))
        {
            SwitchBike();
        }
    }

    void SwitchBike()
    {
        // Ç∑Ç≈Ç…êÿÇËë÷Ç¶çœÇ›Ç»ÇÁâΩÇ‡ÇµÇ»Ç¢
        if (alreadySwitched) return;

        isBlue = !isBlue;
        alreadySwitched = true;

        UpdateBike();
    }

    void UpdateBike()
    {
        bodyRenderer.sprite = isBlue ? blueSprite : redSprite;
    }}
