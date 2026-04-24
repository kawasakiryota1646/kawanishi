using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //変数
    bool IsGoal = false;
    Vector3 StartPos;
    private TimeCounter timeCounter;
    public Text ClearText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartPos = transform.position;//初期位置の保存
        timeCounter = FindAnyObjectByType<TimeCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.rKey.wasPressedThisFrame)//Rキーでリトライ
        {
            Retry();
        }
    }

    //地面に当たったら死亡
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!IsGoal && collision.gameObject.CompareTag("ground"))//ゴール後は死なない
        {
            Debug.Log("死んだ！");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //ゴールに触れたとき
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("goal")&&!IsGoal)
        {
            IsGoal = true;

            timeCounter.StopTime();//クリアしたらカウントダウンを止める

            StartCoroutine(Clear());
            Debug.Log("ゴールに触れた！");
        }
    }


    private void Retry()//Rキーを押されたときにやり直す
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Debug.Log("リトライ");

    }

    public IEnumerator TimeRestart()//Timeが0になったらリスポーン
    {
        yield return new WaitForSeconds(1.0f);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

        Debug.Log("リトライ");


    }

    IEnumerator Clear()//1.5秒経つと次のステージに行く
    {
        ClearText.text = "CLEAR！！";
        yield return new WaitForSeconds(1.5f);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
        Debug.Log("Clear!");
    }


}
