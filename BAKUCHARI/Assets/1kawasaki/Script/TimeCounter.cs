using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{

    private PlayerManager playermanager;
    bool IsStop = false;
    private bool FifteenSecondAnnounced = false;
    //カウントダウン
    public float countdown = 5.0f;

    //時間を表示する変数
    public TMP_Text TimeText;
    public TMP_Text GameOver;
    [Header("BGM")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip normalBGM;
    [SerializeField] private AudioClip hurryBGM;

    [Header("SE")]
    [SerializeField] private AudioSource seSource;
    [SerializeField] private AudioClip warningSE;

    [Header("warning UI")]
    [SerializeField] private RectTransform warningText;
    [SerializeField] private float scrollSpeed = 300f;

    private bool isUrgentActive = false;
    void Start()
    {
        playermanager = FindAnyObjectByType<PlayerManager>();
        // 通常BGM再生
        if (audioSource != null && normalBGM != null)
        {
            audioSource.clip = normalBGM;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    public void StopTime()//カウントダウンストップ用
    {
        IsStop = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (IsStop) return;

        countdown -= Time.deltaTime;

        TimeText.text = countdown.ToString("f1");

        // 15秒アナウンス
        if (!FifteenSecondAnnounced && countdown <= 15f)
        {
            FifteenSecondAnnounced = true;

            // SEを2回鳴らす
            StartCoroutine(PlayWarningSE());
            isUrgentActive = true;
            warningText.gameObject.SetActive(true);

            // 右側スタート位置に配置
            warningText.anchoredPosition = new Vector2(800f, warningText.anchoredPosition.y);
            // BGM切り替え
            if (audioSource != null && hurryBGM != null)
            {
                audioSource.clip = hurryBGM;
                audioSource.Play();
            }
        }
        if (isUrgentActive)
        {
            warningText.anchoredPosition += Vector2.left * scrollSpeed * Time.deltaTime;

            // 画面外に出たら止める
            if (warningText.anchoredPosition.x < -800f)
            {
                isUrgentActive = false;
                warningText.gameObject.SetActive(false);
            }
        }

        // 時間切れ
        if (countdown <= 0)
        {
            IsStop = true;

            GameOver.text = "GameOver";

            StartCoroutine(playermanager.TimeRestart());
        }


    }

    //SEを2回鳴らす処理
    IEnumerator PlayWarningSE()
    {
        for (int i = 0; i < 2; i++)
        {
            if (seSource != null && warningSE != null)
            {
                seSource.PlayOneShot(warningSE);
            }

            yield return new WaitForSeconds(0.8f);
        }
    }
}
