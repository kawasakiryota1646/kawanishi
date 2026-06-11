using UnityEngine;

public static class RecordManager
{
    public static void SaveTime(int stageNo, float time)
    {
        string key = "Stage" + stageNo;

        float bestTime = PlayerPrefs.GetFloat(key, -1);

        // Žc‚èŽžŠÔ‚Í‘å‚«‚¢•û‚ª—Ç‚¢
        if (bestTime < 0 || time > bestTime)
        {
            PlayerPrefs.SetFloat(key, time);
            PlayerPrefs.Save();
        }
    }

    public static float GetBestTime(int stageNo)
    {
        return PlayerPrefs.GetFloat("Stage" + stageNo, -1);
    }
}