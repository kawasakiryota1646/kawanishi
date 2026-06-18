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
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip overSE;

    public TMP_Text GameOver;

    private PlayerManager playerManager;

    private static bool isDead = false;
    void Start()
    {

        isDead = false;
        playerManager = FindObjectOfType<PlayerManager>();

        if (playerManager == null)
        {
            Debug.LogError("Null PlayerManager");
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ìÒèdé¿çsñhé~
        if (isDead) return;

        if (playerManager.IsGoal)
            return;

        if (!IsGoal && collision.gameObject.CompareTag(deathTag))
        {
            isDead = true;
            audioSource.PlayOneShot(overSE);

            GameOver.text = "GameOver";
            Debug.Log("éÄÇÒÇæÅI");

            // CoroutineäJén
            StartCoroutine(GameOverDelay());
        }
    }

    IEnumerator GameOverDelay()
    {
        // 2ïbë“ã@
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}