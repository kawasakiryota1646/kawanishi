using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public bool IsGoal = false;
    [SerializeField] private TimeCounter timeCounter;
    //変数
    public Text ClearText;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip goalSE;
    [SerializeField] private AudioClip overSE;

    private InputAction Bell;
    void Start()
    {
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
        if (collision.gameObject.CompareTag("goal") && !IsGoal)
        {
            IsGoal = true;
            audioSource.PlayOneShot(goalSE);
            timeCounter.StopTime();

            // 残り時間を保存
            RecordManager.SaveTime(
                SceneManager.GetActiveScene().buildIndex,
                timeCounter.countdown
            );

            StartCoroutine(Clear());
            Debug.Log("ゴールに触れた！");
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
