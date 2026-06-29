using System.Collections;
using UnityEngine;
using TMPro;
public class GameStartCountDown : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    public float startDelay = 1f;
    [Header("SE")]
    public AudioSource audioSource;
    public AudioClip countSE;   
    public AudioClip goSE;      
    void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        // プレイヤー操作を止める
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(startDelay);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            audioSource.PlayOneShot(countSE);

            yield return new WaitForSecondsRealtime(1f);
        }

        countdownText.text = "GO!";

        audioSource.PlayOneShot(goSE);
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = " ";

        // ゲーム開始
        Time.timeScale = 1f;
    }
}
