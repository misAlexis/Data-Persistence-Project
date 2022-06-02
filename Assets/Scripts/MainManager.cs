using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string ActivePlayerName;

    public string HighScorePlayerName;
    public int HighScore;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int HighScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.PlayerName = Instance.HighScorePlayerName;
        data.HighScore = Instance.HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText($"{Application.persistentDataPath}/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string filePath = $"{Application.persistentDataPath}/savefile.json";

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Instance.HighScorePlayerName = data.PlayerName;
            Instance.HighScore = data.HighScore;
        }
        else
        {
            Instance.HighScorePlayerName = "No Score";
            Instance.HighScore = 0;
        }
    }
}
