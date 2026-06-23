using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public enum GameState//プレイヤーの状況確認
    {
        Playing,
        Clear,
        Dead
    }

    public static GameState State = GameState.Playing;

    public bool IsGoal = false;
    [SerializeField] private TimeCounter timeCounter;
    //変数
    public Text ClearText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip goalSE;
    [SerializeField] private AudioClip overSE;

    private InputAction Bell;
    void Start()//スタート時にプレイ状態を保存する
    {
        State = GameState.Playing;
    }
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
        audioSource.PlayOneShot(overSE);
        yield return new WaitForSeconds(2.0f);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

        Debug.Log("リトライ");


    }

    //ゴールに触れたとき
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerManager.State != GameState.Playing)
            return;

        if (collision.CompareTag("goal"))
        {
            Debug.Log("ゴール");

            int stageNo = SceneManager.GetActiveScene().buildIndex;

            RecordManager.SaveTime(stageNo, timeCounter.countdown);

            Debug.Log("保存:" + timeCounter.countdown);

            PlayerManager.State = GameState.Clear;

            IsGoal = true;

            audioSource.PlayOneShot(goalSE);
            timeCounter.StopTime();

            StartCoroutine(Clear());
        }
    }

    IEnumerator Clear()//1.5秒経つと次のステージに行く
    {
        ClearText.text = "CLEAR!";
        yield return new WaitForSeconds(1.5f);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
        Debug.Log("Clear!");
    }

}
