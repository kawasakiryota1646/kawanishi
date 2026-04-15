using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    private void OnCollisionEnter2D(Collision2D collision)//地面に当たったら死亡
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }

    private void Retry()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

    }

}
