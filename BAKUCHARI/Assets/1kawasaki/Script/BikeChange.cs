using UnityEngine;

public class BikeChange : MonoBehaviour
{
    public SpriteRenderer bodyRenderer;

    public Sprite blueSprite;
    public Sprite umaSprite;

    [SerializeField] private ParticleSystem particle;

    private bool isBlue = true;
    private bool alreadySwitched = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.U)&& Input.GetKey(KeyCode.M) && Input.GetKeyDown(KeyCode.A))//U,M,A‚ğ‰Ÿ‚·‚ÆƒXƒLƒ“•ÏX
        {

            particle.Play();

            SwitchBike();
        }
    }

    void SwitchBike()
    {
        // ‚·‚Å‚ÉØ‚è‘Ö‚¦Ï‚İ‚È‚ç‰½‚à‚µ‚È‚¢
        if (alreadySwitched) return;

        isBlue = !isBlue;
        alreadySwitched = true;

        UpdateBike();
    }

    void UpdateBike()
    {
        bodyRenderer.sprite = isBlue ? blueSprite : umaSprite;
    }
}
