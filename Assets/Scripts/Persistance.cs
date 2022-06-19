using System;
using System.IO;
using UnityEngine;

public class Persistance : MonoBehaviour
{
    public static Persistance Instance;
    public string playerName { get; set; }
    public PlayerData playerStats;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveBestScore(int newBest)
    {
        PlayerData data = new PlayerData();
        data.bestScore = newBest;
        data.player = playerName;

        playerStats = data;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            playerStats = data;
        }
    }

    [Serializable]
    public class PlayerData
    {
        public int bestScore;
        public string player;
    }
}
