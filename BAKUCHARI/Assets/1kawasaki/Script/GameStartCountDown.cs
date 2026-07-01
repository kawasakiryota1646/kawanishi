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

        RectTransform rt = countdownText.GetComponent<RectTransform>();
        Vector2 originalPos = rt.anchoredPosition; // 元の位置を保存

        yield return new WaitForSecondsRealtime(startDelay);

        // カウントダウン
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            audioSource.PlayOneShot(countSE);

            yield return new WaitForSecondsRealtime(1f);
        }

        // GO!だけ少し左へ
        rt.anchoredPosition = originalPos + new Vector2(-50f, 0f);
        countdownText.text = "GO!";
        audioSource.PlayOneShot(goSE);

        yield return new WaitForSecondsRealtime(1f);

        // 元の位置に戻す
        rt.anchoredPosition = originalPos;
        countdownText.text = "";

        // ゲーム開始
        Time.timeScale = 1f;
    }
}
