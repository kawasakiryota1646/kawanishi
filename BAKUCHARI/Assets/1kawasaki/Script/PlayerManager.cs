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
    private TimeCounter timeCounter;
    public Text ClearText;


    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.rKey.wasPressedThisFrame)//Rキーでリトライ
        {
            Retry();
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

    //ゴールに触れたとき
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("goal") && !IsGoal)
        {
            IsGoal = true;

            timeCounter.StopTime();//クリアしたらカウントダウンを止める

            StartCoroutine(Clear());
            Debug.Log("ゴールに触れた！");
        }
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
