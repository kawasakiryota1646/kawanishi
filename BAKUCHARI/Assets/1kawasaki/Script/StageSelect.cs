using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageSelect : MonoBehaviour
{
    [SerializeField] private string _loadScene; //シーン名を記述

    public void LoadStage(string stageName)
    {
        SceneManager.LoadScene(stageName);
    }
}
