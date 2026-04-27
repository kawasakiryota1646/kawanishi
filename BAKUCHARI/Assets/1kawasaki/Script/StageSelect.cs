using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageSelect : MonoBehaviour
{
    public void OnStage1Button()
    {
        SceneManager.LoadScene("stage1");
    }

    public void OnStage2Button()
    {
        SceneManager.LoadScene("stage2");
    }
    public void OnTitleButton()
    {
        SceneManager.LoadScene("title");
    }

}
