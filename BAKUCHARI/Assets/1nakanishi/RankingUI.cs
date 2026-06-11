using TMPro;
using UnityEngine;

public class RankingUI : MonoBehaviour
{
    public TMP_Text[] stageTexts;

    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            float time = RecordManager.GetBestTime(i);

            if (time < 0)
            {
                stageTexts[i - 1].text =
                    $"STAGE {i} : ---";
            }
            else
            {
                stageTexts[i - 1].text =
                    $"STAGE {i} : {time:F1}•b";
            }
        }
    }
}