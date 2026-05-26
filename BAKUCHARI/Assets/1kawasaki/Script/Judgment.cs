using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Judgment : MonoBehaviour
{
    public string deathTag = "ground";
    bool IsGoal = false;

    public TMP_Text GameOver;

    private PlayerManager playerManager;

    private bool isDead = false;

    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();

        if (playerManager == null)
        {
            Debug.LogError("Null PlayerManager");
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 二重実行防止
        if (isDead) return;

        if (playerManager.IsGoal)
            return;

        if (!IsGoal && collision.gameObject.CompareTag(deathTag))
        {
            isDead = true;

            GameOver.text = "GameOver";
            Debug.Log("死んだ！");

            // Coroutine開始
            StartCoroutine(GameOverDelay());
        }
    }

    IEnumerator GameOverDelay()
    {
        // 2秒待機
        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}