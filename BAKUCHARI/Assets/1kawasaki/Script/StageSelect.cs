using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageSelect : MonoBehaviour
{
    [SerializeField] private string _loadScene; //シーン名を記述
    public AudioSource audioSource;
    public AudioClip clickSE;
    [SerializeField] private float Length = 0.3f;

    public void LoadStage(string stageName)
    {
        StartCoroutine(LoadScene(stageName));

    }
    IEnumerator LoadScene(string stageName)
    {
        audioSource.PlayOneShot(clickSE);
        yield return new WaitForSeconds(Length);

        SceneManager.LoadScene(stageName);

    }

}
