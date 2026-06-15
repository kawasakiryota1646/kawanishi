using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    [SerializeField] private string _loadScene; //シーン名を記述

    //public void OnStartButton()
    //{
    //    SceneManager.LoadScene("StageSelect");
    //    Destroy(GameObject.Find("BGMManager"));

    //}
    public void LoadStage(string stageName)
    {
        SceneManager.LoadScene(stageName);
        Destroy(GameObject.Find("BGMManager"));

    }

    public void ExitButton()
    {
    #if UNITY_EDITOR
        
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        
        Application.Quit();
    #endif
    }
}
