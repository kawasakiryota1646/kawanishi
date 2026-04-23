using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeCounter : MonoBehaviour
{

    private PlayerManager playermanager;

    //カウントダウン
    public float countdown = 5.0f;

    //時間を表示する変数
    public Text timeText;
    void Start()
    {
        playermanager = FindAnyObjectByType<PlayerManager>();
    }  
    
    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f1") + "秒";

        //countdownが0以下になったときリスタート
        if (countdown <= 0)
        {
            timeText.text = "ゲームオーバー";

            StartCoroutine(playermanager.TimeRestart());


        }
    }
}
