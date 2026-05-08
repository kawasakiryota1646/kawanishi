using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Judgment : MonoBehaviour
{
    public string deathTag = "ground"; // ← Unity側で変更できる
    bool IsGoal = false;
    public Text GameOver;
    private PlayerManager playerManager;

    void Start()
    {
        // 同じオブジェクトについている PlayerManager を取得
        playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager == null)
        {
            Debug.LogError("Null PlayerManager");
            return;
        }

    }

    // 衝突したとき
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (playerManager.IsGoal)
            return;

        if (!IsGoal && collision.gameObject.CompareTag(deathTag))
        {
            GameOver.text = "ゲームオーバー";
            Debug.Log("死んだ！");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}