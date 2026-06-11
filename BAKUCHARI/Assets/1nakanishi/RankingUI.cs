using UnityEngine;
using TMPro;

public class RankingUI : MonoBehaviour
{
    public TMP_Text[] stageTexts;

    void Start()
    {
        UpdateRanking();
    }

    void UpdateRanking()
    {

        Debug.Log(stageTexts.Length);

        for (int i = 1; i <= 10; i++)
        {
            float time = RecordManager.GetBestTime(i);

            if (time < 0)
                stageTexts[i - 1].text = $"STAGE{i} : ---";
            else
                stageTexts[i - 1].text = $"STAGE{i} : {time:F1}";
        }
    }

    public void ResetRanking()
    {
        Debug.Log("リセット開始");

        for (int i = 1; i <= 10; i++)
        {
            PlayerPrefs.DeleteKey("Stage" + i);
        }

        PlayerPrefs.Save();

        Debug.Log("Stage1=" + PlayerPrefs.GetFloat("Stage1", -1));

        UpdateRanking();
    }
}