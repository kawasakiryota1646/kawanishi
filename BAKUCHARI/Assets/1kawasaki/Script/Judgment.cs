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

    // 衝突したとき
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsGoal && collision.gameObject.CompareTag(deathTag))
        {
            GameOver.text = "ゲームオーバー";
            Debug.Log("死んだ！");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}