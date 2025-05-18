using System.IO;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    private string savePath => Path.Combine(Application.persistentDataPath, "save.json");

    public GameStateData currentState = new GameStateData();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(currentState, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game saved: " + savePath);
    }

    public void Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            currentState = JsonUtility.FromJson<GameStateData>(json);
            Debug.Log("Game loaded: " + savePath);
        }
    }
}

[System.Serializable]
public class GameStateData
{
    public int playerLevel = 1;
    public string[] completedQuests;
}