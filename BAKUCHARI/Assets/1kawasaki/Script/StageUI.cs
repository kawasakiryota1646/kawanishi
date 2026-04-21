using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUI : MonoBehaviour
{
    public void SelectBack()
    {
        SceneManager.LoadScene("StageSelect");
    }

}
