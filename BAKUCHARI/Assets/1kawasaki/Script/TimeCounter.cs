using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeCounter : MonoBehaviour
{

    private PlayerManager playermanager;
    bool IsStop = false;

    //カウントダウン
    public float countdown = 5.0f;

    //時間を表示する変数
    public Text timeText;
    void Start()
    {
        playermanager = FindAnyObjectByType<PlayerManager>();
    }
    public void StopTime()//カウントダウンストップ用
    {
        IsStop = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (IsStop) return;


        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f1") + "秒";

        //countdownが0以下になったときリスタート
        if (countdown <= 0)
        {
            IsStop = true;

            timeText.text = "ゲームオーバー";

            StartCoroutine(playermanager.TimeRestart());


        }
    }
}
