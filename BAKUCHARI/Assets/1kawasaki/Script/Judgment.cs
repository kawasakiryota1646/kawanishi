using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Judgment : MonoBehaviour
{
    public string deathTag = "ground"; // © Unity‘¤‚Å•ÏX‚Å‚«‚é
    bool IsGoal = false;

    // Õ“Ë‚µ‚½‚Æ‚«
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsGoal && collision.gameObject.CompareTag(deathTag))
        {
            Debug.Log("€‚ñ‚¾I");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}