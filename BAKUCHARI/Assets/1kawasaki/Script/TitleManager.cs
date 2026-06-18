using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    [SerializeField] private string _loadScene; //シーン名を記述
    public AudioSource audioSource;
    public AudioClip clickSE;
    [SerializeField] private float Length=0.5f;
    public void LoadStage(string stageName)
    {
        StartCoroutine(LoadScene(stageName));

    }

    IEnumerator LoadScene(string stageName)
    {
        audioSource.PlayOneShot(clickSE);
        yield return new WaitForSeconds(Length);

        Destroy(GameObject.Find("BGMManager"));
        SceneManager.LoadScene(stageName);

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
